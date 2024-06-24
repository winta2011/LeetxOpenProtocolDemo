
// Type: OpenProtocolInterpreter.Curve.Mid7409

namespace OpenProtocolInterpreter.Curve
{
  public class Mid7409 : Mid, ICurve, IIntegrator
  {
    private const int LAST_REVISION = 1;
    public const int MID = 7409;

    public Mid7409()
      : this(1)
    {
    }

    public Mid7409(int revision = 1)
      : base(7409, revision)
    {
    }
  }
}
