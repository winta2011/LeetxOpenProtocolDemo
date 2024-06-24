
// Type: OpenProtocolInterpreter.PowerMACS.Mid0109

namespace OpenProtocolInterpreter.PowerMACS
{
  public class Mid0109 : Mid, IPowerMACS, IIntegrator
  {
    private const int LAST_REVISION = 1;
    public const int MID = 109;

    public Mid0109()
      : this(1)
    {
    }

    public Mid0109(int revision = 1)
      : base(109, revision)
    {
    }
  }
}
