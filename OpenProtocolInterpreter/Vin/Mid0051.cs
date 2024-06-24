
// Type: OpenProtocolInterpreter.Vin.Mid0051

namespace OpenProtocolInterpreter.Vin
{
  public class Mid0051 : Mid, IVin, IIntegrator
  {
    private const int LAST_REVISION = 2;
    public const int MID = 51;

    public Mid0051()
      : this(2, new int?(0))
    {
    }

    public Mid0051(int revision = 2, int? noAckFlag = 0)
      : base(51, revision, noAckFlag)
    {
    }
  }
}
