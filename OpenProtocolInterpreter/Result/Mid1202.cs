
// Type: OpenProtocolInterpreter.Result.Mid1202
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OpenProtocolInterpreter.Result
{
  public class Mid1202 : Mid, IResult, IController
  {
    private readonly IValueConverter<int> _intConverter;
    private readonly IValueConverter<IEnumerable<VariableDataField>> _variableDataFieldListConverter;
    private const int LAST_REVISION = 1;
    public const int MID = 1202;

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

    public int ObjectId
    {
      get => this.GetField(1, 3).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 3).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int NumberOfDataFields
    {
      get => this.GetField(1, 4).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 4).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public List<VariableDataField> VariableDataFields { get; set; }

    public Mid1202()
      : base(1202, 1)
    {
      this._intConverter = (IValueConverter<int>) new Int32Converter();
      this._variableDataFieldListConverter = (IValueConverter<IEnumerable<VariableDataField>>) new VariableDataFieldListConverter(this._intConverter);
      this.VariableDataFields = new List<VariableDataField>();
    }

    public override string Pack()
    {
      this.NumberOfDataFields = this.VariableDataFields.Count;
      this.GetField(1, 5).SetValue(this._variableDataFieldListConverter.Convert((IEnumerable<VariableDataField>) this.VariableDataFields));
      return base.Pack();
    }

    public override Mid Parse(string package)
    {
      this.HeaderData = this.ProcessHeader(package);
      DataField field = this.GetField(1, 5);
      field.Size = package.Length - field.Index;
      this.ProcessDataFields(package);
      this.VariableDataFields = this._variableDataFieldListConverter.Convert(field.Value).ToList<VariableDataField>();
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
            new DataField(4, 40, 3, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
            new DataField(5, 43, 0, false)
          }
        }
      };
    }

    public enum DataFields
    {
      TOTAL_MESSAGES,
      MESSAGE_NUMBER,
      RESULT_DATA_ID,
      OBJECT_ID,
      NUMBER_DATA_FIELDS,
      VARIABLE_DATA_FIELDS,
    }
  }
}
