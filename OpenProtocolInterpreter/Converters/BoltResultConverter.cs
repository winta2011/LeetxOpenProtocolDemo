
// Type: OpenProtocolInterpreter.Converters.BoltResultConverter
using OpenProtocolInterpreter.PowerMACS;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OpenProtocolInterpreter.Converters
{
  public class BoltResultConverter : AsciiConverter<IEnumerable<BoltResult>>
  {
    private readonly IValueConverter<int> _intConverter;
    private IValueConverter<Decimal> _decimalConverter;

    public BoltResultConverter(IValueConverter<int> intConverter)
    {
      this._intConverter = intConverter;
    }

    public override IEnumerable<BoltResult> Convert(string value)
    {
      for (int i = 0; i < value.Length; i += 29)
      {
        BoltResult result = new BoltResult()
        {
          VariableName = value.Substring(i, 20),
          Type = DataType.DataTypes.First<DataType>((Func<DataType, bool>) (x => x.Type.Trim() == value.Substring(20 + i, 2).Trim()))
        };
        string resultValue = value.Substring(22 + i, 7);
        if (result.Type.Type == DataType.DataTypes[1].Type)
          result.Value = (object) this._intConverter.Convert(resultValue);
        else if (result.Type.Type == DataType.DataTypes[2].Type)
        {
          this._decimalConverter = (IValueConverter<Decimal>) new DecimalConverter();
          result.Value = (object) this._decimalConverter.Convert(resultValue);
        }
        yield return result;
        result = (BoltResult) null;
        resultValue = (string) null;
      }
    }

    public override string Convert(IEnumerable<BoltResult> value)
    {
      string empty = string.Empty;
      foreach (BoltResult boltResult in value)
      {
        empty += this.GetPadded(' ', 20, DataField.PaddingOrientations.RIGHT_PADDED, boltResult.VariableName);
        empty += boltResult.Type.Type;
        if (boltResult.Type.Type == DataType.DataTypes[1].Type)
          empty += this._intConverter.Convert('0', 7, DataField.PaddingOrientations.LEFT_PADDED, (int) boltResult.Value);
        else if (boltResult.Type.Type == DataType.DataTypes[2].Type)
        {
          this._decimalConverter = (IValueConverter<Decimal>) new DecimalConverter();
          empty += this._decimalConverter.Convert('0', 7, DataField.PaddingOrientations.LEFT_PADDED, (Decimal) boltResult.Value);
        }
      }
      return empty;
    }

    public override string Convert(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      IEnumerable<BoltResult> value)
    {
      return this.Convert(value);
    }
  }
}
