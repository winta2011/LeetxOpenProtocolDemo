
// Type: OpenProtocolInterpreter.Converters.SpindleStatusConverter
using OpenProtocolInterpreter.MultiSpindle;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Converters
{
  public class SpindleStatusConverter : AsciiConverter<IEnumerable<SpindleStatus>>
  {
    private readonly IValueConverter<int> _intConverter;
    private readonly IValueConverter<bool> _boolConverter;

    public SpindleStatusConverter(
      IValueConverter<int> intConverter,
      IValueConverter<bool> boolConverter)
    {
      this._intConverter = intConverter;
      this._boolConverter = boolConverter;
    }

    public override IEnumerable<SpindleStatus> Convert(string value)
    {
      for (int i = 0; i < value.Length; i += 5)
        yield return new SpindleStatus()
        {
          SpindleNumber = this._intConverter.Convert(value.Substring(i, 2)),
          ChannelId = this._intConverter.Convert(value.Substring(i + 2, 2)),
          SyncOverallStatus = this._boolConverter.Convert(value.Substring(i + 4, 1))
        };
    }

    public override string Convert(IEnumerable<SpindleStatus> value)
    {
      string str = string.Empty;
      foreach (SpindleStatus spindleStatus in value)
        str = str + this._intConverter.Convert('0', 2, DataField.PaddingOrientations.LEFT_PADDED, spindleStatus.SpindleNumber) + this._intConverter.Convert('0', 2, DataField.PaddingOrientations.LEFT_PADDED, spindleStatus.ChannelId) + this._boolConverter.Convert(spindleStatus.SyncOverallStatus);
      return str;
    }

    public override string Convert(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      IEnumerable<SpindleStatus> value)
    {
      return this.Convert(value);
    }
  }
}
