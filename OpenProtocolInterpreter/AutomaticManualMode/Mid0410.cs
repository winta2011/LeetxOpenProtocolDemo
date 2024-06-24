
// Type: OpenProtocolInterpreter.AutomaticManualMode.Mid0410

namespace OpenProtocolInterpreter.AutomaticManualMode
{
  public class Mid0410 : Mid, IAutomaticManualMode, IIntegrator
  {
    private const int LAST_REVISION = 1;
    public const int MID = 410;

    public Mid0410()
      : base(410, 1)
    {
    }
  }
}
