
// Type: OpenProtocolInterpreter.MotorTuning.MotorTuningMessages
using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.MotorTuning
{
  internal class MotorTuningMessages : MessagesTemplate
  {
    public MotorTuningMessages()
    {
      this._templates = (IDictionary<int, MidCompiledInstance>) new Dictionary<int, MidCompiledInstance>()
      {
        {
          500,
          new MidCompiledInstance(typeof (Mid0500))
        },
        {
          501,
          new MidCompiledInstance(typeof (Mid0501))
        },
        {
          502,
          new MidCompiledInstance(typeof (Mid0502))
        },
        {
          503,
          new MidCompiledInstance(typeof (Mid0503))
        },
        {
          504,
          new MidCompiledInstance(typeof (Mid0504))
        }
      };
    }

    public MotorTuningMessages(IEnumerable<Type> selectedMids)
      : this()
    {
      this.FilterSelectedMids(selectedMids);
    }

    public MotorTuningMessages(InterpreterMode mode)
      : this()
    {
      this.FilterSelectedMids(mode);
    }

    public override bool IsAssignableTo(int mid) => mid > 499 && mid < 505;
  }
}
