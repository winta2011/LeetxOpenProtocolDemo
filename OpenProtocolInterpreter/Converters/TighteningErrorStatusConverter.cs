
// Type: OpenProtocolInterpreter.Converters.TighteningErrorStatusConverter
using OpenProtocolInterpreter.Tightening;


namespace OpenProtocolInterpreter.Converters
{
  public class TighteningErrorStatusConverter : BitConverter, IValueConverter<TighteningErrorStatus>
  {
    private readonly IValueConverter<byte[]> _byteArrayConverter;

    public TighteningErrorStatusConverter(IValueConverter<byte[]> byteArrayConverter)
    {
      this._byteArrayConverter = byteArrayConverter;
    }

    public TighteningErrorStatus Convert(string value)
    {
      return this.ConvertFromBytes(this._byteArrayConverter.Convert(value));
    }

    public string Convert(TighteningErrorStatus value)
    {
      return this._byteArrayConverter.Convert(this.ConvertToBytes(value));
    }

    public string Convert(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      TighteningErrorStatus value)
    {
      return this.Convert(value);
    }

    public TighteningErrorStatus ConvertFromBytes(byte[] value)
    {
      return new TighteningErrorStatus()
      {
        RundownAngleMaxShutOff = this.GetBit(value[0], 1),
        RundownAngleMinShutOff = this.GetBit(value[0], 2),
        TorqueMaxShutOff = this.GetBit(value[0], 3),
        AngleMaxShutOff = this.GetBit(value[0], 4),
        SelftapTorqueMaxShutOff = this.GetBit(value[0], 5),
        SelftapTorqueMinShutOff = this.GetBit(value[0], 6),
        PrevailTorqueMaxShutOff = this.GetBit(value[0], 7),
        PrevailTorqueMinShutOff = this.GetBit(value[0], 8),
        PrevailTorqueCompensateOverflow = this.GetBit(value[1], 1),
        CurrentMonitoringMaxShutOff = this.GetBit(value[1], 2),
        PostViewTorqueMinTorqueShutOff = this.GetBit(value[1], 3),
        PostViewTorqueMaxTorqueShutOff = this.GetBit(value[1], 4),
        PostViewTorqueAngleTooSmall = this.GetBit(value[1], 5),
        TriggerLost = this.GetBit(value[1], 6),
        TorqueLessThanTarget = this.GetBit(value[1], 7),
        ToolHot = this.GetBit(value[1], 8),
        MultistageAbort = this.GetBit(value[2], 1),
        Rehit = this.GetBit(value[2], 2),
        DsMeasureFailed = this.GetBit(value[2], 3),
        CurrentLimitReached = this.GetBit(value[2], 4),
        EndTimeOutShutOff = this.GetBit(value[2], 5),
        RemoveFastenerLimitExceeded = this.GetBit(value[2], 6),
        DisableDrive = this.GetBit(value[2], 7),
        TransducerLost = this.GetBit(value[2], 8),
        TransducerShorted = this.GetBit(value[3], 1),
        TransducerCorrupt = this.GetBit(value[3], 2),
        SyncTimeout = this.GetBit(value[3], 3),
        DynamicCurrentMonitoringMin = this.GetBit(value[3], 4),
        DynamicCurrentMonitoringMax = this.GetBit(value[3], 5),
        AngleMaxMonitor = this.GetBit(value[3], 6),
        YieldNutOff = this.GetBit(value[3], 7),
        YieldTooFewSamples = this.GetBit(value[3], 8)
      };
    }

    public byte[] ConvertToBytes(TighteningErrorStatus value)
    {
      byte[] bytes = new byte[10];
      bytes[0] = this.SetByte(new bool[8]
      {
        value.RundownAngleMaxShutOff,
        value.RundownAngleMinShutOff,
        value.TorqueMaxShutOff,
        value.AngleMaxShutOff,
        value.SelftapTorqueMaxShutOff,
        value.SelftapTorqueMinShutOff,
        value.PrevailTorqueMaxShutOff,
        value.PrevailTorqueMinShutOff
      });
      bytes[1] = this.SetByte(new bool[8]
      {
        value.PrevailTorqueCompensateOverflow,
        value.CurrentMonitoringMaxShutOff,
        value.PostViewTorqueMinTorqueShutOff,
        value.PostViewTorqueMaxTorqueShutOff,
        value.PostViewTorqueAngleTooSmall,
        value.TriggerLost,
        value.TorqueLessThanTarget,
        value.ToolHot
      });
      bytes[2] = this.SetByte(new bool[8]
      {
        value.MultistageAbort,
        value.Rehit,
        value.DsMeasureFailed,
        value.CurrentLimitReached,
        value.EndTimeOutShutOff,
        value.RemoveFastenerLimitExceeded,
        value.DisableDrive,
        value.TransducerLost
      });
      bytes[3] = this.SetByte(new bool[8]
      {
        value.TransducerShorted,
        value.TransducerCorrupt,
        value.SyncTimeout,
        value.DynamicCurrentMonitoringMin,
        value.DynamicCurrentMonitoringMax,
        value.AngleMaxMonitor,
        value.YieldNutOff,
        value.YieldTooFewSamples
      });
      bytes[4] = bytes[5] = bytes[6] = bytes[7] = bytes[8] = bytes[9] = (byte) 0;
      return bytes;
    }

    public byte[] ConvertToBytes(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      TighteningErrorStatus value)
    {
      return this.ConvertToBytes(value);
    }
  }
}
