﻿
// Type: OpenProtocolInterpreter.ApplicationController.ApplicationControllerMessages
using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.ApplicationController
{
  internal class ApplicationControllerMessages : MessagesTemplate
  {
    public ApplicationControllerMessages()
    {
      this._templates = (IDictionary<int, MidCompiledInstance>) new Dictionary<int, MidCompiledInstance>()
      {
        {
          270,
          new MidCompiledInstance(typeof (Mid0270))
        }
      };
    }

    public ApplicationControllerMessages(IEnumerable<Type> selectedMids)
      : this()
    {
      this.FilterSelectedMids(selectedMids);
    }

    public ApplicationControllerMessages(InterpreterMode mode)
      : this()
    {
      this.FilterSelectedMids(mode);
    }

    public override bool IsAssignableTo(int mid) => mid == 270;
  }
}
