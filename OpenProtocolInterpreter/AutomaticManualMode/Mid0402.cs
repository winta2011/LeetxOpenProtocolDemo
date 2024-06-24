
// Type: OpenProtocolInterpreter.AutomaticManualMode.Mid0402

namespace OpenProtocolInterpreter.AutomaticManualMode
{
  public class Mid0402 : Mid, IAutomaticManualMode, IIntegrator
  {
    private const int LAST_REVISION = 1;
    public const int MID = 402;

    public Mid0402()
      : base(402, 1)
    {
    }
  }
}
