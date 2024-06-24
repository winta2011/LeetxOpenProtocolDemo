
// Type: OpenProtocolInterpreter.PowerMACS.Mid0106
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OpenProtocolInterpreter.PowerMACS
{
  public class Mid0106 : Mid, IPowerMACS, IController
  {
    private readonly IValueConverter<int> _intConverter;
    private readonly IValueConverter<bool> _boolConverter;
    private readonly IValueConverter<Decimal> _decimalConverter;
    private readonly IValueConverter<DateTime> _dateConverter;
    private IValueConverter<IEnumerable<BoltData>> _boltDataListConverter;
    private IValueConverter<IEnumerable<SpecialValue>> _specialValueListConverter;
    private const int LAST_REVISION = 4;
    public const int MID = 106;

    public int TotalNumberOfMessages
    {
      get => this.GetField(1, 0).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 0).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int MessageNumber
    {
      get => this.GetField(1, 1).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 1).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int DataNumberSystem
    {
      get => this.GetField(1, 2).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 2).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int StationNumber
    {
      get => this.GetField(1, 3).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 3).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public string StationName
    {
      get => this.GetField(1, 4).Value;
      set => this.GetField(1, 4).SetValue(value);
    }

    public DateTime Time
    {
      get
      {
        return this.GetField(1, 5).GetValue<DateTime>(new Func<string, DateTime>(this._dateConverter.Convert));
      }
      set
      {
        this.GetField(1, 5).SetValue<DateTime>(new Func<char, int, DataField.PaddingOrientations, DateTime, string>(this._dateConverter.Convert), value);
      }
    }

    public int ModeNumber
    {
      get => this.GetField(1, 6).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 6).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public string ModeName
    {
      get => this.GetField(1, 7).Value;
      set => this.GetField(1, 7).SetValue(value);
    }

    public bool SimpleStatus
    {
      get
      {
        return this.GetField(1, 8).GetValue<bool>(new Func<string, bool>(this._boolConverter.Convert));
      }
      set
      {
        this.GetField(1, 8).SetValue<bool>(new Func<char, int, DataField.PaddingOrientations, bool, string>(this._boolConverter.Convert), value);
      }
    }

    public PowerMacsStatus PMStatus
    {
      get
      {
        return (PowerMacsStatus) this.GetField(1, 9).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 9).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public string WpId
    {
      get => this.GetField(1, 10).Value;
      set => this.GetField(1, 10).SetValue(value);
    }

    public int NumberOfBolts
    {
      get => this.GetField(1, 11).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      private set
      {
        this.GetField(1, 11).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public List<BoltData> BoltsData { get; set; }

    public int TotalSpecialValues
    {
      get => this.GetField(1, 13).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      private set
      {
        this.GetField(1, 13).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public List<SpecialValue> SpecialValues { get; set; }

    public SystemSubType SystemSubType
    {
      get
      {
        return (SystemSubType) this.GetField(4, 15).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(4, 15).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public Mid0106()
      : this(4, new int?(0))
    {
    }

    public Mid0106(int revision = 4, int? noAckFlag = 0)
      : base(106, revision, noAckFlag)
    {
      this._intConverter = (IValueConverter<int>) new Int32Converter();
      this._boolConverter = (IValueConverter<bool>) new BoolConverter();
      this._dateConverter = (IValueConverter<DateTime>) new DateConverter();
      this._decimalConverter = (IValueConverter<Decimal>) new DecimalConverter();
      if (this.BoltsData == null)
        this.BoltsData = new List<BoltData>();
      if (this.SpecialValues != null)
        return;
      this.SpecialValues = new List<SpecialValue>();
    }

    public override string Pack()
    {
      this.NumberOfBolts = this.BoltsData.Count;
      this.TotalSpecialValues = this.SpecialValues.Count;
      this._boltDataListConverter = (IValueConverter<IEnumerable<BoltData>>) new BoltDataListConverter(this._intConverter, this._boolConverter, this._decimalConverter, this.NumberOfBolts);
      this._specialValueListConverter = (IValueConverter<IEnumerable<SpecialValue>>) new SpecialValueListConverter(this._intConverter, this.TotalSpecialValues);
      this.GetField(1, 12).Value = this._boltDataListConverter.Convert((IEnumerable<BoltData>) this.BoltsData);
      this.GetField(1, 14).Value = this._specialValueListConverter.Convert((IEnumerable<SpecialValue>) this.SpecialValues);
      string str = this.BuildHeader();
      int num = 1;
      for (int key = 1; key <= (this.HeaderData.Revision > 0 ? this.HeaderData.Revision : 1); ++key)
      {
        foreach (DataField dataField in this.RevisionsByFields[key])
        {
          if (dataField.Field == 13)
            num = 23;
          if (dataField.HasPrefix)
          {
            str = str + num.ToString().PadLeft(2, '0') + dataField.Value;
            ++num;
          }
          else
            str += dataField.Value;
        }
      }
      return str;
    }

    public override Mid Parse(string package)
    {
      this.HeaderData = this.ProcessHeader(package);
      int totalBolts = this._intConverter.Convert(package.Substring(this.GetField(1, 11).Index + 2, this.GetField(1, 11).Size));
      this.GetField(1, 12).Size *= totalBolts;
      DataField field1 = this.GetField(1, 13);
      field1.Index = this.GetField(1, 12).Index + this.GetField(1, 12).Size;
      DataField field2 = this.GetField(1, 14);
      field2.Index = field1.Index + field1.Size + 2;
      if (this.HeaderData.Revision > 3)
      {
        field2.Size = package.Length - this.GetField(4, 15).Size - 2;
        this.GetField(4, 15).Index = field2.Index + field2.Size;
      }
      else
        field2.Size = package.Length - field2.Index;
      this.ProcessDataFields(package);
      this._boltDataListConverter = (IValueConverter<IEnumerable<BoltData>>) new BoltDataListConverter(this._intConverter, this._boolConverter, this._decimalConverter, totalBolts);
      this._specialValueListConverter = (IValueConverter<IEnumerable<SpecialValue>>) new SpecialValueListConverter(this._intConverter, this.TotalSpecialValues);
      this.BoltsData = this._boltDataListConverter.Convert(this.GetField(1, 12).Value).ToList<BoltData>();
      this.SpecialValues = this._specialValueListConverter.Convert(this.GetField(1, 14).Value).ToList<SpecialValue>();
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
            new DataField(2, 28, 10, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(3, 40, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(4, 44, 20, ' '),
            new DataField(5, 66, 19),
            new DataField(6, 87, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(7, 91, 20, ' '),
            new DataField(8, 113, 1),
            new DataField(9, 116, 1),
            new DataField(10, 119, 40, ' '),
            new DataField(11, 161, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(12, 165, 67, false),
            new DataField(13, 0, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(14, 0, 0, false)
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
            new DataField(15, 0, 3, '0', DataField.PaddingOrientations.LEFT_PADDED)
          }
        }
      };
    }

    public enum DataFields
    {
      TOTAL_NUMBER_OF_MESSAGES,
      MESSAGE_NUMBER,
      DATA_NUMBER_SYSTEM,
      STATION_NUMBER,
      STATION_NAME,
      TIME,
      MODE_NUMBER,
      MODE_NAME,
      SIMPLE_STATUS,
      PM_STATUS,
      WP_ID,
      NUMBER_OF_BOLTS,
      BOLT_DATA,
      NUMBER_OF_SPECIAL_VALUES,
      SPECIAL_VALUES,
      SYSTEM_SUB_TYPE,
    }
  }
}
