//
// Type: OpenProtocolInterpreter.ParameterSet.ParameterSetMessages
using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.ParameterSet
{
  internal class ParameterSetMessages : MessagesTemplate
  {
    public ParameterSetMessages()
    {
      this._templates = (IDictionary<int, MidCompiledInstance>) new Dictionary<int, MidCompiledInstance>()
      {
        {
          10,
          new MidCompiledInstance(typeof (Mid0010))
        },
        {
          11,
          new MidCompiledInstance(typeof (Mid0011))
        },
        {
          12,
          new MidCompiledInstance(typeof (Mid0012))
        },
        {
          13,
          new MidCompiledInstance(typeof (Mid0013))
        },
        {
          14,
          new MidCompiledInstance(typeof (Mid0014))
        },
        {
          15,
          new MidCompiledInstance(typeof (Mid0015))
        },
        {
          16,
          new MidCompiledInstance(typeof (Mid0016))
        },
        {
          17,
          new MidCompiledInstance(typeof (Mid0017))
        },
        {
          18,
          new MidCompiledInstance(typeof (Mid0018))
        },
        {
          19,
          new MidCompiledInstance(typeof (Mid0019))
        },
        {
          20,
          new MidCompiledInstance(typeof (Mid0020))
        },
        {
          21,
          new MidCompiledInstance(typeof (Mid0021))
        },
        {
          22,
          new MidCompiledInstance(typeof (Mid0022))
        },
        {
          23,
          new MidCompiledInstance(typeof (Mid0023))
        },
        {
          24,
          new MidCompiledInstance(typeof (Mid0024))
        },
        {
          2504,
          new MidCompiledInstance(typeof (Mid2504))
        }
      };
    }

    public ParameterSetMessages(IEnumerable<Type> selectedMids)
      : this()
    {
      this.FilterSelectedMids(selectedMids);
    }

    public ParameterSetMessages(InterpreterMode mode)
      : this()
    {
      this.FilterSelectedMids(mode);
    }

    public override bool IsAssignableTo(int mid)
    {
      if (mid > 9 && mid < 26)
        return true;
      return mid > 2499 && mid < 2506;
    }
  }
}
