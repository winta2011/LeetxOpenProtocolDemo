
// Type: OpenProtocolInterpreter.Vin.Mid0054

namespace OpenProtocolInterpreter.Vin
{
  public class Mid0054 : Mid, IVin, IIntegrator
  {
    private const int LAST_REVISION = 1;
    public const int MID = 54;

    public Mid0054()
      : this(1)
    {
    }

    public Mid0054(int revision = 1)
      : base(54, revision)
    {
    }
  }
}
