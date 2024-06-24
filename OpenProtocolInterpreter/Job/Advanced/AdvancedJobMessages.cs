
// Type: OpenProtocolInterpreter.Job.Advanced.AdvancedJobMessages
using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Job.Advanced
{
  internal class AdvancedJobMessages : MessagesTemplate
  {
    public AdvancedJobMessages()
    {
      this._templates = (IDictionary<int, MidCompiledInstance>) new Dictionary<int, MidCompiledInstance>()
      {
        {
          120,
          new MidCompiledInstance(typeof (Mid0120))
        },
        {
          121,
          new MidCompiledInstance(typeof (Mid0121))
        },
        {
          122,
          new MidCompiledInstance(typeof (Mid0122))
        },
        {
          123,
          new MidCompiledInstance(typeof (Mid0123))
        },
        {
          124,
          new MidCompiledInstance(typeof (Mid0124))
        },
        {
          125,
          new MidCompiledInstance(typeof (Mid0125))
        },
        {
          126,
          new MidCompiledInstance(typeof (Mid0126))
        },
        {
          (int) sbyte.MaxValue,
          new MidCompiledInstance(typeof (Mid0127))
        },
        {
          128,
          new MidCompiledInstance(typeof (Mid0128))
        },
        {
          129,
          new MidCompiledInstance(typeof (Mid0129))
        },
        {
          130,
          new MidCompiledInstance(typeof (Mid0130))
        },
        {
          131,
          new MidCompiledInstance(typeof (Mid0131))
        },
        {
          132,
          new MidCompiledInstance(typeof (Mid0132))
        },
        {
          133,
          new MidCompiledInstance(typeof (Mid0133))
        },
        {
          140,
          new MidCompiledInstance(typeof (Mid0140))
        }
      };
    }

    public AdvancedJobMessages(IEnumerable<Type> selectedMids)
      : this()
    {
      this.FilterSelectedMids(selectedMids);
    }

    public AdvancedJobMessages(InterpreterMode mode)
      : this()
    {
      this.FilterSelectedMids(mode);
    }

    public override bool IsAssignableTo(int mid) => mid > 119 && mid < 141;
  }
}
