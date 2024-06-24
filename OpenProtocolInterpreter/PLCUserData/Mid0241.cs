
// Type: OpenProtocolInterpreter.PLCUserData.Mid0241

namespace OpenProtocolInterpreter.PLCUserData
{
  public class Mid0241 : Mid, IPLCUserData, IIntegrator
  {
    private const int LAST_REVISION = 1;
    public const int MID = 241;

    public Mid0241()
      : this(new int?(0))
    {
    }

    public Mid0241(int? noAckFlag = 0)
      : base(241, 1, noAckFlag)
    {
    }
  }
}
