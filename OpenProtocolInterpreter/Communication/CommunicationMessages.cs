
// Type: OpenProtocolInterpreter.Communication.CommunicationMessages
using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Communication
{
  internal class CommunicationMessages : MessagesTemplate
  {
    public CommunicationMessages()
    {
      this._templates = (IDictionary<int, MidCompiledInstance>) new Dictionary<int, MidCompiledInstance>()
      {
        {
          1,
          new MidCompiledInstance(typeof (Mid0001))
        },
        {
          2,
          new MidCompiledInstance(typeof (Mid0002))
        },
        {
          3,
          new MidCompiledInstance(typeof (Mid0003))
        },
        {
          4,
          new MidCompiledInstance(typeof (Mid0004))
        },
        {
          5,
          new MidCompiledInstance(typeof (Mid0005))
        },
        {
          6,
          new MidCompiledInstance(typeof (Mid0006))
        },
        {
          8,
          new MidCompiledInstance(typeof (Mid0008))
        }
      };
    }

    public CommunicationMessages(IEnumerable<Type> selectedMids)
      : this()
    {
      this.FilterSelectedMids(selectedMids);
    }

    public CommunicationMessages(InterpreterMode mode)
      : this()
    {
      this.FilterSelectedMids(mode);
    }

    public override bool IsAssignableTo(int mid) => mid > 0 && mid < 10;
  }
}
