
// Type: OpenProtocolInterpreter.ApplicationSelector.Mid0250

namespace OpenProtocolInterpreter.ApplicationSelector
{
  public class Mid0250 : Mid, IApplicationSelector, IIntegrator
  {
    private const int LAST_REVISION = 1;
    public const int MID = 250;

    public Mid0250()
      : this(new int?(0))
    {
    }

    public Mid0250(int? noAckFlag = 0)
      : base(250, 1, noAckFlag)
    {
    }
  }
}
