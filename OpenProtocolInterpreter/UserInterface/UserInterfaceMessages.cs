
// Type: OpenProtocolInterpreter.UserInterface.UserInterfaceMessages
using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.UserInterface
{
  internal class UserInterfaceMessages : MessagesTemplate
  {
    public UserInterfaceMessages()
    {
      this._templates = (IDictionary<int, MidCompiledInstance>) new Dictionary<int, MidCompiledInstance>()
      {
        {
          110,
          new MidCompiledInstance(typeof (Mid0110))
        },
        {
          111,
          new MidCompiledInstance(typeof (Mid0111))
        },
        {
          113,
          new MidCompiledInstance(typeof (Mid0113))
        }
      };
    }

    public UserInterfaceMessages(IEnumerable<Type> selectedMids)
      : this()
    {
      this.FilterSelectedMids(selectedMids);
    }

    public UserInterfaceMessages(InterpreterMode mode)
      : this()
    {
      this.FilterSelectedMids(mode);
    }

    public override bool IsAssignableTo(int mid) => mid > 109 && mid < 114;
  }
}
