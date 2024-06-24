
// Type: OpenProtocolInterpreter.Converters.SpecialValueListConverter
using OpenProtocolInterpreter.PowerMACS;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OpenProtocolInterpreter.Converters
{
  public class SpecialValueListConverter : AsciiConverter<IEnumerable<SpecialValue>>
  {
    private readonly IValueConverter<int> _intConverter;
    private readonly int _totalSpecialValues;
    private bool _stepNumber;

    public SpecialValueListConverter(
      IValueConverter<int> intConverter,
      int totalSpecialValues,
      bool stepNumber = false)
    {
      this._intConverter = intConverter;
      this._totalSpecialValues = totalSpecialValues;
      this._stepNumber = stepNumber;
    }

    public override IEnumerable<SpecialValue> Convert(string value)
    {
      int index = 0;
      for (int i = 0; i < this._totalSpecialValues; ++i)
      {
        SpecialValue obj = new SpecialValue()
        {
          VariableName = value.Substring(index, 20),
          Type = DataType.DataTypes.First<DataType>((Func<DataType, bool>) (x => x.Type.Trim() == value.Substring(20 + index, 2).Trim())),
          Length = this._intConverter.Convert(value.Substring(22 + index, 2))
        };
        obj.Value = (object) value.Substring(24 + index, obj.Length);
        index += 24 + obj.Length;
        if (this._stepNumber)
        {
          obj.StepNumber = this._intConverter.Convert(value.Substring(index, 2));
          index += 2;
        }
        yield return obj;
        obj = (SpecialValue) null;
      }
    }

    public override string Convert(IEnumerable<SpecialValue> value)
    {
      string str = string.Empty;
      foreach (SpecialValue specialValue in value)
      {
        str = str + specialValue.VariableName.PadRight(20, ' ') + specialValue.Type.Type.PadRight(2, ' ') + this._intConverter.Convert('0', 2, DataField.PaddingOrientations.LEFT_PADDED, specialValue.Length) + specialValue.Value.ToString().PadRight(specialValue.Length, ' ');
        if (this._stepNumber)
          str += this._intConverter.Convert('0', 2, DataField.PaddingOrientations.LEFT_PADDED, specialValue.StepNumber);
      }
      return str;
    }

    public override string Convert(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      IEnumerable<SpecialValue> value)
    {
      return this.Convert(value);
    }
  }
}
