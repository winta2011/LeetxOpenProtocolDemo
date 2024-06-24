
// Type: OpenProtocolInterpreter.CustomMessages
using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter
{
  internal class CustomMessages : MessagesTemplate
  {
    public CustomMessages(IDictionary<int, Type> midTypes)
    {
      foreach (KeyValuePair<int, Type> midType in (IEnumerable<KeyValuePair<int, Type>>) midTypes)
        this._templates.Add(midType.Key, new MidCompiledInstance(midType.Value));
    }

    public override bool IsAssignableTo(int mid) => this._templates.ContainsKey(mid);
  }
}
