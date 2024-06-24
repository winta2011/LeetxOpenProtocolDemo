
// Type: OpenProtocolInterpreter.ApplicationSelector.Mid0251
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OpenProtocolInterpreter.ApplicationSelector
{
  public class Mid0251 : Mid, IApplicationSelector, IController
  {
    private readonly IValueConverter<int> _intConverter;
    private IValueConverter<IEnumerable<bool>> _boolListConverter;
    private const int LAST_REVISION = 1;
    public const int MID = 251;

    public int DeviceId
    {
      get => this.GetField(1, 0).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 0).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int NumberOfSockets
    {
      get => this.GetField(1, 1).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 1).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public List<bool> SocketStatus { get; set; }

    public Mid0251()
      : this(new int?(0))
    {
    }

    public Mid0251(int? noAckFlag = 0)
      : base(251, 1, noAckFlag)
    {
      this._intConverter = (IValueConverter<int>) new Int32Converter();
      this._boolListConverter = (IValueConverter<IEnumerable<bool>>) new SocketStatusConverter((IValueConverter<bool>) new BoolConverter());
      if (this.SocketStatus != null)
        return;
      this.SocketStatus = new List<bool>();
    }

    public Mid0251(
      int deviceId,
      int numberOfSockets,
      IEnumerable<bool> socketStatus,
      int? noAckFlag = 0)
      : this(noAckFlag)
    {
      this.DeviceId = deviceId;
      this.NumberOfSockets = numberOfSockets;
      this.SocketStatus = socketStatus.ToList<bool>();
    }

    public override string Pack()
    {
      this.GetField(1, 2).Size = this.NumberOfSockets;
      this.GetField(1, 2).Value = this._boolListConverter.Convert((IEnumerable<bool>) this.SocketStatus);
      return base.Pack();
    }

    public override Mid Parse(string package)
    {
      this.HeaderData = this.ProcessHeader(package);
      this.GetField(1, 2).Size = package.Length - 30;
      this.ProcessDataFields(package);
      this.SocketStatus = this._boolListConverter.Convert(this.GetField(1, 2).Value).ToList<bool>();
      return (Mid) this;
    }

    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
      return new Dictionary<int, List<DataField>>()
      {
        {
          1,
          new List<DataField>()
          {
            new DataField(0, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(1, 24, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(2, 28, 0)
          }
        }
      };
    }

    public enum DataFields
    {
      DEVICE_ID,
      NUMBER_OF_SOCKETS,
      SOCKET_STATUS,
    }
  }
}
