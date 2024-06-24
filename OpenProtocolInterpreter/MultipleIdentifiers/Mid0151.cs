
// Type: OpenProtocolInterpreter.MultipleIdentifiers.Mid0151

namespace OpenProtocolInterpreter.MultipleIdentifiers
{
  public class Mid0151 : Mid, IMultipleIdentifier, IIntegrator
  {
    private const int LAST_REVISION = 1;
    public const int MID = 151;

    public Mid0151()
      : this(new int?(0))
    {
    }

    public Mid0151(int? noAckFlag = 0)
      : base(151, 1, noAckFlag)
    {
    }
  }
}
