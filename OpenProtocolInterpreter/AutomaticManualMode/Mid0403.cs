
// Type: OpenProtocolInterpreter.AutomaticManualMode.Mid0403

namespace OpenProtocolInterpreter.AutomaticManualMode
{
  public class Mid0403 : Mid, IAutomaticManualMode, IIntegrator
  {
    private const int LAST_REVISION = 1;
    public const int MID = 403;

    public Mid0403()
      : base(403, 1)
    {
    }
  }
}
