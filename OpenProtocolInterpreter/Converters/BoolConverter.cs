
// Type: OpenProtocolInterpreter.Converters.BoolConverter

namespace OpenProtocolInterpreter.Converters
{
  public class BoolConverter : AsciiConverter<bool>
  {
    public override bool Convert(string value)
    {
      int result = 0;
      if (value != null)
        int.TryParse(value.ToString(), out result);
      return System.Convert.ToBoolean(result);
    }

    public override string Convert(bool value) => !value ? "0" : "1";

    public override string Convert(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      bool value)
    {
      return this.Convert(value);
    }
  }
}
