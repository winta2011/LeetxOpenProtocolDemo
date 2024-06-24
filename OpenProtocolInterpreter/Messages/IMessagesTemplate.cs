
// Type: OpenProtocolInterpreter.Messages.IMessagesTemplate
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Messages
{
  internal interface IMessagesTemplate
  {
    void AddOrUpdateTemplate(IDictionary<int, Type> types);

    Mid ProcessPackage(int mid, string package);

    Mid ProcessPackage(int mid, byte[] package);

    bool IsAssignableTo(int mid);
  }
}
