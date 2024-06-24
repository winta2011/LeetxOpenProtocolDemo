
// Type: OpenProtocolInterpreter.Statistic.StatisticMessages
using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Statistic
{
  internal class StatisticMessages : MessagesTemplate
  {
    public StatisticMessages()
    {
      this._templates = (IDictionary<int, MidCompiledInstance>) new Dictionary<int, MidCompiledInstance>()
      {
        {
          300,
          new MidCompiledInstance(typeof (Mid0300))
        },
        {
          301,
          new MidCompiledInstance(typeof (Mid0301))
        }
      };
    }

    public StatisticMessages(IEnumerable<Type> selectedMids)
      : this()
    {
      this.FilterSelectedMids(selectedMids);
    }

    public StatisticMessages(InterpreterMode mode)
      : this()
    {
      this.FilterSelectedMids(mode);
    }

    public override bool IsAssignableTo(int mid) => mid > 299 && mid < 302;
  }
}
