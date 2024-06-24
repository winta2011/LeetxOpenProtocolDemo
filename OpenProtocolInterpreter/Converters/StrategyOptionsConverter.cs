
// Type: OpenProtocolInterpreter.Converters.StrategyOptionsConverter
using OpenProtocolInterpreter.Tightening;


namespace OpenProtocolInterpreter.Converters
{
  public class StrategyOptionsConverter : BitConverter, IValueConverter<StrategyOptions>
  {
    private readonly IValueConverter<byte[]> _byteArrayConverter;

    public StrategyOptionsConverter(IValueConverter<byte[]> byteArrayConverter)
    {
      this._byteArrayConverter = byteArrayConverter;
    }

    public StrategyOptions Convert(string value)
    {
      return this.ConvertFromBytes(this._byteArrayConverter.Convert(value));
    }

    public string Convert(StrategyOptions value)
    {
      return this._byteArrayConverter.Convert(this.ConvertToBytes(value));
    }

    public string Convert(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      StrategyOptions value)
    {
      return this.Convert(value);
    }

    public StrategyOptions ConvertFromBytes(byte[] value)
    {
      return new StrategyOptions()
      {
        Torque = this.GetBit(value[0], 1),
        Angle = this.GetBit(value[0], 2),
        Batch = this.GetBit(value[0], 3),
        PvtMonitoring = this.GetBit(value[0], 4),
        PvtCompensate = this.GetBit(value[0], 5),
        Selftap = this.GetBit(value[0], 6),
        Rundown = this.GetBit(value[0], 7),
        CM = this.GetBit(value[0], 8),
        DsControl = this.GetBit(value[1], 1),
        ClickWrench = this.GetBit(value[1], 2),
        RbwMonitoring = this.GetBit(value[1], 3)
      };
    }

    public byte[] ConvertToBytes(StrategyOptions value)
    {
      byte[] bytes = new byte[10];
      bytes[0] = this.SetByte(new bool[8]
      {
        value.Torque,
        value.Angle,
        value.Batch,
        value.PvtMonitoring,
        value.PvtCompensate,
        value.Selftap,
        value.Rundown,
        value.CM
      });
      byte[] numArray = bytes;
      bool[] values = new bool[8];
      values[0] = value.DsControl;
      values[1] = value.ClickWrench;
      values[2] = value.RbwMonitoring;
      int num = (int) this.SetByte(values);
      numArray[1] = (byte) num;
      bytes[2] = bytes[3] = bytes[4] = bytes[5] = bytes[6] = bytes[7] = bytes[8] = bytes[9] = (byte) 0;
      return bytes;
    }

    public byte[] ConvertToBytes(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      StrategyOptions value)
    {
      return this.ConvertToBytes(value);
    }
  }
}
