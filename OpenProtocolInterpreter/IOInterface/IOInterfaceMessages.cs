
// Type: OpenProtocolInterpreter.IOInterface.IOInterfaceMessages
using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.IOInterface
{
  internal class IOInterfaceMessages : MessagesTemplate
  {
    public IOInterfaceMessages()
    {
      this._templates = (IDictionary<int, MidCompiledInstance>) new Dictionary<int, MidCompiledInstance>()
      {
        {
          200,
          new MidCompiledInstance(typeof (Mid0200))
        },
        {
          210,
          new MidCompiledInstance(typeof (Mid0210))
        },
        {
          211,
          new MidCompiledInstance(typeof (Mid0211))
        },
        {
          212,
          new MidCompiledInstance(typeof (Mid0212))
        },
        {
          213,
          new MidCompiledInstance(typeof (Mid0213))
        },
        {
          214,
          new MidCompiledInstance(typeof (Mid0214))
        },
        {
          215,
          new MidCompiledInstance(typeof (Mid0215))
        },
        {
          216,
          new MidCompiledInstance(typeof (Mid0216))
        },
        {
          217,
          new MidCompiledInstance(typeof (Mid0217))
        },
        {
          218,
          new MidCompiledInstance(typeof (Mid0218))
        },
        {
          219,
          new MidCompiledInstance(typeof (Mid0219))
        },
        {
          220,
          new MidCompiledInstance(typeof (Mid0220))
        },
        {
          221,
          new MidCompiledInstance(typeof (Mid0221))
        },
        {
          222,
          new MidCompiledInstance(typeof (Mid0222))
        },
        {
          223,
          new MidCompiledInstance(typeof (Mid0223))
        },
        {
          224,
          new MidCompiledInstance(typeof (Mid0224))
        },
        {
          225,
          new MidCompiledInstance(typeof (Mid0225))
        }
      };
    }

    public IOInterfaceMessages(IEnumerable<Type> selectedMids)
      : this()
    {
      this.FilterSelectedMids(selectedMids);
    }

    public IOInterfaceMessages(InterpreterMode mode)
      : this()
    {
      this.FilterSelectedMids(mode);
    }

    public override bool IsAssignableTo(int mid) => mid > 199 && mid < 226;
  }
}
