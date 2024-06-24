
// Type: OpenProtocolInterpreter.MotorTuning.Mid0502

namespace OpenProtocolInterpreter.MotorTuning
{
  public class Mid0502 : Mid, IMotorTuning, IIntegrator
  {
    private const int LAST_REVISION = 1;
    public const int MID = 502;

    public Mid0502()
      : base(502, 1)
    {
    }
  }
}
