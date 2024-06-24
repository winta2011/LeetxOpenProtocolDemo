
// Type: OpenProtocolInterpreter.PowerMACS.PowerMACSMessages
using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.PowerMACS
{
  internal class PowerMACSMessages : MessagesTemplate
  {
    public PowerMACSMessages()
    {
      this._templates = (IDictionary<int, MidCompiledInstance>) new Dictionary<int, MidCompiledInstance>()
      {
        {
          105,
          new MidCompiledInstance(typeof (Mid0105))
        },
        {
          106,
          new MidCompiledInstance(typeof (Mid0106))
        },
        {
          107,
          new MidCompiledInstance(typeof (Mid0107))
        },
        {
          108,
          new MidCompiledInstance(typeof (Mid0108))
        },
        {
          109,
          new MidCompiledInstance(typeof (Mid0109))
        }
      };
    }

    public PowerMACSMessages(IEnumerable<Type> selectedMids)
      : this()
    {
      this.FilterSelectedMids(selectedMids);
    }

    public PowerMACSMessages(InterpreterMode mode)
      : this()
    {
      this.FilterSelectedMids(mode);
    }

    public override bool IsAssignableTo(int mid) => mid > 104 && mid < 110;
  }
}
