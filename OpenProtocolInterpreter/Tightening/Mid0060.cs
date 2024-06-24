
// Type: OpenProtocolInterpreter.Tightening.Mid0060

namespace OpenProtocolInterpreter.Tightening
{
  public class Mid0060 : Mid, ITightening, IIntegrator
  {
    private const int LAST_REVISION = 7;
    public const int MID = 60;

    public Mid0060()
      : this(7, new int?(0))
    {
    }

    public Mid0060(int revision = 7, int? noAckFlag = 0)
      : base(60, revision, noAckFlag)
    {
    }
  }
}
