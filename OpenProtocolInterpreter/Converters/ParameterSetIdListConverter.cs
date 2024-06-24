
// Type: OpenProtocolInterpreter.Converters.ParameterSetIdListConverter
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Converters
{
  public class ParameterSetIdListConverter : AsciiConverter<IEnumerable<int>>
  {
    private readonly IValueConverter<int> _intConverter;

    public ParameterSetIdListConverter(IValueConverter<int> intConverter)
    {
      this._intConverter = intConverter;
    }

    public override IEnumerable<int> Convert(string value)
    {
      for (int i = 0; i < value.Length; i += 3)
        yield return this._intConverter.Convert(value.Substring(i, 3));
    }

    public override string Convert(IEnumerable<int> value)
    {
      string empty = string.Empty;
      foreach (int num in value)
        empty += this._intConverter.Convert('0', 3, DataField.PaddingOrientations.LEFT_PADDED, num);
      return empty;
    }

    public override string Convert(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      IEnumerable<int> value)
    {
      return this.Convert(value);
    }
  }
}
