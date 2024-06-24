
// Type: OpenProtocolInterpreter.Converters.IdentifierStatusConverter
using OpenProtocolInterpreter.MultipleIdentifiers;


namespace OpenProtocolInterpreter.Converters
{
  public class IdentifierStatusConverter : AsciiConverter<IdentifierStatus>
  {
    private readonly IValueConverter<int> _intConverter;
    private readonly IValueConverter<bool> _boolConverter;

    public IdentifierStatusConverter(
      IValueConverter<int> intConverter,
      IValueConverter<bool> boolConverter)
    {
      this._intConverter = intConverter;
      this._boolConverter = boolConverter;
    }

    public override IdentifierStatus Convert(string value)
    {
      return new IdentifierStatus()
      {
        IdentifierTypeNumber = this._intConverter.Convert(value.Substring(0, 1)),
        IncludedInWorkOrder = this._boolConverter.Convert(value.Substring(1, 2)),
        StatusInWorkOrder = (StatusInWorkOrder) this._intConverter.Convert(value.Substring(3, 2)),
        ResultPart = value.Substring(5, 25)
      };
    }

    public override string Convert(IdentifierStatus value)
    {
      return this._intConverter.Convert('0', 1, DataField.PaddingOrientations.LEFT_PADDED, value.IdentifierTypeNumber) + this._intConverter.Convert('0', 2, DataField.PaddingOrientations.LEFT_PADDED, System.Convert.ToInt32(value.IncludedInWorkOrder)) + this._intConverter.Convert('0', 2, DataField.PaddingOrientations.LEFT_PADDED, (int) value.StatusInWorkOrder) + value.ResultPart.PadRight(25, ' ');
    }

    public override string Convert(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      IdentifierStatus value)
    {
      return this.Convert(value);
    }
  }
}
