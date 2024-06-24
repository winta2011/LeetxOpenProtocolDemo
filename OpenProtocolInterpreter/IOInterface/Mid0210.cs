
// Type: OpenProtocolInterpreter.IOInterface.Mid0210

namespace OpenProtocolInterpreter.IOInterface
{
  public class Mid0210 : Mid, IIOInterface, IIntegrator
  {
    private const int LAST_REVISION = 1;
    public const int MID = 210;

    public Mid0210()
      : this(new int?(0))
    {
    }

    public Mid0210(int? noAckFlag = 0)
      : base(210, 1, noAckFlag)
    {
    }
  }
}
