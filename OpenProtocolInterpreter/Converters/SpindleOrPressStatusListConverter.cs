
// Type: OpenProtocolInterpreter.Converters.SpindleOrPressStatusListConverter
using OpenProtocolInterpreter.MultiSpindle;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Converters
{
  public class SpindleOrPressStatusListConverter : AsciiConverter<IEnumerable<SpindleOrPressStatus>>
  {
    private readonly IValueConverter<Decimal> _decimalConverter;
    private readonly IValueConverter<int> _intConverter;
    private readonly IValueConverter<bool> _boolConverter;

    public SpindleOrPressStatusListConverter(
      IValueConverter<int> intConverter,
      IValueConverter<bool> boolConverter,
      IValueConverter<Decimal> decimalConverter)
    {
      this._intConverter = intConverter;
      this._boolConverter = boolConverter;
      this._decimalConverter = decimalConverter;
    }

    public override IEnumerable<SpindleOrPressStatus> Convert(string value)
    {
      for (int i = 0; i < value.Length; i += 18)
      {
        string spindleValue = value.Substring(i * 18, 18);
        yield return new SpindleOrPressStatus()
        {
          SpindleOrPressNumber = this._intConverter.Convert(spindleValue.Substring(0, 2)),
          ChannelId = this._intConverter.Convert(spindleValue.Substring(2, 2)),
          OverallStatus = this._boolConverter.Convert(spindleValue.Substring(4, 1)),
          TorqueOrForceStatus = (TighteningValueStatus) this._intConverter.Convert(spindleValue.Substring(5, 1)),
          TorqueOrForce = this._decimalConverter.Convert(spindleValue.Substring(6, 6)),
          AngleOrStrokeStatus = this._boolConverter.Convert(spindleValue.Substring(12, 1)),
          AngleOrStroke = this._intConverter.Convert(spindleValue.Substring(13, 5))
        };
        spindleValue = (string) null;
      }
    }

    public override string Convert(IEnumerable<SpindleOrPressStatus> value)
    {
      string str = string.Empty;
      foreach (SpindleOrPressStatus spindleOrPressStatus in value)
        str = str + this._intConverter.Convert('0', 2, DataField.PaddingOrientations.LEFT_PADDED, spindleOrPressStatus.SpindleOrPressNumber) + this._intConverter.Convert('0', 2, DataField.PaddingOrientations.LEFT_PADDED, spindleOrPressStatus.ChannelId) + this._boolConverter.Convert(spindleOrPressStatus.OverallStatus) + this._intConverter.Convert((int) spindleOrPressStatus.TorqueOrForceStatus) + this._decimalConverter.Convert('0', 6, DataField.PaddingOrientations.LEFT_PADDED, spindleOrPressStatus.TorqueOrForce) + this._boolConverter.Convert(spindleOrPressStatus.AngleOrStrokeStatus) + this._intConverter.Convert('0', 5, DataField.PaddingOrientations.LEFT_PADDED, spindleOrPressStatus.AngleOrStroke);
      return str;
    }

    public override string Convert(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      IEnumerable<SpindleOrPressStatus> value)
    {
      throw new NotImplementedException();
    }
  }
}
