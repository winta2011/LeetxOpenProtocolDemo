
// Type: OpenProtocolInterpreter.ParameterSet.Mid0021

namespace OpenProtocolInterpreter.ParameterSet
{
  public class Mid0021 : Mid, IParameterSet, IIntegrator
  {
    private const int LAST_REVISION = 1;
    public const int MID = 21;

    public Mid0021()
      : this(new int?(0))
    {
    }

    public Mid0021(int? noAckFlag = 0)
      : base(21, 1, noAckFlag)
    {
    }
  }
}
