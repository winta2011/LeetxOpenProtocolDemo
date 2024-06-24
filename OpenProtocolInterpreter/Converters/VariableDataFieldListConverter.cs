
// Type: OpenProtocolInterpreter.Converters.VariableDataFieldListConverter
using OpenProtocolInterpreter.Result;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Converters
{
  public class VariableDataFieldListConverter : AsciiConverter<IEnumerable<VariableDataField>>
  {
    private readonly IValueConverter<int> _intConverter;

    public VariableDataFieldListConverter(IValueConverter<int> intConverter)
    {
      this._intConverter = intConverter;
    }

    public override IEnumerable<VariableDataField> Convert(string value)
    {
      int length = 0;
      for (int i = 0; i < value.Length; i += 17 + length)
      {
        length = this._intConverter.Convert(value.Substring(i + 5, 3));
        yield return new VariableDataField()
        {
          ParameterId = this._intConverter.Convert(value.Substring(i, 5)),
          Length = length,
          DataType = this._intConverter.Convert(value.Substring(i + 8, 2)),
          Unit = this._intConverter.Convert(value.Substring(i + 10, 3)),
          StepNumber = this._intConverter.Convert(value.Substring(i + 13, 4)),
          RealValue = value.Substring(i + 17, length)
        };
      }
    }

    public override string Convert(IEnumerable<VariableDataField> value)
    {
      string empty = string.Empty;
      foreach (VariableDataField variableDataField in value)
      {
        empty += this._intConverter.Convert('0', 5, DataField.PaddingOrientations.LEFT_PADDED, variableDataField.ParameterId);
        empty += this._intConverter.Convert('0', 3, DataField.PaddingOrientations.LEFT_PADDED, variableDataField.Length);
        empty += this._intConverter.Convert('0', 2, DataField.PaddingOrientations.LEFT_PADDED, variableDataField.DataType);
        empty += this._intConverter.Convert('0', 3, DataField.PaddingOrientations.LEFT_PADDED, variableDataField.Unit);
        empty += this._intConverter.Convert('0', 4, DataField.PaddingOrientations.LEFT_PADDED, variableDataField.StepNumber);
        empty += this.GetPadded(' ', 1, DataField.PaddingOrientations.RIGHT_PADDED, variableDataField.RealValue);
      }
      return empty;
    }

    public override string Convert(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      IEnumerable<VariableDataField> value)
    {
      return this.Convert(value);
    }
  }
}
