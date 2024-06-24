
// Type: OpenProtocolInterpreter.Job.Advanced.Mid0120

namespace OpenProtocolInterpreter.Job.Advanced
{
  public class Mid0120 : Mid, IAdvancedJob, IIntegrator
  {
    private const int LAST_REVISION = 1;
    public const int MID = 120;

    public Mid0120()
      : this(new int?(0))
    {
    }

    public Mid0120(int? noAckFlag = 0)
      : base(120, 1, noAckFlag)
    {
    }
  }
}
