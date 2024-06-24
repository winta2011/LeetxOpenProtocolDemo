
// Type: OpenProtocolInterpreter.Converters.DigitalInputListConverter
using OpenProtocolInterpreter.IOInterface;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Converters
{
  public class DigitalInputListConverter : AsciiConverter<IEnumerable<DigitalInput>>
  {
    private readonly IValueConverter<int> _intConverter;
    private readonly IValueConverter<bool> _boolConverter;

    public DigitalInputListConverter(
      IValueConverter<int> intConverter,
      IValueConverter<bool> boolConverter)
    {
      this._intConverter = intConverter;
      this._boolConverter = boolConverter;
    }

    public override IEnumerable<DigitalInput> Convert(string value)
    {
      for (int i = 0; i < value.Length; i += 4)
        yield return new DigitalInput()
        {
          Number = (DigitalInputNumber) this._intConverter.Convert(value.Substring(i, 3)),
          Status = this._boolConverter.Convert(value.Substring(i + 3, 1))
        };
    }

    public override string Convert(IEnumerable<DigitalInput> value)
    {
      string str = string.Empty;
      foreach (DigitalInput digitalInput in value)
        str = str + this._intConverter.Convert('0', 3, DataField.PaddingOrientations.LEFT_PADDED, (int) digitalInput.Number) + this._boolConverter.Convert(digitalInput.Status);
      return str;
    }

    public override string Convert(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      IEnumerable<DigitalInput> value)
    {
      return this.Convert(value);
    }
  }
}
