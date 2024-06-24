
// Type: OpenProtocolInterpreter.Converters.LightCommandListConverter
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Converters
{
  public class LightCommandListConverter : AsciiConverter<IEnumerable<LightCommand>>
  {
    private readonly IValueConverter<int> _intConverter;

    public LightCommandListConverter(IValueConverter<int> intConverter)
    {
      this._intConverter = intConverter;
    }

    public override IEnumerable<LightCommand> Convert(string value)
    {
      string str = value;
      for (int index = 0; index < str.Length; ++index)
      {
        char c = str[index];
        yield return (LightCommand) this._intConverter.Convert(c.ToString());
      }
      str = (string) null;
    }

    public override string Convert(IEnumerable<LightCommand> value)
    {
      string empty = string.Empty;
      foreach (LightCommand lightCommand in value)
        empty += this._intConverter.Convert((int) lightCommand);
      return empty;
    }

    public override string Convert(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      IEnumerable<LightCommand> value)
    {
      return this.Convert(value);
    }
  }
}
