
// Type: OpenProtocolInterpreter.PLCUserData.PLCUserDataMessages
using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.PLCUserData
{
  internal class PLCUserDataMessages : MessagesTemplate
  {
    public PLCUserDataMessages()
    {
      this._templates = (IDictionary<int, MidCompiledInstance>) new Dictionary<int, MidCompiledInstance>()
      {
        {
          240,
          new MidCompiledInstance(typeof (Mid0240))
        },
        {
          241,
          new MidCompiledInstance(typeof (Mid0241))
        },
        {
          242,
          new MidCompiledInstance(typeof (Mid0242))
        },
        {
          243,
          new MidCompiledInstance(typeof (Mid0243))
        },
        {
          244,
          new MidCompiledInstance(typeof (Mid0244))
        },
        {
          245,
          new MidCompiledInstance(typeof (Mid0245))
        }
      };
    }

    public PLCUserDataMessages(IEnumerable<Type> selectedMids)
      : this()
    {
      this.FilterSelectedMids(selectedMids);
    }

    public PLCUserDataMessages(InterpreterMode mode)
      : this()
    {
      this.FilterSelectedMids(mode);
    }

    public override bool IsAssignableTo(int mid) => mid > 239 && mid < 246;
  }
}
