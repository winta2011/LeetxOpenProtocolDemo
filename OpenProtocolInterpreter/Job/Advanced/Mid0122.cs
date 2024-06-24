
// Type: OpenProtocolInterpreter.Job.Advanced.Mid0122

namespace OpenProtocolInterpreter.Job.Advanced
{
  public class Mid0122 : Mid, IAdvancedJob, IController
  {
    private const int LAST_REVISION = 1;
    public const int MID = 122;

    public Mid0122()
      : this(new int?(0))
    {
    }

    public Mid0122(int? noAckFlag = 0)
      : base(122, 1, noAckFlag)
    {
    }
  }
}
