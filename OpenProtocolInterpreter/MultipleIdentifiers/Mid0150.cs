
// Type: OpenProtocolInterpreter.MultipleIdentifiers.Mid0150
using System.Collections.Generic;


namespace OpenProtocolInterpreter.MultipleIdentifiers
{
  public class Mid0150 : Mid, IMultipleIdentifier, IIntegrator
  {
    private const int LAST_REVISION = 1;
    public const int MID = 150;

    public string IdentifierData
    {
      get => this.GetField(1, 0).Value;
      set => this.GetField(1, 0).SetValue(value);
    }

    public Mid0150()
      : base(150, 1)
    {
    }

    public Mid0150(string identifierData)
      : this()
    {
      this.IdentifierData = identifierData;
    }

    public override Mid Parse(string package)
    {
      this.HeaderData = this.ProcessHeader(package);
      this.GetField(1, 0).Size = package.Length - 20;
      this.ProcessDataFields(package);
      return (Mid) this;
    }

    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
      return new Dictionary<int, List<DataField>>()
      {
        {
          1,
          new List<DataField>() { new DataField(0, 20, 100, false) }
        }
      };
    }

    public enum DataFields
    {
      IDENTIFIER_DATA,
    }
  }
}
