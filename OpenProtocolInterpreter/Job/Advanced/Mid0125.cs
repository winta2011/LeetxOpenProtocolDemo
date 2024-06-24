
// Type: OpenProtocolInterpreter.Job.Advanced.Mid0125

namespace OpenProtocolInterpreter.Job.Advanced
{
  public class Mid0125 : Mid, IAdvancedJob, IIntegrator
  {
    private const int LAST_REVISION = 1;
    public const int MID = 125;

    public Mid0125()
      : this(new int?(0))
    {
    }

    public Mid0125(int? noAckFlag = 0)
      : base(125, 1, noAckFlag)
    {
    }
  }
}
