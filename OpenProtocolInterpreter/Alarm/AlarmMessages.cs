
// Type: OpenProtocolInterpreter.Alarm.AlarmMessages
using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Alarm
{
  internal class AlarmMessages : MessagesTemplate
  {
    public AlarmMessages()
    {
      this._templates = (IDictionary<int, MidCompiledInstance>) new Dictionary<int, MidCompiledInstance>()
      {
        {
          70,
          new MidCompiledInstance(typeof (Mid0070))
        },
        {
          71,
          new MidCompiledInstance(typeof (Mid0071))
        },
        {
          72,
          new MidCompiledInstance(typeof (Mid0072))
        },
        {
          73,
          new MidCompiledInstance(typeof (Mid0073))
        },
        {
          74,
          new MidCompiledInstance(typeof (Mid0074))
        },
        {
          75,
          new MidCompiledInstance(typeof (Mid0075))
        },
        {
          76,
          new MidCompiledInstance(typeof (Mid0076))
        },
        {
          77,
          new MidCompiledInstance(typeof (Mid0077))
        },
        {
          78,
          new MidCompiledInstance(typeof (Mid0078))
        }
      };
    }

    public AlarmMessages(IEnumerable<Type> selectedMids)
      : this()
    {
      this.FilterSelectedMids(selectedMids);
    }

    public AlarmMessages(InterpreterMode mode)
      : this()
    {
      this.FilterSelectedMids(mode);
    }

    public override bool IsAssignableTo(int mid) => mid > 69 && mid < 79;
  }
}
