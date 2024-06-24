
// Type: OpenProtocolInterpreter.Vin.Mid0053

namespace OpenProtocolInterpreter.Vin
{
  public class Mid0053 : Mid, IVin, IIntegrator
  {
    private const int LAST_REVISION = 2;
    public const int MID = 53;

    public Mid0053()
      : this(2)
    {
    }

    public Mid0053(int revision = 2)
      : base(53, revision)
    {
    }
  }
}
