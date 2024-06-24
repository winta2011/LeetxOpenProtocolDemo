
// Type: OpenProtocolInterpreter.AutomaticManualMode.Mid0400

namespace OpenProtocolInterpreter.AutomaticManualMode
{
  public class Mid0400 : Mid, IAutomaticManualMode, IIntegrator
  {
    private const int LAST_REVISION = 1;
    public const int MID = 400;

    public Mid0400()
      : this(new int?(0))
    {
    }

    public Mid0400(int? noAckFlag = 0)
      : base(400, 1, noAckFlag)
    {
    }
  }
}
