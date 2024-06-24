
// Type: OpenProtocolInterpreter.Converters.OpenEndDataConverter
using OpenProtocolInterpreter.Tool;


namespace OpenProtocolInterpreter.Converters
{
  public class OpenEndDataConverter : AsciiConverter<Mid0041.OpenEndDatas>
  {
    private readonly IValueConverter<bool> _boolConverter;
    private readonly IValueConverter<int> _intConverter;

    public OpenEndDataConverter(
      IValueConverter<int> intConverter,
      IValueConverter<bool> boolConverter)
    {
      this._boolConverter = boolConverter;
      this._intConverter = intConverter;
    }

    public override Mid0041.OpenEndDatas Convert(string value)
    {
      return new Mid0041.OpenEndDatas()
      {
        UseOpenEnd = this._boolConverter.Convert(value[0].ToString()),
        TighteningDirection = (TighteningDirection) this._intConverter.Convert(value[1].ToString()),
        MotorRotation = (MotorRotation) this._intConverter.Convert(value[2].ToString())
      };
    }

    public override string Convert(Mid0041.OpenEndDatas value)
    {
      return this._boolConverter.Convert(value.UseOpenEnd) + this._intConverter.Convert((int) value.TighteningDirection) + this._intConverter.Convert((int) value.MotorRotation);
    }

    public override string Convert(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      Mid0041.OpenEndDatas value)
    {
      return this.Convert(value);
    }
  }
}
