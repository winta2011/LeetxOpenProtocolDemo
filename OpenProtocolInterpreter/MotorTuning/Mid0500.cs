
// Type: OpenProtocolInterpreter.MotorTuning.Mid0500

namespace OpenProtocolInterpreter.MotorTuning
{
  public class Mid0500 : Mid, IMotorTuning, IIntegrator
  {
    private const int LAST_REVISION = 1;
    public const int MID = 500;

    public Mid0500()
      : base(500, 1)
    {
    }
  }
}
