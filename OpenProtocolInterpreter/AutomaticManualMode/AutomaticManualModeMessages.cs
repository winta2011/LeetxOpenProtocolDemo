
// Type: OpenProtocolInterpreter.AutomaticManualMode.AutomaticManualModeMessages
using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.AutomaticManualMode
{
  internal class AutomaticManualModeMessages : MessagesTemplate
  {
    public AutomaticManualModeMessages()
    {
      this._templates = (IDictionary<int, MidCompiledInstance>) new Dictionary<int, MidCompiledInstance>()
      {
        {
          400,
          new MidCompiledInstance(typeof (Mid0400))
        },
        {
          401,
          new MidCompiledInstance(typeof (Mid0401))
        },
        {
          402,
          new MidCompiledInstance(typeof (Mid0402))
        },
        {
          403,
          new MidCompiledInstance(typeof (Mid0403))
        },
        {
          410,
          new MidCompiledInstance(typeof (Mid0410))
        },
        {
          411,
          new MidCompiledInstance(typeof (Mid0411))
        }
      };
    }

    public AutomaticManualModeMessages(IEnumerable<Type> selectedMids)
      : this()
    {
      this.FilterSelectedMids(selectedMids);
    }

    public AutomaticManualModeMessages(InterpreterMode mode)
      : this()
    {
      this.FilterSelectedMids(mode);
    }

    public override bool IsAssignableTo(int mid) => mid > 399 && mid < 412;
  }
}
