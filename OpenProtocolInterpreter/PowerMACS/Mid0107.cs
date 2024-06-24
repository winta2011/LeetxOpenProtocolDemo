
// Type: OpenProtocolInterpreter.PowerMACS.Mid0107
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OpenProtocolInterpreter.PowerMACS
{
  public class Mid0107 : Mid, IPowerMACS, IController
  {
    private readonly IValueConverter<bool> _boolConverter;
    private readonly IValueConverter<int> _intConverter;
    private readonly IValueConverter<DateTime> _dateConverter;
    private readonly IValueConverter<IEnumerable<BoltResult>> _boltResultConverter;
    private readonly IValueConverter<IEnumerable<StepResult>> _stepResultConverter;
    private IValueConverter<IEnumerable<SpecialValue>> _specialValueConverter;
    private const int LAST_REVISION = 4;
    public const int MID = 107;

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

    public DateTime Time
    {
      get
      {
        return this.GetField(1, 4).GetValue<DateTime>(new Func<string, DateTime>(this._dateConverter.Convert));
      }
      set
      {
        this.GetField(1, 4).SetValue<DateTime>(new Func<char, int, DataField.PaddingOrientations, DateTime, string>(this._dateConverter.Convert), value);
      }
    }

    public int BoltNumber
    {
      get => this.GetField(1, 5).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 5).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public string BoltName
    {
      get => this.GetField(1, 6).Value;
      set => this.GetField(1, 6).SetValue(value);
    }

    public string ProgramName
    {
      get => this.GetField(1, 7).Value;
      set => this.GetField(1, 7).SetValue(value);
    }

    public Mid0107.PowerMacsStatuses PowerMacsStatus
    {
      get
      {
        return (Mid0107.PowerMacsStatuses) this.GetField(1, 8).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 8).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public string Errors
    {
      get => this.GetField(1, 9).Value;
      set => this.GetField(1, 9).SetValue(value);
    }

    public string CustomerErrorCode
    {
      get => this.GetField(1, 10).Value;
      set => this.GetField(1, 10).SetValue(value);
    }

    public int NumberOfBoltResults
    {
      get => this.GetField(1, 11).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      private set
      {
        this.GetField(1, 11).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public List<BoltResult> BoltResults { get; set; }

    public int NumberOfStepResults
    {
      get => this.GetField(1, 13).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      private set
      {
        this.GetField(1, 13).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public bool AllStepDataSent
    {
      get
      {
        return this.GetField(1, 14).GetValue<bool>(new Func<string, bool>(this._boolConverter.Convert));
      }
      set
      {
        this.GetField(1, 14).SetValue<bool>(new Func<char, int, DataField.PaddingOrientations, bool, string>(this._boolConverter.Convert), value);
      }
    }

    public List<StepResult> StepResults { get; set; }

    public int NumberOfSpecialValues
    {
      get => this.GetField(1, 16).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      private set
      {
        this.GetField(1, 16).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public List<SpecialValue> SpecialValues { get; set; }

    public Mid0107()
      : base(107, 4)
    {
      this._boolConverter = (IValueConverter<bool>) new BoolConverter();
      this._intConverter = (IValueConverter<int>) new Int32Converter();
      this._dateConverter = (IValueConverter<DateTime>) new DateConverter();
      this._boltResultConverter = (IValueConverter<IEnumerable<BoltResult>>) new BoltResultConverter(this._intConverter);
      this._stepResultConverter = (IValueConverter<IEnumerable<StepResult>>) new StepResultConverter(this._intConverter);
      if (this.BoltResults == null)
        this.BoltResults = new List<BoltResult>();
      if (this.StepResults == null)
        this.StepResults = new List<StepResult>();
      if (this.SpecialValues != null)
        return;
      this.SpecialValues = new List<SpecialValue>();
    }

    public override string Pack()
    {
      this.NumberOfBoltResults = this.BoltResults.Count;
      this.NumberOfStepResults = this.StepResults.Count;
      this.NumberOfSpecialValues = this.SpecialValues.Count;
      this._specialValueConverter = (IValueConverter<IEnumerable<SpecialValue>>) new SpecialValueListConverter(this._intConverter, this.NumberOfSpecialValues, true);
      this.GetField(1, 12).SetValue(this._boltResultConverter.Convert((IEnumerable<BoltResult>) this.BoltResults));
      this.GetField(1, 15).SetValue(this._stepResultConverter.Convert((IEnumerable<StepResult>) this.StepResults));
      this.GetField(1, 17).SetValue(this._specialValueConverter.Convert((IEnumerable<SpecialValue>) this.SpecialValues));
      return base.Pack();
    }

    public override Mid Parse(string package)
    {
      this.HeaderData = this.ProcessHeader(package);
      int num1 = this._intConverter.Convert(this.GetValue(this.GetField(1, 11), package));
      DataField field1 = this.GetField(1, 12);
      field1.Size = 29 * num1;
      DataField field2 = this.GetField(1, 13);
      field2.Index = field1.Index + field1.Size;
      DataField field3 = this.GetField(1, 14);
      field3.Index = 2 + field2.Index + field2.Size;
      DataField field4 = this.GetField(1, 15);
      field4.Index = 2 + field3.Index + field3.Size;
      int num2 = this._intConverter.Convert(this.GetValue(field2, package));
      field4.Size = 31 * num2;
      DataField field5 = this.GetField(1, 16);
      field5.Index = field4.Index + field4.Size;
      DataField field6 = this.GetField(1, 17);
      field6.Index = 2 + field5.Index + field5.Size;
      field6.Size = package.Length - field6.Index;
      this.ProcessDataFields(package);
      this._specialValueConverter = (IValueConverter<IEnumerable<SpecialValue>>) new SpecialValueListConverter(this._intConverter, this.NumberOfSpecialValues, true);
      this.BoltResults = this._boltResultConverter.Convert(field1.Value).ToList<BoltResult>();
      this.StepResults = this._stepResultConverter.Convert(field4.Value).ToList<StepResult>();
      this.SpecialValues = this._specialValueConverter.Convert(field6.Value).ToList<SpecialValue>();
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
            new DataField(3, 40, 2),
            new DataField(4, 44, 19),
            new DataField(5, 65, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(6, 71, 20),
            new DataField(7, 93, 20),
            new DataField(8, 115, 1),
            new DataField(9, 118, 50),
            new DataField(10, 170, 4),
            new DataField(11, 176, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(12, 180, 0, false),
            new DataField(13, 0, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(14, 0, 1),
            new DataField(15, 0, 0, false),
            new DataField(16, 0, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(17, 0, 0, false)
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
            new DataField(18, 0, 3, '0', DataField.PaddingOrientations.LEFT_PADDED)
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
      TIME,
      BOLT_NUMBER,
      BOLT_NAME,
      PROGRAM_NAME,
      PM_STATUS,
      ERRORS,
      CUSTOMER_ERROR_CODE,
      NUMBER_OF_BOLT_RESULTS,
      BOLT_RESULTS,
      NUMBER_OF_STEP_RESULTS,
      ALL_STEP_DATA_SENT,
      STEP_RESULTS,
      NUMBER_OF_SPECIAL_VALUES,
      SPECIAL_VALUES,
      SYSTEM_SUB_TYPE,
    }

    public enum PowerMacsStatuses
    {
      OK,
      OKR,
      NOK,
      TERMNOK,
    }
  }
}
