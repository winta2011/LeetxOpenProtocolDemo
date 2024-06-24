
// Type: OpenProtocolInterpreter.Tightening.Mid0065
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OpenProtocolInterpreter.Tightening
{
  public class Mid0065 : Mid, ITightening, IController
  {
    private readonly IValueConverter<int> _intConverter;
    private readonly IValueConverter<long> _longConverter;
    private readonly IValueConverter<bool> _boolConverter;
    private readonly IValueConverter<Decimal> _decimalConverter;
    private readonly IValueConverter<DateTime> _dateConverter;
    private readonly IValueConverter<StrategyOptions> _strategyOptionsConverter;
    private readonly IValueConverter<TighteningErrorStatus> _tighteningErrorStatusConverter;
    private readonly IValueConverter<TighteningErrorStatus2> _tighteningErrorStatus2Converter;
    public const int MID = 65;
    private const int LAST_REVISION = 6;

    public long TighteningId
    {
      get
      {
        return this.GetField(this.GetCurrentRevisionIndex(), 0).GetValue<long>(new Func<string, long>(this._longConverter.Convert));
      }
      set
      {
        this.GetField(this.GetCurrentRevisionIndex(), 0).SetValue<long>(new Func<char, int, DataField.PaddingOrientations, long, string>(this._longConverter.Convert), value);
      }
    }

    public string VinNumber
    {
      get => this.GetField(this.GetCurrentRevisionIndex(), 1).Value;
      set => this.GetField(this.GetCurrentRevisionIndex(), 1).SetValue(value);
    }

    public int ParameterSetId
    {
      get
      {
        return this.GetField(this.GetCurrentRevisionIndex(), 2).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(this.GetCurrentRevisionIndex(), 2).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int BatchCounter
    {
      get
      {
        return this.GetField(this.GetCurrentRevisionIndex(), 3).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(this.GetCurrentRevisionIndex(), 3).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public bool TighteningStatus
    {
      get
      {
        return this.GetField(this.GetCurrentRevisionIndex(), 4).GetValue<bool>(new Func<string, bool>(this._boolConverter.Convert));
      }
      set
      {
        this.GetField(this.GetCurrentRevisionIndex(), 4).SetValue<bool>(new Func<char, int, DataField.PaddingOrientations, bool, string>(this._boolConverter.Convert), value);
      }
    }

    public TighteningValueStatus TorqueStatus
    {
      get
      {
        return (TighteningValueStatus) this.GetField(this.GetCurrentRevisionIndex(), 5).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(this.GetCurrentRevisionIndex(), 3).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public TighteningValueStatus AngleStatus
    {
      get
      {
        return (TighteningValueStatus) this.GetField(this.GetCurrentRevisionIndex(), 6).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(this.GetCurrentRevisionIndex(), 3).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public Decimal Torque
    {
      get
      {
        return this.GetField(this.GetCurrentRevisionIndex(), 7).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(this.GetCurrentRevisionIndex(), 7).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public int Angle
    {
      get
      {
        return this.GetField(this.GetCurrentRevisionIndex(), 8).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(this.GetCurrentRevisionIndex(), 8).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public DateTime Timestamp
    {
      get
      {
        return this.GetField(this.GetCurrentRevisionIndex(), 9).GetValue<DateTime>(new Func<string, DateTime>(this._dateConverter.Convert));
      }
      set
      {
        this.GetField(this.GetCurrentRevisionIndex(), 9).SetValue<DateTime>(new Func<char, int, DataField.PaddingOrientations, DateTime, string>(this._dateConverter.Convert), value);
      }
    }

    public BatchStatus BatchStatus
    {
      get
      {
        return (BatchStatus) this.GetField(this.GetCurrentRevisionIndex(), 10).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(this.GetCurrentRevisionIndex(), 10).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public int JobId
    {
      get => this.GetField(2, 11).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(2, 11).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public Strategy Strategy
    {
      get
      {
        return (Strategy) this.GetField(2, 12).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(2, 12).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public StrategyOptions StrategyOptions
    {
      get
      {
        return this.GetField(2, 13).GetValue<StrategyOptions>(new Func<byte[], StrategyOptions>(this._strategyOptionsConverter.ConvertFromBytes));
      }
      set
      {
        this.GetField(2, 13).SetRawValue<StrategyOptions>(new Func<char, int, DataField.PaddingOrientations, StrategyOptions, byte[]>(this._strategyOptionsConverter.ConvertToBytes), value);
      }
    }

    public int BatchSize
    {
      get => this.GetField(2, 14).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(2, 14).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public TighteningValueStatus RundownAngleStatus
    {
      get
      {
        return (TighteningValueStatus) this.GetField(2, 15).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(2, 15).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public TighteningValueStatus CurrentMonitoringStatus
    {
      get
      {
        return (TighteningValueStatus) this.GetField(2, 16).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(2, 16).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public TighteningValueStatus SelftapStatus
    {
      get
      {
        return (TighteningValueStatus) this.GetField(2, 17).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(2, 17).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public TighteningValueStatus PrevailTorqueMonitoringStatus
    {
      get
      {
        return (TighteningValueStatus) this.GetField(2, 18).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(2, 18).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public TighteningValueStatus PrevailTorqueCompensateStatus
    {
      get
      {
        return (TighteningValueStatus) this.GetField(2, 19).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(2, 19).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public TighteningErrorStatus TighteningErrorStatus
    {
      get
      {
        return this.GetField(2, 20).GetValue<TighteningErrorStatus>(new Func<byte[], TighteningErrorStatus>(this._tighteningErrorStatusConverter.ConvertFromBytes));
      }
      set
      {
        this.GetField(2, 20).SetRawValue<TighteningErrorStatus>(new Func<char, int, DataField.PaddingOrientations, TighteningErrorStatus, byte[]>(this._tighteningErrorStatusConverter.ConvertToBytes), value);
      }
    }

    public int RundownAngle
    {
      get => this.GetField(2, 21).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(2, 21).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int CurrentMonitoringValue
    {
      get => this.GetField(2, 22).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(2, 22).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public Decimal SelftapTorque
    {
      get
      {
        return this.GetField(2, 23).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(2, 23).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public Decimal PrevailTorque
    {
      get
      {
        return this.GetField(2, 24).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(2, 24).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public int JobSequenceNumber
    {
      get => this.GetField(2, 25).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(2, 25).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int SyncTighteningId
    {
      get => this.GetField(2, 26).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(2, 26).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public string ToolSerialNumber
    {
      get => this.GetField(2, 27).Value;
      set => this.GetField(2, 27).SetValue(value);
    }

    public TorqueValuesUnit TorqueValuesUnit
    {
      get
      {
        return (TorqueValuesUnit) this.GetField(3, 28).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(3, 28).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public ResultType ResultType
    {
      get
      {
        return (ResultType) this.GetField(3, 29).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(3, 29).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public string IdentifierResultPart2
    {
      get => this.GetField(4, 30).Value;
      set => this.GetField(4, 30).SetValue(value);
    }

    public string IdentifierResultPart3
    {
      get => this.GetField(4, 31).Value;
      set => this.GetField(4, 31).SetValue(value);
    }

    public string IdentifierResultPart4
    {
      get => this.GetField(4, 32).Value;
      set => this.GetField(4, 32).SetValue(value);
    }

    public string CustomerTighteningErrorCode
    {
      get => this.GetField(5, 33).Value;
      set => this.GetField(5, 33).SetValue(value);
    }

    public Decimal PrevailTorqueCompensateValue
    {
      get
      {
        return this.GetField(6, 34).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(6, 34).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public TighteningErrorStatus2 TighteningErrorStatus2
    {
      get
      {
        return this.GetField(6, 35).GetValue<TighteningErrorStatus2>(new Func<byte[], TighteningErrorStatus2>(this._tighteningErrorStatus2Converter.ConvertFromBytes));
      }
      set
      {
        this.GetField(6, 35).SetRawValue<TighteningErrorStatus2>(new Func<char, int, DataField.PaddingOrientations, TighteningErrorStatus2, byte[]>(this._tighteningErrorStatus2Converter.ConvertToBytes), value);
      }
    }

    public Mid0065()
      : this(6)
    {
    }

    public Mid0065(int revision = 6)
      : base(65, revision)
    {
      ByteArrayConverter byteArrayConverter = new ByteArrayConverter();
      this._intConverter = (IValueConverter<int>) new Int32Converter();
      this._longConverter = (IValueConverter<long>) new Int64Converter();
      this._boolConverter = (IValueConverter<bool>) new BoolConverter();
      this._decimalConverter = (IValueConverter<Decimal>) new DecimalTrucatedConverter(2);
      this._dateConverter = (IValueConverter<DateTime>) new DateConverter();
      this._strategyOptionsConverter = (IValueConverter<StrategyOptions>) new StrategyOptionsConverter((IValueConverter<byte[]>) byteArrayConverter);
      this._tighteningErrorStatusConverter = (IValueConverter<TighteningErrorStatus>) new TighteningErrorStatusConverter((IValueConverter<byte[]>) byteArrayConverter);
      this._tighteningErrorStatus2Converter = (IValueConverter<TighteningErrorStatus2>) new TighteningErrorStatus2Converter((IValueConverter<byte[]>) byteArrayConverter);
    }

    protected override string BuildHeader()
    {
      if (this.RevisionsByFields.Any<KeyValuePair<int, List<DataField>>>())
      {
        this.HeaderData.Length = 20;
        this.HeaderData.Revision = this.HeaderData.Revision > 0 ? this.HeaderData.Revision : 1;
        if (this.HeaderData.Revision > 1)
        {
          for (int key = 2; key <= this.HeaderData.Revision; ++key)
          {
            foreach (DataField dataField in this.RevisionsByFields[key])
              this.HeaderData.Length += (dataField.HasPrefix ? 2 : 0) + dataField.Size;
          }
        }
        else
        {
          foreach (DataField dataField in this.RevisionsByFields[1])
            this.HeaderData.Length += (dataField.HasPrefix ? 2 : 0) + dataField.Size;
        }
      }
      return this.HeaderData.ToString();
    }

    [Obsolete("Use PackBytes(), this method will convert everything to ASCII, which will break packages above revision 1 because of byte fields")]
    public override string Pack()
    {
      string str = this.BuildHeader();
      if (this.HeaderData.Revision > 1)
      {
        int? nullable1 = new int?(this.HeaderData.Revision);
        int prefixIndex = 1;
        int key = 2;
        while (true)
        {
          int num = key;
          int? nullable2 = nullable1;
          int valueOrDefault = nullable2.GetValueOrDefault();
          if (num <= valueOrDefault & nullable2.HasValue)
          {
            str += this.BuildDataFieldsPackage(prefixIndex, this.RevisionsByFields[key]);
            prefixIndex += this.RevisionsByFields[key].Count<DataField>((Func<DataField, bool>) (x => x.HasPrefix));
            ++key;
          }
          else
            break;
        }
      }
      else
        str += this.BuildDataFieldsPackage(1, this.RevisionsByFields[1]);
      return str;
    }

    public override byte[] PackBytes()
    {
      List<byte> byteList = new List<byte>();
      byteList.AddRange((IEnumerable<byte>) this.BuildRawHeader());
      if (this.HeaderData.Revision > 1)
      {
        int? nullable1 = new int?(this.HeaderData.Revision);
        int prefixIndex = 1;
        int key = 2;
        while (true)
        {
          int num = key;
          int? nullable2 = nullable1;
          int valueOrDefault = nullable2.GetValueOrDefault();
          if (num <= valueOrDefault & nullable2.HasValue)
          {
            byte[] collection = this.BuildDataFieldsRawPackage(prefixIndex, this.RevisionsByFields[key]);
            byteList.AddRange((IEnumerable<byte>) collection);
            prefixIndex += this.RevisionsByFields[key].Count<DataField>((Func<DataField, bool>) (x => x.HasPrefix));
            ++key;
          }
          else
            break;
        }
      }
      else
        byteList.AddRange((IEnumerable<byte>) this.BuildDataFieldsRawPackage(1, this.RevisionsByFields[1]));
      return byteList.ToArray();
    }

    [Obsolete("Use Parse(byte[] package), this method will parse everything as ASCII, which will break packages above revision 1 because of byte fields")]
    public override Mid Parse(string package) => base.Parse(package);

    public override Mid Parse(byte[] package)
    {
      this.HeaderData = this.ProcessHeader(this.ToAscii(((IEnumerable<byte>) package).Take<byte>(20).ToArray<byte>()));
      if (this.HeaderData.Revision > 1)
      {
        int revision = this.HeaderData.Revision;
        for (int key = 2; key <= revision; ++key)
          this.ProcessDataFields(package, this.RevisionsByFields[key]);
      }
      else
        this.ProcessDataFields(package, this.RevisionsByFields[this.HeaderData.Revision]);
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
            new DataField(0, 20, 10, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(1, 32, 25, ' '),
            new DataField(2, 59, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(3, 64, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(4, 70, 1),
            new DataField(5, 73, 1),
            new DataField(6, 76, 1),
            new DataField(7, 79, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(8, 87, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(9, 94, 19),
            new DataField(10, 115, 1)
          }
        },
        {
          2,
          new List<DataField>()
          {
            new DataField(0, 20, 10, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(1, 32, 25, ' '),
            new DataField(11, 59, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(2, 65, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(12, 70, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(13, 74, 5),
            new DataField(14, 81, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(3, 87, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(4, 93, 1),
            new DataField(10, 96, 1),
            new DataField(5, 99, 1),
            new DataField(6, 102, 1),
            new DataField(15, 105, 1),
            new DataField(16, 108, 1),
            new DataField(17, 111, 1),
            new DataField(18, 114, 1),
            new DataField(19, 117, 1),
            new DataField(20, 120, 10),
            new DataField(7, 132, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(8, 140, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(21, 147, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(22, 154, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(23, 159, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(24, 167, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(25, 175, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(26, 182, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(27, 189, 14, ' '),
            new DataField(9, 205, 19)
          }
        },
        {
          3,
          new List<DataField>()
          {
            new DataField(28, 226, 1),
            new DataField(29, 229, 2, '0', DataField.PaddingOrientations.LEFT_PADDED)
          }
        },
        {
          4,
          new List<DataField>()
          {
            new DataField(30, 233, 25, ' '),
            new DataField(31, 260, 25, ' '),
            new DataField(32, 287, 25, ' ')
          }
        },
        {
          5,
          new List<DataField>() { new DataField(33, 314, 4, ' ') }
        },
        {
          6,
          new List<DataField>()
          {
            new DataField(34, 320, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(35, 328, 10, ' ')
          }
        }
      };
    }

    protected override void ProcessDataFields(string package)
    {
      if (this.HeaderData.Revision > 1)
      {
        int? nullable1 = new int?(this.HeaderData.Revision);
        int key = 2;
        while (true)
        {
          int num = key;
          int? nullable2 = nullable1;
          int valueOrDefault = nullable2.GetValueOrDefault();
          if (num <= valueOrDefault & nullable2.HasValue)
          {
            this.ProcessDataFields(package, this.RevisionsByFields[key]);
            ++key;
          }
          else
            break;
        }
      }
      else
        this.ProcessDataFields(package, this.RevisionsByFields[1]);
    }

    private void ProcessDataFields(byte[] package, List<DataField> fields)
    {
      foreach (DataField field in fields)
      {
        try
        {
          Enumerable.Empty<byte>();
          IEnumerable<byte> source = (IEnumerable<byte>) this.GetValue(field, package);
          if (this.IsByteField(field))
            field.RawValue = source.ToArray<byte>();
          else
            field.Value = this.ToAscii(source.ToArray<byte>());
        }
        catch (ArgumentOutOfRangeException ex)
        {
        }
      }
    }

    private int GetCurrentRevisionIndex() => this.HeaderData.Revision <= 1 ? 1 : 2;

    private void ProcessDataFields(string package, List<DataField> fields)
    {
      foreach (DataField field in fields)
        field.Value = this.GetValue(field, package);
    }

    private string BuildDataFieldsPackage(int prefixIndex, List<DataField> fields)
    {
      string str = string.Empty;
      foreach (DataField field in fields)
      {
        if (field.HasPrefix)
        {
          str = str + prefixIndex.ToString().PadLeft(2, '0') + field.Value;
          ++prefixIndex;
        }
        else
          str += field.Value;
      }
      return str;
    }

    private byte[] BuildDataFieldsRawPackage(int prefixIndex, List<DataField> fields)
    {
      List<byte> byteList = new List<byte>();
      foreach (DataField field in fields)
      {
        if (field.HasPrefix)
        {
          byte[] bytes = this.ToBytes(prefixIndex.ToString().PadLeft(2, '0'));
          byteList.AddRange((IEnumerable<byte>) bytes);
          ++prefixIndex;
        }
        if (this.IsByteField(field))
          byteList.AddRange((IEnumerable<byte>) field.RawValue);
        else
          byteList.AddRange((IEnumerable<byte>) this.ToBytes(field.Value));
      }
      return byteList.ToArray();
    }

    private bool IsByteField(DataField dataField)
    {
      Mid0065.DataFields field = (Mid0065.DataFields) dataField.Field;
      int num;
      switch (field)
      {
        case Mid0065.DataFields.STRATEGY_OPTIONS:
        case Mid0065.DataFields.TIGHTENING_ERROR_STATUS:
          num = 1;
          break;
        default:
          num = field == Mid0065.DataFields.TIGHTENING_ERROR_STATUS_2 ? 1 : 0;
          break;
      }
      return num != 0;
    }

    public enum DataFields
    {
      TIGHTENING_ID,
      VIN_NUMBER,
      PARAMETER_SET_ID,
      BATCH_COUNTER,
      TIGHTENING_STATUS,
      TORQUE_STATUS,
      ANGLE_STATUS,
      TORQUE,
      ANGLE,
      TIMESTAMP,
      BATCH_STATUS,
      JOB_ID,
      STRATEGY,
      STRATEGY_OPTIONS,
      BATCH_SIZE,
      RUNDOWN_ANGLE_STATUS,
      CURRENT_MONITORING_STATUS,
      SELFTAP_STATUS,
      PREVAIL_TORQUE_MONITORING_STATUS,
      PREVAIL_TORQUE_COMPENSATE_STATUS,
      TIGHTENING_ERROR_STATUS,
      RUNDOWN_ANGLE,
      CURRENT_MONITORING_VALUE,
      SELFTAP_TORQUE,
      PREVAIL_TORQUE,
      JOB_SEQUENCE_NUMBER,
      SYNC_TIGHTENING_ID,
      TOOL_SERIAL_NUMBER,
      TORQUE_VALUES_UNIT,
      RESULT_TYPE,
      IDENTIFIER_RESULT_PART_2,
      IDENTIFIER_RESULT_PART_3,
      IDENTIFIER_RESULT_PART_4,
      CUSTOMER_TIGHTENING_ERROR_CODE,
      PREVAIL_TORQUE_COMPENSATE_VALUE,
      TIGHTENING_ERROR_STATUS_2,
    }
  }
}
