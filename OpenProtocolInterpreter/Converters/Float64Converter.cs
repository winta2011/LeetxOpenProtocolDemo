
// Type: OpenProtocolInterpreter.Converters.Float64Converter

namespace OpenProtocolInterpreter.Converters
{
  internal class Float64Converter : AsciiConverter<double>
  {
    public override double Convert(string value)
    {
      double result = 0.0;
      if (value != null)
        double.TryParse(value.ToString(), out result);
      return result;
    }

    public override string Convert(double value) => value.ToString();

    public override string Convert(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      double value)
    {
      return this.GetPadded(paddingChar, size, orientation, this.Convert(value));
    }
  }
}
