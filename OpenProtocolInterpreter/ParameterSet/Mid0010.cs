
// Type: OpenProtocolInterpreter.ParameterSet.Mid0010

namespace OpenProtocolInterpreter.ParameterSet
{
  public class Mid0010 : Mid, IParameterSet, IIntegrator
  {
    private const int LAST_REVISION = 3;
    public const int MID = 10;

    public Mid0010()
      : this(3)
    {
    }

    public Mid0010(int revision = 3)
      : base(10, revision)
    {
    }
  }
}
