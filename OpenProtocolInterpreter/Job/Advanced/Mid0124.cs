
// Type: OpenProtocolInterpreter.Job.Advanced.Mid0124

namespace OpenProtocolInterpreter.Job.Advanced
{
  public class Mid0124 : Mid, IAdvancedJob, IController
  {
    private const int LAST_REVISION = 1;
    public const int MID = 124;

    public Mid0124()
      : this(new int?(0))
    {
    }

    public Mid0124(int? noAckFlag = 0)
      : base(124, 1, noAckFlag)
    {
    }
  }
}
