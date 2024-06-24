
// Type: OpenProtocolInterpreter.Alarm.Mid0073

namespace OpenProtocolInterpreter.Alarm
{
  public class Mid0073 : Mid, IAlarm, IIntegrator
  {
    private const int LAST_REVISION = 2;
    public const int MID = 73;

    public Mid0073()
      : this(2)
    {
    }

    public Mid0073(int revision = 2)
      : base(73, revision)
    {
    }
  }
}
