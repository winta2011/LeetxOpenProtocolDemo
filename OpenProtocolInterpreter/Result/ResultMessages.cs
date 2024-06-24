
// Type: OpenProtocolInterpreter.Result.ResultMessages
using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Result
{
  internal class ResultMessages : MessagesTemplate
  {
    public ResultMessages()
    {
      this._templates = (IDictionary<int, MidCompiledInstance>) new Dictionary<int, MidCompiledInstance>()
      {
        {
          1201,
          new MidCompiledInstance(typeof (Mid1201))
        },
        {
          1202,
          new MidCompiledInstance(typeof (Mid1202))
        },
        {
          1203,
          new MidCompiledInstance(typeof (Mid1203))
        }
      };
    }

    public ResultMessages(IEnumerable<Type> selectedMids)
      : this()
    {
      this.FilterSelectedMids(selectedMids);
    }

    public ResultMessages(InterpreterMode mode)
      : this()
    {
      this.FilterSelectedMids(mode);
    }

    public override bool IsAssignableTo(int mid) => mid > 1200 && mid < 1204;
  }
}
