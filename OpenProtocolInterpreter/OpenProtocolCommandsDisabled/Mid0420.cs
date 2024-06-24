
// Type: OpenProtocolInterpreter.OpenProtocolCommandsDisabled.Mid0420

namespace OpenProtocolInterpreter.OpenProtocolCommandsDisabled
{
  public class Mid0420 : Mid, IOpenProtocolCommandsDisabled, IIntegrator
  {
    private const int LAST_REVISION = 1;
    public const int MID = 420;

    public Mid0420()
      : this(new int?(0))
    {
    }

    public Mid0420(int? noAckFlag = 0)
      : base(420, 1, noAckFlag)
    {
    }
  }
}
