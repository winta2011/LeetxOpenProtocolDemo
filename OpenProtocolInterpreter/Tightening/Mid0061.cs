
// Type: OpenProtocolInterpreter.Tightening.Mid0061
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OpenProtocolInterpreter.Tightening
{
  public class Mid0061 : Mid, ITightening, IController
  {
    private readonly IValueConverter<int> _intConverter;
    private readonly IValueConverter<long> _longConverter;
    private readonly IValueConverter<bool> _boolConverter;
    private readonly IValueConverter<Decimal> _decimalConverter;
    private readonly IValueConverter<DateTime> _dateConverter;
    private readonly IValueConverter<StrategyOptions> _strategyOptionsConverter;
    private readonly IValueConverter<TighteningErrorStatus> _tighteningErrorStatusConverter;
    private readonly IValueConverter<TighteningErrorStatus2> _tighteningErrorStatus2Converter;
    private readonly IValueConverter<IEnumerable<StageResult>> _stageResultListConverter;
    private const int LAST_REVISION = 7;
    public const int MID = 61;

    public int CellId
    {
      get
      {
        return this.GetField(this.GetCurrentRevisionIndex(), 0).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(this.GetCurrentRevisionIndex(), 0).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int ChannelId
    {
      get
      {
        return this.GetField(this.GetCurrentRevisionIndex(), 1).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(this.GetCurrentRevisionIndex(), 1).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public string TorqueControllerName
    {
      get => this.GetField(this.GetCurrentRevisionIndex(), 2).Value;
      set => this.GetField(this.GetCurrentRevisionIndex(), 2).SetValue(value);
    }

    public string VinNumber
    {
      get => this.GetField(this.GetCurrentRevisionIndex(), 3).Value;
      set => this.GetField(this.GetCurrentRevisionIndex(), 3).SetValue(value);
    }

    public int JobId
    {
      get
      {
        return this.GetField(this.GetCurrentRevisionIndex(), 4).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(this.GetCurrentRevisionIndex(), 4).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int ParameterSetId
    {
      get
      {
        return this.GetField(this.GetCurrentRevisionIndex(), 5).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(this.GetCurrentRevisionIndex(), 5).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int BatchSize
    {
      get
      {
        return this.GetField(this.GetCurrentRevisionIndex(), 6).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(this.GetCurrentRevisionIndex(), 6).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int BatchCounter
    {
      get
      {
        return this.GetField(this.GetCurrentRevisionIndex(), 7).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(this.GetCurrentRevisionIndex(), 7).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public bool TighteningStatus
    {
      get
      {
        return this.GetField(this.GetCurrentRevisionIndex(), 8).GetValue<bool>(new Func<string, bool>(this._boolConverter.Convert));
      }
      set
      {
        this.GetField(this.GetCurrentRevisionIndex(), 8).SetValue<bool>(new Func<char, int, DataField.PaddingOrientations, bool, string>(this._boolConverter.Convert), value);
      }
    }

    public TighteningValueStatus TorqueStatus
    {
      get
      {
        return (TighteningValueStatus) this.GetField(this.GetCurrentRevisionIndex(), 9).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(this.GetCurrentRevisionIndex(), 9).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public TighteningValueStatus AngleStatus
    {
      get
      {
        return (TighteningValueStatus) this.GetField(this.GetCurrentRevisionIndex(), 10).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(this.GetCurrentRevisionIndex(), 10).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public Decimal TorqueMinLimit
    {
      get
      {
        return this.GetField(this.GetCurrentRevisionIndex(), 11).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(this.GetCurrentRevisionIndex(), 11).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public Decimal TorqueMaxLimit
    {
      get
      {
        return this.GetField(this.GetCurrentRevisionIndex(), 12).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(this.GetCurrentRevisionIndex(), 12).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public Decimal TorqueFinalTarget
    {
      get
      {
        return this.GetField(this.GetCurrentRevisionIndex(), 13).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(this.GetCurrentRevisionIndex(), 13).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public Decimal Torque
    {
      get
      {
        return this.GetField(this.GetCurrentRevisionIndex(), 14).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(this.GetCurrentRevisionIndex(), 14).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public int AngleMinLimit
    {
      get
      {
        return this.GetField(this.GetCurrentRevisionIndex(), 15).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(this.GetCurrentRevisionIndex(), 15).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int AngleMaxLimit
    {
      get
      {
        return this.GetField(this.GetCurrentRevisionIndex(), 16).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(this.GetCurrentRevisionIndex(), 16).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int AngleFinalTarget
    {
      get
      {
        return this.GetField(this.GetCurrentRevisionIndex(), 17).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(this.GetCurrentRevisionIndex(), 17).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int Angle
    {
      get
      {
        return this.GetField(this.GetCurrentRevisionIndex(), 18).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(this.GetCurrentRevisionIndex(), 18).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public DateTime Timestamp
    {
      get
      {
        return this.GetField(this.GetCurrentRevisionIndex(), 19).GetValue<DateTime>(new Func<string, DateTime>(this._dateConverter.Convert));
      }
      set
      {
        this.GetField(this.GetCurrentRevisionIndex(), 19).SetValue<DateTime>(new Func<char, int, DataField.PaddingOrientations, DateTime, string>(this._dateConverter.Convert), value);
      }
    }

    public DateTime LastChangeInParameterSet
    {
      get
      {
        return this.GetField(this.GetCurrentRevisionIndex(), 20).GetValue<DateTime>(new Func<string, DateTime>(this._dateConverter.Convert));
      }
      set
      {
        this.GetField(this.GetCurrentRevisionIndex(), 20).SetValue<DateTime>(new Func<char, int, DataField.PaddingOrientations, DateTime, string>(this._dateConverter.Convert), value);
      }
    }

    public BatchStatus BatchStatus
    {
      get
      {
        return (BatchStatus) this.GetField(this.GetCurrentRevisionIndex(), 21).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(this.GetCurrentRevisionIndex(), 21).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public long TighteningId
    {
      get
      {
        return this.GetField(this.GetCurrentRevisionIndex(), 22).GetValue<long>(new Func<string, long>(this._longConverter.Convert));
      }
      set
      {
        this.GetField(this.GetCurrentRevisionIndex(), 22).SetValue<long>(new Func<char, int, DataField.PaddingOrientations, long, string>(this._longConverter.Convert), value);
      }
    }

    public Strategy Strategy
    {
      get
      {
        return (Strategy) this.GetField(2, 23).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(2, 23).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public StrategyOptions StrategyOptions
    {
      get
      {
        return this.GetField(2, 24).GetValue<StrategyOptions>(new Func<byte[], StrategyOptions>(this._strategyOptionsConverter.ConvertFromBytes));
      }
      set
      {
        this.GetField(2, 24).SetRawValue<StrategyOptions>(new Func<char, int, DataField.PaddingOrientations, StrategyOptions, byte[]>(this._strategyOptionsConverter.ConvertToBytes), value);
      }
    }

    public TighteningValueStatus RundownAngleStatus
    {
      get
      {
        return (TighteningValueStatus) this.GetField(2, 25).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(2, 25).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public TighteningValueStatus CurrentMonitoringStatus
    {
      get
      {
        return (TighteningValueStatus) this.GetField(2, 26).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(2, 26).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public TighteningValueStatus SelftapStatus
    {
      get
      {
        return (TighteningValueStatus) this.GetField(2, 27).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(2, 27).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public TighteningValueStatus PrevailTorqueMonitoringStatus
    {
      get
      {
        return (TighteningValueStatus) this.GetField(2, 28).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(2, 28).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public TighteningValueStatus PrevailTorqueCompensateStatus
    {
      get
      {
        return (TighteningValueStatus) this.GetField(2, 29).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(2, 29).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public TighteningErrorStatus TighteningErrorStatus
    {
      get
      {
        return this.GetField(2, 30).GetValue<TighteningErrorStatus>(new Func<byte[], TighteningErrorStatus>(this._tighteningErrorStatusConverter.ConvertFromBytes));
      }
      set
      {
        this.GetField(2, 30).SetRawValue<TighteningErrorStatus>(new Func<char, int, DataField.PaddingOrientations, TighteningErrorStatus, byte[]>(this._tighteningErrorStatusConverter.ConvertToBytes), value);
      }
    }

    public int RundownAngleMin
    {
      get => this.GetField(2, 31).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(2, 31).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int RundownAngleMax
    {
      get => this.GetField(2, 32).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(2, 32).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int RundownAngle
    {
      get => this.GetField(2, 33).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(2, 33).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int CurrentMonitoringMin
    {
      get => this.GetField(2, 34).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(2, 34).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int CurrentMonitoringMax
    {
      get => this.GetField(2, 35).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(2, 35).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int CurrentMonitoringValue
    {
      get => this.GetField(2, 36).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(2, 36).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public Decimal SelftapMin
    {
      get
      {
        return this.GetField(2, 37).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(2, 37).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public Decimal SelftapMax
    {
      get
      {
        return this.GetField(2, 38).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(2, 38).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public Decimal SelftapTorque
    {
      get
      {
        return this.GetField(2, 39).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(2, 39).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public Decimal PrevailTorqueMonitoringMin
    {
      get
      {
        return this.GetField(2, 40).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(2, 40).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public Decimal PrevailTorqueMonitoringMax
    {
      get
      {
        return this.GetField(2, 41).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(2, 41).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public Decimal PrevailTorque
    {
      get
      {
        return this.GetField(2, 42).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(2, 42).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public int JobSequenceNumber
    {
      get => this.GetField(2, 43).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(2, 43).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int SyncTighteningId
    {
      get => this.GetField(2, 44).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(2, 44).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public string ToolSerialNumber
    {
      get => this.GetField(2, 45).Value;
      set => this.GetField(2, 45).SetValue(value);
    }

    public string ParameterSetName
    {
      get => this.GetField(3, 46).Value;
      set => this.GetField(3, 46).SetValue(value);
    }

    public TorqueValuesUnit TorqueValuesUnit
    {
      get
      {
        return (TorqueValuesUnit) this.GetField(3, 47).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(3, 47).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public ResultType ResultType
    {
      get
      {
        return (ResultType) this.GetField(3, 48).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(3, 48).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public string IdentifierResultPart2
    {
      get => this.GetField(4, 49).Value;
      set => this.GetField(4, 49).SetValue(value);
    }

    public string IdentifierResultPart3
    {
      get => this.GetField(4, 50).Value;
      set => this.GetField(4, 50).SetValue(value);
    }

    public string IdentifierResultPart4
    {
      get => this.GetField(4, 51).Value;
      set => this.GetField(4, 51).SetValue(value);
    }

    public string CustomerTighteningErrorCode
    {
      get => this.GetField(5, 52).Value;
      set => this.GetField(5, 52).SetValue(value);
    }

    public Decimal PrevailTorqueCompensateValue
    {
      get
      {
        return this.GetField(6, 53).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(6, 53).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public TighteningErrorStatus2 TighteningErrorStatus2
    {
      get
      {
        return this.GetField(6, 54).GetValue<TighteningErrorStatus2>(new Func<byte[], TighteningErrorStatus2>(this._tighteningErrorStatus2Converter.ConvertFromBytes));
      }
      set
      {
        this.GetField(6, 54).SetRawValue<TighteningErrorStatus2>(new Func<char, int, DataField.PaddingOrientations, TighteningErrorStatus2, byte[]>(this._tighteningErrorStatus2Converter.ConvertToBytes), value);
      }
    }

    public Decimal CompensatedAngle
    {
      get
      {
        return this.GetField(7, 55).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(7, 55).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public Decimal FinalAngleDecimal
    {
      get
      {
        return this.GetField(7, 56).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(7, 56).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public int NumberOfStagesInMultistage
    {
      get
      {
        return this.GetField(998, 57).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(998, 57).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int NumberOfStageResults
    {
      get
      {
        return this.GetField(998, 58).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(998, 58).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public List<StageResult> StageResults { get; set; }

    public Mid0061()
      : this(7)
    {
    }

    public Mid0061(int revision = 7)
      : base(61, revision)
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
      this._stageResultListConverter = (IValueConverter<IEnumerable<StageResult>>) new StageResultListConverter(this._intConverter, this._decimalConverter);
    }

    protected override string BuildHeader()
    {
      if (this.RevisionsByFields.Any<KeyValuePair<int, List<DataField>>>())
      {
        this.HeaderData.Length = 20;
        this.HeaderData.Revision = this.HeaderData.Revision > 0 ? this.HeaderData.Revision : 1;
        if (this.HeaderData.Revision == 1 || this.HeaderData.Revision == 999)
        {
          foreach (DataField dataField in this.RevisionsByFields[this.HeaderData.Revision])
            this.HeaderData.Length += (dataField.HasPrefix ? 2 : 0) + dataField.Size;
        }
        else
        {
          int num = this.HeaderData.Revision != 998 ? this.HeaderData.Revision : 6;
          for (int key = 2; key <= num; ++key)
          {
            foreach (DataField dataField in this.RevisionsByFields[key])
              this.HeaderData.Length += (dataField.HasPrefix ? 2 : 0) + dataField.Size;
          }
          if (this.HeaderData.Revision == 998)
          {
            this.GetField(998, 59).Size = this.StageResults.Count * 11;
            foreach (DataField dataField in this.RevisionsByFields[998])
              this.HeaderData.Length += (dataField.HasPrefix ? 2 : 0) + dataField.Size;
          }
        }
      }
      return this.HeaderData.ToString();
    }

    public override string Pack()
    {
      string empty = string.Empty;
      string str;
      if (this.HeaderData.Revision > 1 && this.HeaderData.Revision != 999)
      {
        DataField field1 = this.GetField(2, 24);
        field1.SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), System.BitConverter.ToInt32(field1.RawValue, 0));
        DataField field2 = this.GetField(2, 30);
        field2.SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), System.BitConverter.ToInt32(field2.RawValue, 0));
        if (this.HeaderData.Revision > 5)
        {
          DataField field3 = this.GetField(6, 54);
          field3.RawValue = System.BitConverter.GetBytes(this._intConverter.Convert(field3.Value));
        }
        if (this.HeaderData.Revision == 998)
        {
          this.NumberOfStageResults = this.StageResults.Count;
          DataField field4 = this.GetField(998, 59);
          field4.Size = this.StageResults.Count * 11;
          field4.SetValue(this._stageResultListConverter.Convert((IEnumerable<StageResult>) this.StageResults));
        }
        str = this.BuildHeader();
        int num = this.HeaderData.Revision != 998 ? this.HeaderData.Revision : 6;
        int prefixIndex = 1;
        for (int key = 2; key <= num; ++key)
        {
          str += this.BuildDataFieldsPackage(prefixIndex, this.RevisionsByFields[key]);
          prefixIndex += this.RevisionsByFields[key].Count<DataField>((Func<DataField, bool>) (x => x.HasPrefix));
        }
        if (this.HeaderData.Revision == 998)
          str += this.BuildDataFieldsPackage(56, this.RevisionsByFields[998]);
      }
      else
        str = this.BuildHeader() + this.BuildDataFieldsPackage(1, this.RevisionsByFields[this.HeaderData.Revision]);
      return str;
    }

    public override byte[] PackBytes()
    {
      List<byte> byteList = new List<byte>();
      byteList.AddRange((IEnumerable<byte>) this.BuildRawHeader());
      if (this.HeaderData.Revision == 1 || this.HeaderData.Revision == 999)
      {
        byte[] bytes = this.ToBytes(this.BuildDataFieldsPackage(1, this.RevisionsByFields[this.HeaderData.Revision]));
        byteList.AddRange((IEnumerable<byte>) bytes);
      }
      else
      {
        int num = this.HeaderData.Revision != 998 ? this.HeaderData.Revision : 6;
        int prefixIndex = 1;
        for (int key = 2; key <= num; ++key)
        {
          byte[] collection = this.BuildDataFieldsRawPackage(prefixIndex, this.RevisionsByFields[key]);
          byteList.AddRange((IEnumerable<byte>) collection);
          prefixIndex += this.RevisionsByFields[key].Count<DataField>((Func<DataField, bool>) (x => x.HasPrefix));
        }
        if (this.HeaderData.Revision == 998)
        {
          this.NumberOfStageResults = this.StageResults.Count;
          this.GetField(998, 59).SetValue(this._stageResultListConverter.Convert((IEnumerable<StageResult>) this.StageResults));
          byte[] collection = this.BuildDataFieldsRawPackage(prefixIndex, this.RevisionsByFields[998]);
          byteList.AddRange((IEnumerable<byte>) collection);
        }
      }
      return byteList.ToArray();
    }

    public override Mid Parse(string package)
    {
      base.Parse(package);
      if (this.HeaderData.Revision > 1 && this.HeaderData.Revision != 999)
      {
        DataField field1 = this.GetField(2, 24);
        field1.RawValue = System.BitConverter.GetBytes(this._intConverter.Convert(field1.Value));
        DataField field2 = this.GetField(2, 30);
        field2.RawValue = System.BitConverter.GetBytes(this._intConverter.Convert(field2.Value));
        if (this.HeaderData.Revision > 5)
        {
          DataField field3 = this.GetField(6, 54);
          field3.RawValue = System.BitConverter.GetBytes(this._intConverter.Convert(field3.Value));
        }
        if (this.HeaderData.Revision == 998)
          this.StageResults = this._stageResultListConverter.Convert(this.GetField(998, 59).Value).ToList<StageResult>();
      }
      return (Mid) this;
    }

    public override Mid Parse(byte[] package)
    {
      this.HeaderData = this.ProcessHeader(this.ToAscii(((IEnumerable<byte>) package).Take<byte>(20).ToArray<byte>()));
      if (this.HeaderData.Revision == 1 || this.HeaderData.Revision == 999)
      {
        this.ProcessDataFields(package, this.RevisionsByFields[this.HeaderData.Revision]);
      }
      else
      {
        int num = this.HeaderData.Revision;
        if (this.HeaderData.Revision == 998)
        {
          num = 6;
          DataField field = this.GetField(998, 59);
          field.Size = package.Length - field.Index - 2;
          this.ProcessDataFields(package, this.RevisionsByFields[998]);
          this.StageResults = this._stageResultListConverter.Convert(field.Value).ToList<StageResult>();
        }
        for (int key = 2; key <= num; ++key)
          this.ProcessDataFields(package, this.RevisionsByFields[key]);
      }
      return (Mid) this;
    }

    protected override void ProcessDataFields(string package)
    {
      if (this.HeaderData.Revision == 1 || this.HeaderData.Revision == 999)
      {
        this.ProcessDataFields(this.RevisionsByFields[this.HeaderData.Revision], package);
      }
      else
      {
        int num = this.HeaderData.Revision;
        if (this.HeaderData.Revision == 998)
        {
          num = 6;
          DataField field = this.GetField(998, 59);
          field.Size = package.Length - field.Index - 2;
          this.ProcessDataFields(this.RevisionsByFields[998], package);
        }
        for (int key = 2; key <= num; ++key)
          this.ProcessDataFields(this.RevisionsByFields[key], package);
      }
    }

    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
      return new Dictionary<int, List<DataField>>()
      {
        {
          1,
          new List<DataField>()
          {
            new DataField(0, 20, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(1, 26, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(2, 30, 25, ' '),
            new DataField(3, 57, 25, ' '),
            new DataField(4, 84, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(5, 88, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(6, 93, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(7, 99, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(8, 105, 1),
            new DataField(9, 108, 1),
            new DataField(10, 111, 1),
            new DataField(11, 114, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(12, 122, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(13, 130, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(14, 138, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(15, 146, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(16, 153, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(17, 160, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(18, 167, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(19, 174, 19),
            new DataField(20, 195, 19),
            new DataField(21, 216, 1),
            new DataField(22, 219, 10, '0', DataField.PaddingOrientations.LEFT_PADDED)
          }
        },
        {
          2,
          new List<DataField>()
          {
            new DataField(0, 20, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(1, 26, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(2, 30, 25, ' '),
            new DataField(3, 57, 25, ' '),
            new DataField(4, 84, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(5, 90, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(23, 95, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(24, 99, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(6, 106, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(7, 112, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(8, 118, 1),
            new DataField(21, 121, 1),
            new DataField(9, 124, 1),
            new DataField(10, (int) sbyte.MaxValue, 1),
            new DataField(25, 130, 1),
            new DataField(26, 133, 1),
            new DataField(27, 136, 1),
            new DataField(28, 139, 1),
            new DataField(29, 142, 1),
            new DataField(30, 145, 10, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(11, 157, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(12, 165, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(13, 173, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(14, 181, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(15, 189, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(16, 196, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(17, 203, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(18, 210, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(31, 217, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(32, 224, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(33, 231, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(34, 238, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(35, 243, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(36, 248, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(37, 253, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(38, 261, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(39, 269, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(40, 277, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(41, 285, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(42, 293, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(22, 301, 10, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(43, 313, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(44, 320, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(45, 327, 14, ' '),
            new DataField(19, 343, 19),
            new DataField(20, 364, 19)
          }
        },
        {
          3,
          new List<DataField>()
          {
            new DataField(46, 385, 25, ' '),
            new DataField(47, 412, 1),
            new DataField(48, 415, 2, '0', DataField.PaddingOrientations.LEFT_PADDED)
          }
        },
        {
          4,
          new List<DataField>()
          {
            new DataField(49, 419, 25, ' '),
            new DataField(50, 446, 25, ' '),
            new DataField(51, 473, 25, ' ')
          }
        },
        {
          5,
          new List<DataField>() { new DataField(52, 500, 4, ' ') }
        },
        {
          6,
          new List<DataField>()
          {
            new DataField(53, 506, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(54, 514, 10, '0', DataField.PaddingOrientations.LEFT_PADDED)
          }
        },
        {
          7,
          new List<DataField>()
          {
            new DataField(55, 526, 7, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(56, 535, 7, '0', DataField.PaddingOrientations.LEFT_PADDED)
          }
        },
        {
          998,
          new List<DataField>()
          {
            new DataField(57, 526, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(58, 530, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(59, 534, 11)
          }
        },
        {
          999,
          new List<DataField>()
          {
            new DataField(3, 20, 25, ' ', hasPrefix: false),
            new DataField(4, 45, 2, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
            new DataField(5, 47, 3, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
            new DataField(6, 50, 4, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
            new DataField(7, 54, 4, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
            new DataField(21, 58, 1, false),
            new DataField(8, 59, 1, false),
            new DataField(9, 60, 1, false),
            new DataField(10, 61, 1, false),
            new DataField(14, 62, 6, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
            new DataField(18, 68, 5, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
            new DataField(19, 73, 19, false),
            new DataField(20, 92, 19, false),
            new DataField(22, 111, 10, '0', DataField.PaddingOrientations.LEFT_PADDED, false)
          }
        }
      };
    }

    private int GetCurrentRevisionIndex()
    {
      if (this.HeaderData.Revision == 999)
        return 999;
      return this.HeaderData.Revision > 1 ? 2 : 1;
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
      Mid0061.DataFields field = (Mid0061.DataFields) dataField.Field;
      int num;
      switch (field)
      {
        case Mid0061.DataFields.STRATEGY_OPTIONS:
        case Mid0061.DataFields.TIGHTENING_ERROR_STATUS:
          num = 1;
          break;
        default:
          num = field == Mid0061.DataFields.TIGHTENING_ERROR_STATUS_2 ? 1 : 0;
          break;
      }
      return num != 0;
    }

    public enum DataFields
    {
      CELL_ID,
      CHANNEL_ID,
      TORQUE_CONTROLLER_NAME,
      VIN_NUMBER,
      JOB_ID,
      PARAMETER_SET_ID,
      BATCH_SIZE,
      BATCH_COUNTER,
      TIGHTENING_STATUS,
      TORQUE_STATUS,
      ANGLE_STATUS,
      TORQUE_MIN_LIMIT,
      TORQUE_MAX_LIMIT,
      TORQUE_FINAL_TARGET,
      TORQUE,
      ANGLE_MIN_LIMIT,
      ANGLE_MAX_LIMIT,
      ANGLE_FINAL_TARGET,
      ANGLE,
      TIMESTAMP,
      LAST_CHANGE_IN_PARAMETER_SET,
      BATCH_STATUS,
      TIGHTENING_ID,
      STRATEGY,
      STRATEGY_OPTIONS,
      RUNDOWN_ANGLE_STATUS,
      CURRENT_MONITORING_STATUS,
      SELFTAP_STATUS,
      PREVAIL_TORQUE_MONITORING_STATUS,
      PREVAIL_TORQUE_COMPENSATE_STATUS,
      TIGHTENING_ERROR_STATUS,
      RUNDOWN_ANGLE_MIN,
      RUNDOWN_ANGLE_MAX,
      RUNDOWN_ANGLE,
      CURRENT_MONITORING_MIN,
      CURRENT_MONITORING_MAX,
      CURRENT_MONITORING_VALUE,
      SELFTAP_MIN,
      SELFTAP_MAX,
      SELFTAP_TORQUE,
      PREVAIL_TORQUE_MONITORING_MIN,
      PREVAIL_TORQUE_MONITORING_MAX,
      PREVAIL_TORQUE,
      JOB_SEQUENCE_NUMBER,
      SYNC_TIGHTENING_ID,
      TOOL_SERIAL_NUMBER,
      PARAMETER_SET_NAME,
      TORQUE_VALUES_UNIT,
      RESULT_TYPE,
      IDENTIFIER_RESULT_PART_2,
      IDENTIFIER_RESULT_PART_3,
      IDENTIFIER_RESULT_PART_4,
      CUSTOMER_TIGHTENING_ERROR_CODE,
      PREVAIL_TORQUE_COMPENSATE_VALUE,
      TIGHTENING_ERROR_STATUS_2,
      COMPENSATED_ANGLE,
      FINAL_ANGLE_DECIMAL,
      NUMBER_OF_STAGES_IN_MULTISTAGE,
      NUMBER_OF_STAGE_RESULTS,
      STAGE_RESULT,
    }
  }
}
