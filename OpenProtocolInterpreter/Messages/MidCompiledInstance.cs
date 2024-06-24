
// Type: OpenProtocolInterpreter.Messages.MidCompiledInstance
using System;
using System.Linq.Expressions;
using System.Reflection;


namespace OpenProtocolInterpreter.Messages
{
  internal class MidCompiledInstance
  {
    public Type Type { get; set; }

    public Func<Mid> CompiledConstructor { get; set; }

    public MidCompiledInstance(Type type)
    {
      this.Type = type;
      this.CompiledConstructor = Expression.Lambda < Func<Mid> >( Expression.New(type.GetConstructor(Type.EmptyTypes))).Compile();
    }
  }
}
