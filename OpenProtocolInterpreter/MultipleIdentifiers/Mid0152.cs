
// Type: OpenProtocolInterpreter.MultipleIdentifiers.Mid0152
using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.MultipleIdentifiers
{
  public class Mid0152 : Mid, IMultipleIdentifier, IController
  {
    private readonly IValueConverter<IdentifierStatus> _identifierStatusConverter;
    private const int LAST_REVISION = 1;
    public const int MID = 152;

    public IdentifierStatus FirstIdentifierStatus { get; set; }

    public IdentifierStatus SecondIdentifierStatus { get; set; }

    public IdentifierStatus ThirdIdentifierStatus { get; set; }

    public IdentifierStatus FourthIdentifierStatus { get; set; }

    public Mid0152()
      : base(152, 1)
    {
      this._identifierStatusConverter = (IValueConverter<IdentifierStatus>) new IdentifierStatusConverter((IValueConverter<int>) new Int32Converter(), (IValueConverter<bool>) new BoolConverter());
    }

    public override string Pack()
    {
      this.GetField(1, 0).Value = this._identifierStatusConverter.Convert(this.FirstIdentifierStatus);
      this.GetField(1, 1).Value = this._identifierStatusConverter.Convert(this.SecondIdentifierStatus);
      this.GetField(1, 2).Value = this._identifierStatusConverter.Convert(this.ThirdIdentifierStatus);
      this.GetField(1, 3).Value = this._identifierStatusConverter.Convert(this.FourthIdentifierStatus);
      return base.Pack();
    }

    public override Mid Parse(string package)
    {
      base.Parse(package);
      this.FirstIdentifierStatus = this._identifierStatusConverter.Convert(this.GetField(1, 0).Value);
      this.SecondIdentifierStatus = this._identifierStatusConverter.Convert(this.GetField(1, 1).Value);
      this.ThirdIdentifierStatus = this._identifierStatusConverter.Convert(this.GetField(1, 2).Value);
      this.FourthIdentifierStatus = this._identifierStatusConverter.Convert(this.GetField(1, 3).Value);
      return (Mid) this;
    }

    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
      return new Dictionary<int, List<DataField>>()
      {
        {
          1,
          new List<DataField>()
          {
            new DataField(0, 20, 30),
            new DataField(1, 52, 30),
            new DataField(2, 84, 30),
            new DataField(3, 116, 30)
          }
        }
      };
    }

    public enum DataFields
    {
      FIRST_IDENTIFIER_STATUS,
      SECOND_IDENTIFIER_STATUS,
      THIRD_IDENTIFIER_STATUS,
      FOURTH_IDENTIFIER_STATUS,
    }
  }
}
