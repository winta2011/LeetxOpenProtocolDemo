
// Type: OpenProtocolInterpreter.Job.Advanced.Mid0123

namespace OpenProtocolInterpreter.Job.Advanced
{
  public class Mid0123 : Mid, IAdvancedJob, IController
  {
    private const int LAST_REVISION = 1;
    public const int MID = 123;

    public Mid0123()
      : this(new int?(0))
    {
    }

    public Mid0123(int? noAckFlag = 0)
      : base(123, 1, noAckFlag)
    {
    }
  }
}
