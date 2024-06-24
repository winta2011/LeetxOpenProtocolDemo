
// Type: OpenProtocolInterpreter.Tightening.Mid0063

namespace OpenProtocolInterpreter.Tightening
{
  public class Mid0063 : Mid, ITightening, IIntegrator
  {
    private const int LAST_REVISION = 6;
    public const int MID = 63;

    public Mid0063()
      : this(6)
    {
    }

    public Mid0063(int revision = 6)
      : base(63, revision)
    {
    }
  }
}
