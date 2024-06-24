
// Type: OpenProtocolInterpreter.Converters.StepResultConverter
using OpenProtocolInterpreter.PowerMACS;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OpenProtocolInterpreter.Converters
{
  public class StepResultConverter : AsciiConverter<IEnumerable<StepResult>>
  {
    private readonly IValueConverter<int> _intConverter;
    private IValueConverter<Decimal> _decimalConverter;

    public StepResultConverter(IValueConverter<int> intConverter)
    {
      this._intConverter = intConverter;
    }

    public override IEnumerable<StepResult> Convert(string value)
    {
      for (int i = 0; i < value.Length; i += 31)
      {
        StepResult result = new StepResult()
        {
          VariableName = value.Substring(i, 20),
          Type = DataType.DataTypes.First<DataType>((Func<DataType, bool>) (x => x.Type.Trim() == value.Substring(20 + i, 2).Trim())),
          StepNumber = this._intConverter.Convert(value.Substring(29 + i, 2))
        };
        string resultValue = value.Substring(22 + i, 7);
        if (result.Type.Type == DataType.DataTypes[1].Type)
          result.Value = (object) this._intConverter.Convert(resultValue);
        else if (result.Type.Type == DataType.DataTypes[2].Type)
        {
          int decimalPlaces = resultValue.Split('.')[1].Length;
          this._decimalConverter = (IValueConverter<Decimal>) new DecimalConverter();
          result.Value = (object) this._decimalConverter.Convert(resultValue);
        }
        yield return result;
        result = (StepResult) null;
        resultValue = (string) null;
      }
    }

    public override string Convert(IEnumerable<StepResult> value)
    {
      string empty = string.Empty;
      foreach (StepResult stepResult in value)
      {
        empty += this.GetPadded(' ', 20, DataField.PaddingOrientations.RIGHT_PADDED, stepResult.VariableName);
        empty += stepResult.Type.Type;
        if (stepResult.Type.Type == DataType.DataTypes[1].Type)
          empty += this._intConverter.Convert('0', 7, DataField.PaddingOrientations.LEFT_PADDED, (int) stepResult.Value);
        else if (stepResult.Type.Type == DataType.DataTypes[2].Type)
        {
          this._decimalConverter = (IValueConverter<Decimal>) new DecimalConverter();
          empty += this._decimalConverter.Convert('0', 7, DataField.PaddingOrientations.LEFT_PADDED, (Decimal) stepResult.Value);
        }
        empty += this._intConverter.Convert('0', 2, DataField.PaddingOrientations.LEFT_PADDED, stepResult.StepNumber);
      }
      return empty;
    }

    public override string Convert(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      IEnumerable<StepResult> value)
    {
      return this.Convert(value);
    }
  }
}
