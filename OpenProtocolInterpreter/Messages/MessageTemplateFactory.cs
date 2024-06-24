
// Type: OpenProtocolInterpreter.Messages.MessageTemplateFactory
using System;
using System.Collections.Generic;
using System.Linq;


namespace OpenProtocolInterpreter.Messages
{
  internal static class MessageTemplateFactory
  {
    public static IDictionary<int, Type> Except(
      this IDictionary<int, Type> defaultMids,
      IEnumerable<Type> selectedMids)
    {
      if (!selectedMids.Any<Type>())
        return defaultMids;
      foreach (Type type in defaultMids.Values.Except<Type>(selectedMids))
      {
        Type unused = type;
        ((ICollection<KeyValuePair<int, Type>>) defaultMids).Remove(defaultMids.First<KeyValuePair<int, Type>>((Func<KeyValuePair<int, Type>, bool>) (x => x.Value == unused)));
      }
      return defaultMids;
    }
  }
}
