
// Type: OpenProtocolInterpreter.Converters.StageResultListConverter
using OpenProtocolInterpreter.Tightening;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Converters
{
  public class StageResultListConverter : AsciiConverter<IEnumerable<StageResult>>
  {
    private readonly IValueConverter<int> _intConverter;
    private readonly IValueConverter<Decimal> _decimalConverter;

    public StageResultListConverter(
      IValueConverter<int> intConverter,
      IValueConverter<Decimal> decimalConverter)
    {
      this._intConverter = intConverter;
      this._decimalConverter = decimalConverter;
    }

    public override IEnumerable<StageResult> Convert(string value)
    {
      for (int i = 0; i < value.Length; i += 11)
        yield return new StageResult()
        {
          Torque = this._decimalConverter.Convert(value.Substring(i, 6)),
          Angle = this._intConverter.Convert(value.Substring(i + 6, 5))
        };
    }

    public override string Convert(IEnumerable<StageResult> value)
    {
      string empty = string.Empty;
      foreach (StageResult stageResult in value)
      {
        empty += this._decimalConverter.Convert('0', 6, DataField.PaddingOrientations.LEFT_PADDED, stageResult.Torque);
        empty += this._intConverter.Convert('0', 5, DataField.PaddingOrientations.LEFT_PADDED, stageResult.Angle);
      }
      return empty;
    }

    public override string Convert(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      IEnumerable<StageResult> value)
    {
      return this.Convert(value);
    }
  }
}
