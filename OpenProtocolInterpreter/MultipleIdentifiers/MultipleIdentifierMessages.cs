
// Type: OpenProtocolInterpreter.MultipleIdentifiers.MultipleIdentifierMessages
using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.MultipleIdentifiers
{
  internal class MultipleIdentifierMessages : MessagesTemplate
  {
    public MultipleIdentifierMessages()
    {
      this._templates = (IDictionary<int, MidCompiledInstance>) new Dictionary<int, MidCompiledInstance>()
      {
        {
          150,
          new MidCompiledInstance(typeof (Mid0150))
        },
        {
          151,
          new MidCompiledInstance(typeof (Mid0151))
        },
        {
          152,
          new MidCompiledInstance(typeof (Mid0152))
        },
        {
          153,
          new MidCompiledInstance(typeof (Mid0153))
        },
        {
          154,
          new MidCompiledInstance(typeof (Mid0154))
        },
        {
          155,
          new MidCompiledInstance(typeof (Mid0155))
        },
        {
          156,
          new MidCompiledInstance(typeof (Mid0156))
        },
        {
          157,
          new MidCompiledInstance(typeof (Mid0157))
        }
      };
    }

    public MultipleIdentifierMessages(IEnumerable<Type> selectedMids)
      : this()
    {
      this.FilterSelectedMids(selectedMids);
    }

    public MultipleIdentifierMessages(InterpreterMode mode)
      : this()
    {
      this.FilterSelectedMids(mode);
    }

    public override bool IsAssignableTo(int mid) => mid > 149 && mid < 158;
  }
}
