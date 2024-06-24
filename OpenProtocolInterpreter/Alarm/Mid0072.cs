
// Type: OpenProtocolInterpreter.Alarm.Mid0072

namespace OpenProtocolInterpreter.Alarm
{
  public class Mid0072 : Mid, IAlarm, IIntegrator
  {
    private const int LAST_REVISION = 2;
    public const int MID = 72;

    public Mid0072()
      : this(2)
    {
    }

    public Mid0072(int revision = 2)
      : base(72, revision)
    {
    }
  }
}
