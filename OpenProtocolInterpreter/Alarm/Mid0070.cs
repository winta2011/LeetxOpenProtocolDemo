
// Type: OpenProtocolInterpreter.Alarm.Mid0070

namespace OpenProtocolInterpreter.Alarm
{
  public class Mid0070 : Mid, IAlarm, IIntegrator
  {
    private const int LAST_REVISION = 2;
    public const int MID = 70;

    public Mid0070()
      : this(2, new int?(0))
    {
    }

    public Mid0070(int revision = 2, int? noAckFlag = 0)
      : base(70, revision, noAckFlag)
    {
    }
  }
}
