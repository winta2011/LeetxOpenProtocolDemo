
// Type: OpenProtocolInterpreter.ApplicationToolLocationSystem.ApplicationToolLocationSystemMessages
using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.ApplicationToolLocationSystem
{
  internal class ApplicationToolLocationSystemMessages : MessagesTemplate
  {
    public ApplicationToolLocationSystemMessages()
    {
      this._templates = (IDictionary<int, MidCompiledInstance>) new Dictionary<int, MidCompiledInstance>()
      {
        {
          260,
          new MidCompiledInstance(typeof (Mid0260))
        },
        {
          261,
          new MidCompiledInstance(typeof (Mid0261))
        },
        {
          262,
          new MidCompiledInstance(typeof (Mid0262))
        },
        {
          263,
          new MidCompiledInstance(typeof (Mid0263))
        },
        {
          264,
          new MidCompiledInstance(typeof (Mid0264))
        },
        {
          265,
          new MidCompiledInstance(typeof (Mid0265))
        }
      };
    }

    public ApplicationToolLocationSystemMessages(IEnumerable<Type> selectedMids)
      : this()
    {
      this.FilterSelectedMids(selectedMids);
    }

    public ApplicationToolLocationSystemMessages(InterpreterMode mode)
      : this()
    {
      this.FilterSelectedMids(mode);
    }

    public override bool IsAssignableTo(int mid) => mid > 259 && mid < 266;
  }
}
