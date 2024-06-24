
// Type: OpenProtocolInterpreter.Curve.Mid7411

namespace OpenProtocolInterpreter.Curve
{
  public class Mid7411 : Mid, ICurve, IIntegrator
  {
    private const int LAST_REVISION = 1;
    public const int MID = 7411;

    public Mid7411()
      : this(1)
    {
    }

    public Mid7411(int revision = 1)
      : base(7411, revision)
    {
    }
  }
}
