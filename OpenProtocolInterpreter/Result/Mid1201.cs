
// Type: OpenProtocolInterpreter.Result.Mid1201
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OpenProtocolInterpreter.Result
{
  public class Mid1201 : Mid, IResult, IController
  {
    private readonly IValueConverter<int> _intConverter;
    private readonly IValueConverter<DateTime> _dateConverter;
    private readonly IValueConverter<bool> _boolConverter;
    private readonly IValueConverter<IEnumerable<ObjectData>> _objectDataListConverter;
    private readonly IValueConverter<IEnumerable<VariableDataField>> _varDataFieldListConverter;
    private const int LAST_REVISION = 1;
    public const int MID = 1201;

    public Mid1201()
      : base(1201, 1)
    {
      this._intConverter = (IValueConverter<int>) new Int32Converter();
      this._dateConverter = (IValueConverter<DateTime>) new DateConverter();
      this._boolConverter = (IValueConverter<bool>) new BoolConverter();
      this._objectDataListConverter = (IValueConverter<IEnumerable<ObjectData>>) new ObjectDataListConverter(this._intConverter, this._boolConverter);
      this._varDataFieldListConverter = (IValueConverter<IEnumerable<VariableDataField>>) new VariableDataFieldListConverter(this._intConverter);
      this.ObjectDataList = new List<ObjectData>();
      this.VariableDataFields = new List<VariableDataField>();
    }

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

    public int ResultDataIdentifier
    {
      get => this.GetField(1, 2).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 2).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public DateTime Time
    {
      get
      {
        return this.GetField(1, 3).GetValue<DateTime>(new Func<string, DateTime>(this._dateConverter.Convert));
      }
      set
      {
        this.GetField(1, 3).SetValue<DateTime>(new Func<char, int, DataField.PaddingOrientations, DateTime, string>(this._dateConverter.Convert), value);
      }
    }

    public bool ResultStatus
    {
      get
      {
        return this.GetField(1, 4).GetValue<bool>(new Func<string, bool>(this._boolConverter.Convert));
      }
      set
      {
        this.GetField(1, 4).SetValue<bool>(new Func<char, int, DataField.PaddingOrientations, bool, string>(this._boolConverter.Convert), value);
      }
    }

    public OperationType OperationType
    {
      get
      {
        return (OperationType) this.GetField(1, 5).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 5).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public int NumberOfObjects
    {
      get => this.GetField(1, 6).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 6).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int NumberOfDataFields
    {
      get => this.GetField(1, 8).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 8).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public List<ObjectData> ObjectDataList { get; set; }

    public List<VariableDataField> VariableDataFields { get; set; }

    public override string Pack()
    {
      this.NumberOfObjects = this.ObjectDataList.Count;
      this.NumberOfDataFields = this.VariableDataFields.Count;
      this.GetField(1, 7).SetValue(this._objectDataListConverter.Convert((IEnumerable<ObjectData>) this.ObjectDataList));
      this.GetField(1, 9).SetValue(this._varDataFieldListConverter.Convert((IEnumerable<VariableDataField>) this.VariableDataFields));
      return base.Pack();
    }

    public override Mid Parse(string package)
    {
      this.HeaderData = this.ProcessHeader(package);
      int num = this._intConverter.Convert(this.GetValue(this.GetField(1, 6), package));
      DataField field1 = this.GetField(1, 7);
      field1.Size = num * 5;
      DataField field2 = this.GetField(1, 8);
      field2.Index = field1.Index + field1.Size;
      DataField field3 = this.GetField(1, 9);
      field3.Index = field2.Index + field2.Size;
      field3.Size = package.Length - field3.Index;
      this.ObjectDataList = this._objectDataListConverter.Convert(field1.Value).ToList<ObjectData>();
      this.VariableDataFields = this._varDataFieldListConverter.Convert(field3.Value).ToList<VariableDataField>();
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
            new DataField(0, 20, 3, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
            new DataField(1, 23, 3, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
            new DataField(2, 26, 10, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
            new DataField(3, 36, 4, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
            new DataField(4, 55, 1, false),
            new DataField(5, 56, 2, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
            new DataField(6, 58, 3, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
            new DataField(7, 61, 0, false),
            new DataField(8, 0, 3, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
            new DataField(9, 0, 0, false)
          }
        }
      };
    }

    public enum DataFields
    {
      TOTAL_MESSAGES,
      MESSAGE_NUMBER,
      RESULT_DATA_IDENTIFIER,
      TIME,
      RESULT_STATUS,
      OPERATION_TYPE,
      NUMBER_OF_OBJECTS,
      OBJECT_DATA,
      NUMBER_OF_DATA_FIELDS,
      DATA_FIELD_LIST,
    }
  }
}
