
// Type: OpenProtocolInterpreter.Converters.DecimalTrucatedConverter
using System;


namespace OpenProtocolInterpreter.Converters
{
  public class DecimalTrucatedConverter : AsciiConverter<Decimal>
  {
    private readonly Decimal _decimalPointsMultiplier;
    private readonly int _decimalPoints;

    public DecimalTrucatedConverter(int decimalPoints)
    {
      this._decimalPointsMultiplier = 1M;
      for (int index = 0; index < decimalPoints; ++index)
        this._decimalPointsMultiplier *= 10M;
      this._decimalPoints = decimalPoints;
    }

    public override Decimal Convert(string value)
    {
      int result = 0;
      if (value != null)
        int.TryParse(value.ToString(), out result);
      return (Decimal) result / this._decimalPointsMultiplier;
    }

    public override string Convert(Decimal value)
    {
      return ((int) (Math.Round(value, this._decimalPoints) * this._decimalPointsMultiplier)).ToString();
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
