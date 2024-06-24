
// Type: OpenProtocolInterpreter.MidInterpreter
using OpenProtocolInterpreter.ApplicationController;
using OpenProtocolInterpreter.KeepAlive;
using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OpenProtocolInterpreter
{
  public class MidInterpreter
  {
    private readonly IList<IMessagesTemplate> _messagesTemplates;
    private readonly IDictionary<int, IMessagesTemplate> _fastAccessTemplate;

    public MidInterpreter()
    {
      this._messagesTemplates = (IList<IMessagesTemplate>) new List<IMessagesTemplate>();
      this._fastAccessTemplate = (IDictionary<int, IMessagesTemplate>) new Dictionary<int, IMessagesTemplate>();
    }

    public string Pack(Mid mid) => mid.Pack();

    public byte[] PackBytes(Mid mid) => mid.PackBytes();

    public Mid Parse(string package)
    {
      int mid = int.Parse(package.Substring(4, 4));
      return this.TryParseStandaloneMid(mid) ?? this.GetMessageTemplate(mid).ProcessPackage(mid, package);
    }

    public Mid Parse(byte[] package)
    {
      int mid = int.Parse(Encoding.ASCII.GetString(package, 4, 4));
      return this.TryParseStandaloneMid(mid) ?? this.GetMessageTemplate(mid).ProcessPackage(mid, package);
    }

    public ExpectedMid Parse<ExpectedMid>(string package) where ExpectedMid : Mid
    {
      Mid mid = this.Parse(package);
      return mid.GetType().Equals(typeof (ExpectedMid)) ? (ExpectedMid) mid : throw new InvalidCastException("Package is Mid " + mid.GetType().Name + ", cannot be casted to " + typeof (ExpectedMid).Name);
    }

    public ExpectedMid Parse<ExpectedMid>(byte[] package) where ExpectedMid : Mid
    {
      Mid mid = this.Parse(package);
      return mid.GetType().Equals(typeof (ExpectedMid)) ? (ExpectedMid) mid : throw new InvalidCastException("Package is Mid " + mid.GetType().Name + ", cannot be casted to " + typeof (ExpectedMid).Name);
    }

    internal void UseTemplate(IMessagesTemplate template)
    {
      if (this._messagesTemplates.Any<IMessagesTemplate>((Func<IMessagesTemplate, bool>) (x => x.GetType().Equals(template.GetType()))))
        return;
      this._messagesTemplates.Add(template);
    }

    internal void UseTemplate<T>() where T : IMessagesTemplate
    {
      this.UseTemplate((IMessagesTemplate) Activator.CreateInstance(typeof (T)));
    }

    internal void UseTemplate<T>(InterpreterMode mode) where T : IMessagesTemplate
    {
      this.UseTemplate((IMessagesTemplate) Activator.CreateInstance(typeof (T), (object) mode));
    }

    internal void UseTemplate<T>(IEnumerable<Type> types) where T : IMessagesTemplate
    {
      if (!types.Any<Type>())
        return;
      this.UseTemplate((IMessagesTemplate) Activator.CreateInstance(typeof (T), (object) types));
    }

    internal void UseTemplate<T>(IDictionary<int, Type> types) where T : IMessagesTemplate
    {
      if (!types.Any<KeyValuePair<int, Type>>())
        return;
      IMessagesTemplate template = this._messagesTemplates.FirstOrDefault<IMessagesTemplate>((Func<IMessagesTemplate, bool>) (x => x.GetType().Equals(typeof (T))));
      if (template == null)
      {
        template = (IMessagesTemplate) Activator.CreateInstance(typeof (T), (object) types.Select<KeyValuePair<int, Type>, Type>((Func<KeyValuePair<int, Type>, Type>) (x => x.Value)));
        this.UseTemplate(template);
      }
      template.AddOrUpdateTemplate(types);
    }

    private IMessagesTemplate GetMessageTemplate(int mid)
    {
      IMessagesTemplate messageTemplate;
      if (!this._fastAccessTemplate.TryGetValue(mid, out messageTemplate))
      {
        messageTemplate = this._messagesTemplates.FirstOrDefault<IMessagesTemplate>((Func<IMessagesTemplate, bool>) (x => x.IsAssignableTo(mid)));
        if (messageTemplate == null)
          throw new NotImplementedException(string.Format("Could not found a message parser for mid {0}, please register it before using", (object) mid));
        this._fastAccessTemplate.Add(mid, messageTemplate);
      }
      return messageTemplate;
    }

    private Mid TryParseStandaloneMid(int mid)
    {
      switch (mid)
      {
        case 270:
          return (Mid) new Mid0270();
        case 9999:
          return (Mid) new Mid9999();
        default:
          return (Mid) null;
      }
    }
  }
}
