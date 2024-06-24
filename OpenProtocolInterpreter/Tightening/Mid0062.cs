
// Type: OpenProtocolInterpreter.Tightening.Mid0062

namespace OpenProtocolInterpreter.Tightening
{
  public class Mid0062 : Mid, ITightening, IIntegrator
  {
    private const int LAST_REVISION = 6;
    public const int MID = 62;

    public Mid0062()
      : this(6)
    {
    }

    public Mid0062(int revision = 6)
      : base(62, revision)
    {
    }
  }
}
