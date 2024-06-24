
// Type: OpenProtocolInterpreter.Job.JobMessages
using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Job
{
  internal class JobMessages : MessagesTemplate
  {
    public JobMessages()
    {
      this._templates = (IDictionary<int, MidCompiledInstance>) new Dictionary<int, MidCompiledInstance>()
      {
        {
          30,
          new MidCompiledInstance(typeof (Mid0030))
        },
        {
          31,
          new MidCompiledInstance(typeof (Mid0031))
        },
        {
          32,
          new MidCompiledInstance(typeof (Mid0032))
        },
        {
          33,
          new MidCompiledInstance(typeof (Mid0033))
        },
        {
          34,
          new MidCompiledInstance(typeof (Mid0034))
        },
        {
          35,
          new MidCompiledInstance(typeof (Mid0035))
        },
        {
          36,
          new MidCompiledInstance(typeof (Mid0036))
        },
        {
          37,
          new MidCompiledInstance(typeof (Mid0037))
        },
        {
          38,
          new MidCompiledInstance(typeof (Mid0038))
        },
        {
          39,
          new MidCompiledInstance(typeof (Mid0039))
        }
      };
    }

    public JobMessages(IEnumerable<Type> selectedMids)
      : this()
    {
      this.FilterSelectedMids(selectedMids);
    }

    public JobMessages(InterpreterMode mode)
      : this()
    {
      this.FilterSelectedMids(mode);
    }

    public override bool IsAssignableTo(int mid) => mid > 29 && mid < 40;
  }
}
