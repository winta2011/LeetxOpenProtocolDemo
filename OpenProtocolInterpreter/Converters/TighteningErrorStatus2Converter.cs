
// Type: OpenProtocolInterpreter.Converters.TighteningErrorStatus2Converter
using OpenProtocolInterpreter.Tightening;


namespace OpenProtocolInterpreter.Converters
{
  internal class TighteningErrorStatus2Converter : 
    BitConverter,
    IValueConverter<TighteningErrorStatus2>
  {
    private readonly IValueConverter<byte[]> _byteArrayConverter;

    public TighteningErrorStatus2Converter(IValueConverter<byte[]> byteArrayConverter)
    {
      this._byteArrayConverter = byteArrayConverter;
    }

    public TighteningErrorStatus2 Convert(string value)
    {
      return this.ConvertFromBytes(this._byteArrayConverter.Convert(value));
    }

    public string Convert(TighteningErrorStatus2 value)
    {
      return this._byteArrayConverter.Convert(this.ConvertToBytes(value));
    }

    public string Convert(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      TighteningErrorStatus2 value)
    {
      return this.Convert(value);
    }

    public TighteningErrorStatus2 ConvertFromBytes(byte[] value)
    {
      TighteningErrorStatus2 tighteningErrorStatus2 = new TighteningErrorStatus2()
      {
        DriveDeactivated = this.GetBit(value[0], 1),
        ToolStall = this.GetBit(value[0], 2),
        DriveHot = this.GetBit(value[0], 3),
        GradientMonitoringHigh = this.GetBit(value[0], 4),
        GradientMonitoringLow = this.GetBit(value[0], 5),
        ReactionBarFailed = this.GetBit(value[0], 6),
        Reserved = new byte[10]
      };
      byte[] reserved = tighteningErrorStatus2.Reserved;
      bool[] values = new bool[8];
      values[0] = this.GetBit(value[0], 7);
      values[1] = this.GetBit(value[0], 8);
      int num = (int) this.SetByte(values);
      reserved[0] = (byte) num;
      return tighteningErrorStatus2;
    }

    public byte[] ConvertToBytes(TighteningErrorStatus2 value)
    {
      return new byte[10]
      {
        this.SetByte(new bool[8]
        {
          value.DriveDeactivated,
          value.ToolStall,
          value.DriveHot,
          value.GradientMonitoringHigh,
          value.GradientMonitoringLow,
          value.ReactionBarFailed,
          this.GetBit(value.Reserved[0], 7),
          this.GetBit(value.Reserved[0], 8)
        }),
        value.Reserved[1],
        value.Reserved[2],
        value.Reserved[3],
        value.Reserved[4],
        value.Reserved[5],
        value.Reserved[6],
        value.Reserved[7],
        value.Reserved[8],
        value.Reserved[9]
      };
    }

    public byte[] ConvertToBytes(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      TighteningErrorStatus2 value)
    {
      return this.ConvertToBytes(value);
    }
  }
}
