
// Type: OpenProtocolInterpreter.Converters.RelayListConverter
using OpenProtocolInterpreter.IOInterface;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Converters
{
  public class RelayListConverter : AsciiConverter<IEnumerable<Relay>>
  {
    private readonly IValueConverter<int> _intConverter;
    private readonly IValueConverter<bool> _boolConverter;

    public RelayListConverter(
      IValueConverter<int> intConverter,
      IValueConverter<bool> boolConverter)
    {
      this._intConverter = intConverter;
      this._boolConverter = boolConverter;
    }

    public override IEnumerable<Relay> Convert(string value)
    {
      for (int i = 0; i < value.Length; i += 4)
        yield return new Relay()
        {
          Number = (RelayNumber) this._intConverter.Convert(value.Substring(i, 3)),
          Status = this._boolConverter.Convert(value.Substring(i + 3, 1))
        };
    }

    public override string Convert(IEnumerable<Relay> value)
    {
      string str = string.Empty;
      foreach (Relay relay in value)
        str = str + this._intConverter.Convert('0', 3, DataField.PaddingOrientations.LEFT_PADDED, (int) relay.Number) + this._boolConverter.Convert(relay.Status);
      return str;
    }

    public override string Convert(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      IEnumerable<Relay> value)
    {
      return this.Convert(value);
    }
  }
}
