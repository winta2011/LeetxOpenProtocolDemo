
// Type: OpenProtocolInterpreter.Converters.DecimalConverter
using System;
using System.Globalization;


namespace OpenProtocolInterpreter.Converters
{
  public class DecimalConverter : AsciiConverter<Decimal>
  {
    public override Decimal Convert(string value)
    {
      Decimal result = 0M;
      if (value != null)
        Decimal.TryParse(value.Replace(',', '.'), NumberStyles.AllowDecimalPoint, (IFormatProvider) new CultureInfo("en-US"), out result);
      return result;
    }

    public override string Convert(Decimal value)
    {
      return value.ToString("00.0###", (IFormatProvider) new CultureInfo("en-US"));
    }

    public override string Convert(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      Decimal value)
    {
      return this.GetPadded(paddingChar, size, orientation, this.Convert(value));
    }
  }
}
