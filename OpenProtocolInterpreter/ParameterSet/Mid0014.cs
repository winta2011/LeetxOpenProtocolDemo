
// Type: OpenProtocolInterpreter.ParameterSet.Mid0014

namespace OpenProtocolInterpreter.ParameterSet
{
  public class Mid0014 : Mid, IParameterSet, IIntegrator
  {
    private const int LAST_REVISION = 1;
    public const int MID = 14;

    public Mid0014()
      : this(new int?(0))
    {
    }

    public Mid0014(int? noAckFlag = 0)
      : base(14, 1, noAckFlag)
    {
    }
  }
}
