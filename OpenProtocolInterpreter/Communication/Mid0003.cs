
// Type: OpenProtocolInterpreter.Communication.Mid0003

namespace OpenProtocolInterpreter.Communication
{
  public class Mid0003 : Mid, ICommunication, IIntegrator
  {
    private const int LAST_REVISION = 1;
    public const int MID = 3;

    public Mid0003()
      : base(3, 1)
    {
    }
  }
}
