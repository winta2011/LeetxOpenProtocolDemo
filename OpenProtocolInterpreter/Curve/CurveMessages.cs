
// Type: OpenProtocolInterpreter.Curve.CurveMessages
using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Curve
{
  internal class CurveMessages : MessagesTemplate
  {
    public CurveMessages()
    {
      this._templates = (IDictionary<int, MidCompiledInstance>) new Dictionary<int, MidCompiledInstance>()
      {
        {
          7408,
          new MidCompiledInstance(typeof (Mid7408))
        },
        {
          7409,
          new MidCompiledInstance(typeof (Mid7409))
        },
        {
          7410,
          new MidCompiledInstance(typeof (Mid7410))
        },
        {
          7411,
          new MidCompiledInstance(typeof (Mid7411))
        }
      };
    }

    public CurveMessages(IEnumerable<Type> selectedMids)
      : this()
    {
      this.FilterSelectedMids(selectedMids);
    }

    public CurveMessages(InterpreterMode mode)
      : this()
    {
      this.FilterSelectedMids(mode);
    }

    public override bool IsAssignableTo(int mid) => mid >= 7408 && mid <= 7411;
  }
}
