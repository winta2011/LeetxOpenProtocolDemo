
// Type: OpenProtocolInterpreter.Vin.VinMessages
using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Vin
{
  internal class VinMessages : MessagesTemplate
  {
    public VinMessages()
    {
      this._templates = (IDictionary<int, MidCompiledInstance>) new Dictionary<int, MidCompiledInstance>()
      {
        {
          50,
          new MidCompiledInstance(typeof (Mid0050))
        },
        {
          51,
          new MidCompiledInstance(typeof (Mid0051))
        },
        {
          52,
          new MidCompiledInstance(typeof (Mid0052))
        },
        {
          53,
          new MidCompiledInstance(typeof (Mid0053))
        },
        {
          54,
          new MidCompiledInstance(typeof (Mid0054))
        }
      };
    }

    public VinMessages(IEnumerable<Type> selectedMids)
      : this()
    {
      this.FilterSelectedMids(selectedMids);
    }

    public VinMessages(InterpreterMode mode)
      : this()
    {
      this.FilterSelectedMids(mode);
    }

    public override bool IsAssignableTo(int mid) => mid > 49 && mid < 55;
  }
}
