
// Type: OpenProtocolInterpreter.Job.Mid0030

namespace OpenProtocolInterpreter.Job
{
  public class Mid0030 : Mid, IJob, IIntegrator
  {
    private const int LAST_REVISION = 2;
    public const int MID = 30;

    public Mid0030()
      : this(2)
    {
    }

    public Mid0030(int revision = 2)
      : base(30, revision)
    {
    }
  }
}
