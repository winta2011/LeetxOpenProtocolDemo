
// Type: OpenProtocolInterpreter.Curve.Mid7408

namespace OpenProtocolInterpreter.Curve
{
  public class Mid7408 : Mid, ICurve, IIntegrator
  {
    private const int LAST_REVISION = 2;
    public const int MID = 7408;

    public Mid7408()
      : this(2, 0)
    {
    }

    public Mid7408(int revision = 2, int noAckFlag = 0)
      : base(7408, revision, noAckFlag==1)
    {
    }
  }
}
