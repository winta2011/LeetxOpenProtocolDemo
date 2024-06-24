
// Type: OpenProtocolInterpreter.MultiSpindle.Mid0101
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OpenProtocolInterpreter.MultiSpindle
{
  public class Mid0101 : Mid, IMultiSpindle, IController
  {
    private readonly IValueConverter<int> _intConverter;
    private readonly IValueConverter<bool> _boolConverter;
    private readonly IValueConverter<Decimal> _decimalConverter;
    private readonly IValueConverter<DateTime> _dateConverter;
    private readonly IValueConverter<IEnumerable<SpindleOrPressStatus>> _spindleOrPressStatusListConverter;
    private const int LAST_REVISION = 5;
    public const int MID = 101;

    public int NumberOfSpindlesOrPresses
    {
      get => this.GetField(1, 0).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 0).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public string VinNumber
    {
      get => this.GetField(1, 1).Value;
      set => this.GetField(1, 1).SetValue(value);
    }

    public int JobId
    {
      get => this.GetField(1, 2).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 2).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int ParameterSetId
    {
      get => this.GetField(1, 3).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 3).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int BatchSize
    {
      get => this.GetField(1, 4).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 4).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int BatchCounter
    {
      get => this.GetField(1, 5).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 5).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public BatchStatus BatchStatus
    {
      get
      {
        return (BatchStatus) this.GetField(1, 6).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 6).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public Decimal TorqueOrForceMinLimit
    {
      get
      {
        return this.GetField(1, 7).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(1, 7).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public Decimal TorqueOrForceMaxLimit
    {
      get
      {
        return this.GetField(1, 8).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(1, 8).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public Decimal TorqueOrForceFinalTarget
    {
      get
      {
        return this.GetField(1, 9).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(1, 9).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public Decimal AngleOrStrokeMinLimit
    {
      get
      {
        return this.GetField(1, 10).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(1, 10).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public Decimal AngleOrStrokeMaxLimit
    {
      get
      {
        return this.GetField(1, 11).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(1, 11).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public Decimal FinalAngleOrStrokeTarget
    {
      get
      {
        return this.GetField(1, 12).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(1, 12).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public DateTime LastChangeInParameterSet
    {
      get
      {
        return this.GetField(1, 14).GetValue<DateTime>(new Func<string, DateTime>(this._dateConverter.Convert));
      }
      set
      {
        this.GetField(1, 14).SetValue<DateTime>(new Func<char, int, DataField.PaddingOrientations, DateTime, string>(this._dateConverter.Convert), value);
      }
    }

    public DateTime TimeStamp
    {
      get
      {
        return this.GetField(1, 15).GetValue<DateTime>(new Func<string, DateTime>(this._dateConverter.Convert));
      }
      set
      {
        this.GetField(1, 15).SetValue<DateTime>(new Func<char, int, DataField.PaddingOrientations, DateTime, string>(this._dateConverter.Convert), value);
      }
    }

    public int SyncTighteningId
    {
      get => this.GetField(1, 16).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 16).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public bool SyncOverallStatus
    {
      get
      {
        return this.GetField(1, 17).GetValue<bool>(new Func<string, bool>(this._boolConverter.Convert));
      }
      set
      {
        this.GetField(1, 17).SetValue<bool>(new Func<char, int, DataField.PaddingOrientations, bool, string>(this._boolConverter.Convert), value);
      }
    }

    public List<SpindleOrPressStatus> SpindlesOrPressesStatus { get; set; }

    public SystemSubType SystemSubType
    {
      get
      {
        return (SystemSubType) this.GetField(4, 19).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(4, 19).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public int JobSequenceNumber
    {
      get => this.GetField(5, 20).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(5, 20).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public Mid0101()
      : this(5)
    {
    }

    public Mid0101(int revision = 5)
      : base(101, revision)
    {
      this._boolConverter = (IValueConverter<bool>) new BoolConverter();
      this._intConverter = (IValueConverter<int>) new Int32Converter();
      this._dateConverter = (IValueConverter<DateTime>) new DateConverter();
      this._decimalConverter = (IValueConverter<Decimal>) new DecimalTrucatedConverter(2);
      this._spindleOrPressStatusListConverter = (IValueConverter<IEnumerable<SpindleOrPressStatus>>) new SpindleOrPressStatusListConverter(this._intConverter, this._boolConverter, this._decimalConverter);
    }

    public override string Pack()
    {
      DataField field = this.GetField(1, 18);
      field.Size = this.SpindlesOrPressesStatus.Count * 18;
      field.Value = this._spindleOrPressStatusListConverter.Convert((IEnumerable<SpindleOrPressStatus>) this.SpindlesOrPressesStatus);
      return base.Pack();
    }

    public override Mid Parse(string package)
    {
      this.HeaderData = this.ProcessHeader(package);
      DataField field1 = this.GetField(1, 0);
      int num = this._intConverter.Convert(package.Substring(field1.Index + 2, field1.Size));
      DataField field2 = this.GetField(1, 18);
      field2.Size = num * 18;
      if (this.HeaderData.Revision > 3)
      {
        DataField field3 = this.GetField(4, 19);
        field3.Index = field2.Index + field2.Size + 2;
        if (this.HeaderData.Revision > 4)
          this.GetField(5, 20).Index = field3.Index + field3.Size + 2;
      }
      this.ProcessDataFields(package);
      this.SpindlesOrPressesStatus = this._spindleOrPressStatusListConverter.Convert(field2.Value).ToList<SpindleOrPressStatus>();
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
            new DataField(1, 24, 25, ' '),
            new DataField(2, 51, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(3, 55, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(4, 60, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(5, 66, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(6, 72, 1),
            new DataField(7, 75, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(8, 83, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(9, 91, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(10, 99, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(11, 106, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(12, 113, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(14, 120, 19),
            new DataField(15, 141, 19),
            new DataField(16, 162, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(17, 169, 1),
            new DataField(18, 172, 0)
          }
        },
        {
          2,
          new List<DataField>()
        },
        {
          3,
          new List<DataField>()
        },
        {
          4,
          new List<DataField>()
          {
            new DataField(19, 0, 3, '0', DataField.PaddingOrientations.LEFT_PADDED)
          }
        },
        {
          5,
          new List<DataField>()
          {
            new DataField(20, 0, 5, '0', DataField.PaddingOrientations.LEFT_PADDED)
          }
        }
      };
    }

    public enum DataFields
    {
      NUMBER_OF_SPINDLES_OR_PRESSES,
      VIN_NUMBER,
      JOB_ID,
      PARAMETER_SET_ID,
      BATCH_SIZE,
      BATCH_COUNTER,
      BATCH_STATUS,
      TORQUE_OR_FORCE_MIN_LIMIT,
      TORQUE_OR_FORCE_MAX_LIMIT,
      TORQUE_OR_FORCE_FINAL_TARGET,
      ANGLE_OR_STROKE_MIN_LIMIT,
      ANGLE_OR_STROKE_MAX_LIMIT,
      FINAL_ANGLE_OR_STROKE_TARGET,
      TARGET,
      LAST_CHANGE_IN_PARAMETER_SET,
      TIMESTAMP,
      SYNC_TIGHTENING_ID,
      SYNC_OVERALL_STATUS,
      SPINDLES_OR_PRESSES_STATUS,
      SYSTEM_SUB_TYPE,
      JOB_SEQUENCE_NUMBER,
    }
  }
}
