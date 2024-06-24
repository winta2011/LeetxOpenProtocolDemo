
// Type: OpenProtocolInterpreter.Converters.SocketStatusConverter
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Converters
{
  public class SocketStatusConverter : AsciiConverter<IEnumerable<bool>>
  {
    private readonly IValueConverter<bool> _boolConverter;

    public SocketStatusConverter(IValueConverter<bool> boolConverter)
    {
      this._boolConverter = boolConverter;
    }

    public override IEnumerable<bool> Convert(string value)
    {
      string str = value;
      for (int index = 0; index < str.Length; ++index)
      {
        char c = str[index];
        yield return this._boolConverter.Convert(c.ToString());
      }
      str = (string) null;
    }

    public override string Convert(IEnumerable<bool> value)
    {
      string empty = string.Empty;
      foreach (bool flag in value)
        empty += this._boolConverter.Convert(flag);
      return empty;
    }

    public override string Convert(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      IEnumerable<bool> value)
    {
      return this.Convert(value);
    }
  }
}
