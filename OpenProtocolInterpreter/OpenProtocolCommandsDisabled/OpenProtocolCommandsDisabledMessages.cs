
// Type: OpenProtocolInterpreter.OpenProtocolCommandsDisabled.OpenProtocolCommandsDisabledMessages
using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.OpenProtocolCommandsDisabled
{
  internal class OpenProtocolCommandsDisabledMessages : MessagesTemplate
  {
    public OpenProtocolCommandsDisabledMessages()
    {
      this._templates = (IDictionary<int, MidCompiledInstance>) new Dictionary<int, MidCompiledInstance>()
      {
        {
          420,
          new MidCompiledInstance(typeof (Mid0420))
        },
        {
          421,
          new MidCompiledInstance(typeof (Mid0421))
        },
        {
          422,
          new MidCompiledInstance(typeof (Mid0422))
        },
        {
          423,
          new MidCompiledInstance(typeof (Mid0423))
        }
      };
    }

    public OpenProtocolCommandsDisabledMessages(IEnumerable<Type> selectedMids)
      : this()
    {
      this.FilterSelectedMids(selectedMids);
    }

    public OpenProtocolCommandsDisabledMessages(InterpreterMode mode)
      : this()
    {
      this.FilterSelectedMids(mode);
    }

    public override bool IsAssignableTo(int mid) => mid > 419 && mid < 424;
  }
}
