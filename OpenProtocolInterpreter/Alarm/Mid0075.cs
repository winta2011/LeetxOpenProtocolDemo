
// Type: OpenProtocolInterpreter.Alarm.Mid0075

namespace OpenProtocolInterpreter.Alarm
{
  public class Mid0075 : Mid, IAlarm, IIntegrator
  {
    private const int LAST_REVISION = 2;
    public const int MID = 75;

    public Mid0075()
      : this(2)
    {
    }

    public Mid0075(int revision = 2)
      : base(75, revision)
    {
    }
  }
}
