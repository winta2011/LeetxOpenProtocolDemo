
// Type: OpenProtocolInterpreter.ApplicationToolLocationSystem.Mid0261

namespace OpenProtocolInterpreter.ApplicationToolLocationSystem
{
  public class Mid0261 : Mid, IApplicationToolLocationSystem, IController
  {
    private const int LAST_REVISION = 1;
    public const int MID = 261;

    public Mid0261()
      : this(new int?(0))
    {
    }

    public Mid0261(int? noAckFlag = 0)
      : base(261, 1, noAckFlag)
    {
    }
  }
}
