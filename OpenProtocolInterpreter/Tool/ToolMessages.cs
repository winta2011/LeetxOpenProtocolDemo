
// Type: OpenProtocolInterpreter.Tool.ToolMessages
using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Tool
{
  internal class ToolMessages : MessagesTemplate
  {
    public ToolMessages()
    {
      this._templates = (IDictionary<int, MidCompiledInstance>) new Dictionary<int, MidCompiledInstance>()
      {
        {
          40,
          new MidCompiledInstance(typeof (Mid0040))
        },
        {
          41,
          new MidCompiledInstance(typeof (Mid0041))
        },
        {
          42,
          new MidCompiledInstance(typeof (Mid0042))
        },
        {
          43,
          new MidCompiledInstance(typeof (Mid0043))
        },
        {
          44,
          new MidCompiledInstance(typeof (Mid0044))
        },
        {
          45,
          new MidCompiledInstance(typeof (Mid0045))
        },
        {
          46,
          new MidCompiledInstance(typeof (Mid0046))
        },
        {
          47,
          new MidCompiledInstance(typeof (Mid0047))
        },
        {
          48,
          new MidCompiledInstance(typeof (Mid0048))
        }
      };
    }

    public ToolMessages(IEnumerable<Type> selectedMids)
      : this()
    {
      this.FilterSelectedMids(selectedMids);
    }

    public ToolMessages(InterpreterMode mode)
      : this()
    {
      this.FilterSelectedMids(mode);
    }

    public override bool IsAssignableTo(int mid) => mid > 39 && mid < 49;
  }
}
