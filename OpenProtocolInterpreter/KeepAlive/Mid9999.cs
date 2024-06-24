
// Type: OpenProtocolInterpreter.KeepAlive.Mid9999

namespace OpenProtocolInterpreter.KeepAlive
{
  public class Mid9999 : Mid, IIntegrator, IController
  {
    private const int LAST_REVISION = 1;
    public const int MID = 9999;

    public Mid9999()
      : base(9999, 1)
    {
    }
  }
}
