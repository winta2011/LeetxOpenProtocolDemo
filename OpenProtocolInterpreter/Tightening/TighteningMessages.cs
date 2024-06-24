
// Type: OpenProtocolInterpreter.Tightening.TighteningMessages
using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Tightening
{
  internal class TighteningMessages : MessagesTemplate
  {
    public TighteningMessages()
    {
      this._templates = (IDictionary<int, MidCompiledInstance>) new Dictionary<int, MidCompiledInstance>()
      {
        {
          60,
          new MidCompiledInstance(typeof (Mid0060))
        },
        {
          61,
          new MidCompiledInstance(typeof (Mid0061))
        },
        {
          62,
          new MidCompiledInstance(typeof (Mid0062))
        },
        {
          63,
          new MidCompiledInstance(typeof (Mid0063))
        },
        {
          64,
          new MidCompiledInstance(typeof (Mid0064))
        },
        {
          65,
          new MidCompiledInstance(typeof (Mid0065))
        }
      };
    }

    public TighteningMessages(IEnumerable<Type> selectedMids)
      : this()
    {
      this.FilterSelectedMids(selectedMids);
    }

    public TighteningMessages(InterpreterMode mode)
      : this()
    {
      this.FilterSelectedMids(mode);
    }

    public override bool IsAssignableTo(int mid) => mid > 59 && mid < 66;
  }
}
