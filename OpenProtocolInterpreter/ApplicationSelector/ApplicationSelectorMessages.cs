
// Type: OpenProtocolInterpreter.ApplicationSelector.ApplicationSelectorMessages
using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.ApplicationSelector
{
  internal class ApplicationSelectorMessages : MessagesTemplate
  {
    public ApplicationSelectorMessages()
    {
      this._templates = (IDictionary<int, MidCompiledInstance>) new Dictionary<int, MidCompiledInstance>()
      {
        {
          250,
          new MidCompiledInstance(typeof (Mid0250))
        },
        {
          251,
          new MidCompiledInstance(typeof (Mid0251))
        },
        {
          252,
          new MidCompiledInstance(typeof (Mid0252))
        },
        {
          253,
          new MidCompiledInstance(typeof (Mid0253))
        },
        {
          254,
          new MidCompiledInstance(typeof (Mid0254))
        },
        {
          (int) byte.MaxValue,
          new MidCompiledInstance(typeof (Mid0255))
        }
      };
    }

    public ApplicationSelectorMessages(IEnumerable<Type> selectedMids)
      : this()
    {
      this.FilterSelectedMids(selectedMids);
    }

    public ApplicationSelectorMessages(InterpreterMode mode)
      : this()
    {
      this.FilterSelectedMids(mode);
    }

    public override bool IsAssignableTo(int mid) => mid > 249 && mid < 256;
  }
}
