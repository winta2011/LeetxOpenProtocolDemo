
// Type: OpenProtocolInterpreter.Converters.Int32Converter

namespace OpenProtocolInterpreter.Converters
{
  public class Int32Converter : AsciiConverter<int>
  {
    public override int Convert(string value)
    {
      int result = 0;
      if (value != null)
        int.TryParse(value.ToString(), out result);
      return result;
    }

    public override string Convert(int value) => value.ToString();

    public override string Convert(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      int value)
    {
      return this.GetPadded(paddingChar, size, orientation, this.Convert(value));
    }
  }
}
