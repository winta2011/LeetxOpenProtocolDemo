
// Type: OpenProtocolInterpreter.MultiSpindle.Mid0090

namespace OpenProtocolInterpreter.MultiSpindle
{
  public class Mid0090 : Mid, IMultiSpindle, IIntegrator
  {
    private const int LAST_REVISION = 1;
    public const int MID = 90;

    public Mid0090()
      : this(new int?(0))
    {
    }

    public Mid0090(int? noAckFlag = 0)
      : base(90, 1, noAckFlag)
    {
    }
  }
}
