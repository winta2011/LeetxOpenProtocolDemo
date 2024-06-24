
// Type: OpenProtocolInterpreter.Job.Mid0034

namespace OpenProtocolInterpreter.Job
{
  public class Mid0034 : Mid, IJob, IIntegrator
  {
    private const int LAST_REVISION = 4;
    public const int MID = 34;

    public Mid0034()
      : this(4, new int?(0))
    {
    }

    public Mid0034(int revision = 4, int? noAckFlag = 0)
      : base(34, revision, noAckFlag)
    {
    }
  }
}
