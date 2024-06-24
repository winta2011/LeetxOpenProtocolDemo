
// Type: OpenProtocolInterpreter.Communication.Mid0001

namespace OpenProtocolInterpreter.Communication
{
  public class Mid0001 : Mid, ICommunication, IIntegrator
  {
    private const int LAST_REVISION = 5;
    public const int MID = 1;

    public Mid0001()
      : this(5)
    {
    }

    public Mid0001(int revision = 5)
      : base(1, revision)
    {
    }
  }
}
