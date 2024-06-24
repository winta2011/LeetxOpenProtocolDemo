
// Type: OpenProtocolInterpreter.MultiSpindle.MultiSpindleMessages
using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.MultiSpindle
{
  internal class MultiSpindleMessages : MessagesTemplate
  {
    public MultiSpindleMessages()
    {
      this._templates = (IDictionary<int, MidCompiledInstance>) new Dictionary<int, MidCompiledInstance>()
      {
        {
          90,
          new MidCompiledInstance(typeof (Mid0090))
        },
        {
          91,
          new MidCompiledInstance(typeof (Mid0091))
        },
        {
          92,
          new MidCompiledInstance(typeof (Mid0092))
        },
        {
          93,
          new MidCompiledInstance(typeof (Mid0093))
        },
        {
          100,
          new MidCompiledInstance(typeof (Mid0100))
        },
        {
          101,
          new MidCompiledInstance(typeof (Mid0101))
        },
        {
          102,
          new MidCompiledInstance(typeof (Mid0102))
        },
        {
          103,
          new MidCompiledInstance(typeof (Mid0103))
        }
      };
    }

    public MultiSpindleMessages(IEnumerable<Type> selectedMids)
      : this()
    {
      this.FilterSelectedMids(selectedMids);
    }

    public MultiSpindleMessages(InterpreterMode mode)
      : this()
    {
      this.FilterSelectedMids(mode);
    }

    public override bool IsAssignableTo(int mid) => mid > 89 && mid < 104;
  }
}
