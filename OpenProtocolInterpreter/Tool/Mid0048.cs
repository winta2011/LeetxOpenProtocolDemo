
// Type: OpenProtocolInterpreter.Tool.Mid0048
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Tool
{
  public class Mid0048 : Mid, ITool, IController
  {
    private readonly IValueConverter<int> _intConverter;
    private readonly IValueConverter<DateTime> _dateConverter;
    private const int LAST_REVISION = 1;
    public const int MID = 48;

    public PairingStatus PairingStatus
    {
      get
      {
        return (PairingStatus) this.GetField(1, 0).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 0).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public DateTime TimeStamp
    {
      get
      {
        return this.GetField(1, 1).GetValue<DateTime>(new Func<string, DateTime>(this._dateConverter.Convert));
      }
      set
      {
        this.GetField(1, 1).SetValue<DateTime>(new Func<char, int, DataField.PaddingOrientations, DateTime, string>(this._dateConverter.Convert), value);
      }
    }

    public Mid0048()
      : base(48, 1)
    {
      this._intConverter = (IValueConverter<int>) new Int32Converter();
      this._dateConverter = (IValueConverter<DateTime>) new DateConverter();
    }

    public Mid0048(PairingStatus pairingStatus, DateTime timeStamp)
      : this()
    {
      this.PairingStatus = pairingStatus;
      this.TimeStamp = timeStamp;
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
            new DataField(1, 24, 19)
          }
        }
      };
    }

    public enum DataFields
    {
      PAIRING_STATUS,
      TIMESTAMP,
    }
  }
}
