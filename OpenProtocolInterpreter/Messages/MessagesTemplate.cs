
// Type: OpenProtocolInterpreter.Messages.MessagesTemplate
using System;
using System.Collections.Generic;
using System.Linq;


namespace OpenProtocolInterpreter.Messages
{
  internal abstract class MessagesTemplate : IMessagesTemplate
  {
    protected IDictionary<int, MidCompiledInstance> _templates;

    public MessagesTemplate()
    {
      this._templates = (IDictionary<int, MidCompiledInstance>) new Dictionary<int, MidCompiledInstance>();
    }

    public abstract bool IsAssignableTo(int mid);

    public Mid ProcessPackage(int mid, string package)
    {
      return this.GetMidType(mid).CompiledConstructor().Parse(package);
    }

    public Mid ProcessPackage(int mid, byte[] package)
    {
      return this.GetMidType(mid).CompiledConstructor().Parse(package);
    }

    public void AddOrUpdateTemplate(IDictionary<int, Type> types)
    {
      foreach (KeyValuePair<int, Type> type in (IEnumerable<KeyValuePair<int, Type>>) types)
      {
        if (this._templates.ContainsKey(type.Key))
          this._templates.Remove(type.Key);
        this._templates.Add(type.Key, new MidCompiledInstance(type.Value));
      }
    }

    protected void FilterSelectedMids(InterpreterMode mode)
    {
      if (mode == InterpreterMode.Both)
        return;
      Type type = mode == InterpreterMode.Controller ? typeof (IIntegrator) : typeof (IController);
      this.FilterSelectedMids(this._templates.Values.Where<MidCompiledInstance>((Func<MidCompiledInstance, bool>) (x => type.IsAssignableFrom(x.Type))));
    }

    protected void FilterSelectedMids(IEnumerable<Type> mids)
    {
      this.FilterSelectedMids(this._templates.Values.Where<MidCompiledInstance>((Func<MidCompiledInstance, bool>) (x => mids.Contains<Type>(x.Type))));
    }

    private void FilterSelectedMids(IEnumerable<MidCompiledInstance> mids)
    {
      foreach (KeyValuePair<int, MidCompiledInstance> keyValuePair in this._templates.Where<KeyValuePair<int, MidCompiledInstance>>((Func<KeyValuePair<int, MidCompiledInstance>, bool>) (x => !mids.Contains<MidCompiledInstance>(x.Value))).ToList<KeyValuePair<int, MidCompiledInstance>>())
        ((ICollection<KeyValuePair<int, MidCompiledInstance>>) this._templates).Remove(keyValuePair);
    }

    private MidCompiledInstance GetMidType(int mid)
    {
      MidCompiledInstance midType;
      if (!this._templates.TryGetValue(mid, out midType))
        throw new NotImplementedException(string.Format("MID {0} was not implemented, please register it!", (object) mid));
      return midType;
    }
  }
}
