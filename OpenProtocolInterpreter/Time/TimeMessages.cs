
// Type: OpenProtocolInterpreter.Time.TimeMessages
using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Time
{
  internal class TimeMessages : MessagesTemplate
  {
    public TimeMessages()
    {
      this._templates = (IDictionary<int, MidCompiledInstance>) new Dictionary<int, MidCompiledInstance>()
      {
        {
          80,
          new MidCompiledInstance(typeof (Mid0080))
        },
        {
          81,
          new MidCompiledInstance(typeof (Mid0081))
        },
        {
          82,
          new MidCompiledInstance(typeof (Mid0082))
        }
      };
    }

    public TimeMessages(IEnumerable<Type> selectedMids)
      : this()
    {
      this.FilterSelectedMids(selectedMids);
    }

    public TimeMessages(InterpreterMode mode)
      : this()
    {
      this.FilterSelectedMids(mode);
    }

    public override bool IsAssignableTo(int mid) => mid > 79 && mid < 83;
  }
}
