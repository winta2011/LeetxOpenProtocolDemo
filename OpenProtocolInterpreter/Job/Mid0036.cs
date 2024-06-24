
// Type: OpenProtocolInterpreter.Job.Mid0036

namespace OpenProtocolInterpreter.Job
{
  public class Mid0036 : Mid, IJob, IIntegrator
  {
    private const int LAST_REVISION = 4;
    public const int MID = 36;

    public Mid0036()
      : this(4)
    {
    }

    public Mid0036(int revision = 4)
      : base(36, revision)
    {
    }
  }
}
