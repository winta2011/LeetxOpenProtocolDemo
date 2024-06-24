
// Type: OpenProtocolInterpreter.Converters.ValueConverter

namespace OpenProtocolInterpreter.Converters
{
  public class ValueConverter
  {
    public string GetPadded(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      string value)
    {
      if (value == null)
        return string.Empty.PadLeft(size, paddingChar);
      return orientation == DataField.PaddingOrientations.RIGHT_PADDED ? value.PadRight(size, paddingChar) : value.PadLeft(size, paddingChar);
    }
  }
}
