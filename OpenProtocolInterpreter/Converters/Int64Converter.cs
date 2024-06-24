
// Type: OpenProtocolInterpreter.Converters.Int64Converter

namespace OpenProtocolInterpreter.Converters
{
  public class Int64Converter : AsciiConverter<long>
  {
    public override long Convert(string value)
    {
      long result = 0;
      if (value != null)
        long.TryParse(value.ToString(), out result);
      return result;
    }

    public override string Convert(long value) => value.ToString();

    public override string Convert(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      long value)
    {
      return this.GetPadded(paddingChar, size, orientation, this.Convert(value));
    }
  }
}
