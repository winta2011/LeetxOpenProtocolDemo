
// Type: OpenProtocolInterpreter.MultiSpindle.Mid0091
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OpenProtocolInterpreter.MultiSpindle
{
  public class Mid0091 : Mid, IMultiSpindle, IController
  {
    private readonly IValueConverter<int> _intConverter;
    private readonly IValueConverter<bool> _boolConverter;
    private readonly IValueConverter<DateTime> _dateConverter;
    private readonly IValueConverter<IEnumerable<SpindleStatus>> _spindlesStatusConverter;
    private const int LAST_REVISION = 1;
    public const int MID = 91;

    public int NumberOfSpindles
    {
      get => this.GetField(1, 0).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 0).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int SyncTighteningId
    {
      get => this.GetField(1, 1).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 1).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public DateTime Time
    {
      get
      {
        return this.GetField(1, 2).GetValue<DateTime>(new Func<string, DateTime>(this._dateConverter.Convert));
      }
      set
      {
        this.GetField(1, 2).SetValue<DateTime>(new Func<char, int, DataField.PaddingOrientations, DateTime, string>(this._dateConverter.Convert), value);
      }
    }

    public bool SyncOverallStatus
    {
      get
      {
        return this.GetField(1, 3).GetValue<bool>(new Func<string, bool>(this._boolConverter.Convert));
      }
      set
      {
        this.GetField(1, 3).SetValue<bool>(new Func<char, int, DataField.PaddingOrientations, bool, string>(this._boolConverter.Convert), value);
      }
    }

    public List<SpindleStatus> SpindlesStatus { get; set; }

    public Mid0091()
      : this(new int?(0))
    {
    }

    public Mid0091(int? noAckFlag = 0)
      : base(91, 1, noAckFlag)
    {
      this._intConverter = (IValueConverter<int>) new Int32Converter();
      this._boolConverter = (IValueConverter<bool>) new BoolConverter();
      this._dateConverter = (IValueConverter<DateTime>) new DateConverter();
      this._spindlesStatusConverter = (IValueConverter<IEnumerable<SpindleStatus>>) new SpindleStatusConverter(this._intConverter, this._boolConverter);
      if (this.SpindlesStatus != null)
        return;
      this.SpindlesStatus = new List<SpindleStatus>();
    }

    public Mid0091(
      int numberOfSpindles,
      int syncTighteningId,
      DateTime time,
      bool syncOverallStatus,
      IEnumerable<SpindleStatus> spindleStatus,
      int? noAckFlag = 0)
      : this(noAckFlag)
    {
      this.NumberOfSpindles = numberOfSpindles;
      this.SyncTighteningId = syncTighteningId;
      this.Time = time;
      this.SpindlesStatus = spindleStatus.ToList<SpindleStatus>();
    }

    public override string Pack()
    {
      this.GetField(1, 4).Value = this._spindlesStatusConverter.Convert((IEnumerable<SpindleStatus>) this.SpindlesStatus);
      return base.Pack();
    }

    public override Mid Parse(string package)
    {
      DataField field = this.GetField(1, 4);
      field.Size = package.Length - field.Index - 2;
      base.Parse(package);
      this.SpindlesStatus = this._spindlesStatusConverter.Convert(field.Value).ToList<SpindleStatus>();
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
            new DataField(1, 24, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(2, 31, 19),
            new DataField(3, 52, 1),
            new DataField(4, 55, 5)
          }
        }
      };
    }

    public enum DataFields
    {
      NUMBER_OF_SPINDLES,
      SYNC_TIGHTENING_ID,
      TIME,
      SYNC_OVERALL_STATUS,
      SPINDLE_STATUS,
    }
  }
}
