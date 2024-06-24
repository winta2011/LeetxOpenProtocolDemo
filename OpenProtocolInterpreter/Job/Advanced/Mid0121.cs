
// Type: OpenProtocolInterpreter.Job.Advanced.Mid0121

namespace OpenProtocolInterpreter.Job.Advanced
{
  public class Mid0121 : Mid, IAdvancedJob, IController
  {
    private const int LAST_REVISION = 1;
    public const int MID = 121;

    public Mid0121()
      : this(new int?(0))
    {
    }

    public Mid0121(int? noAckFlag = 0)
      : base(121, 1, noAckFlag)
    {
    }
  }
}
