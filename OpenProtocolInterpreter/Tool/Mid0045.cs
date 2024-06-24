
// Type: OpenProtocolInterpreter.Tool.Mid0045
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Tool
{
  public class Mid0045 : Mid, ITool, IIntegrator
  {
    private readonly IValueConverter<Decimal> _decimalConverter;
    private readonly IValueConverter<int> _intConverter;
    private const int LAST_REVISION = 1;
    public const int MID = 45;

    public CalibrationUnit CalibrationValueUnit
    {
      get
      {
        return (CalibrationUnit) this.GetField(1, 0).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 0).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public Decimal CalibrationValue
    {
      get
      {
        return this.GetField(1, 1).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(1, 1).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public Mid0045()
      : base(45, 1)
    {
      this._decimalConverter = (IValueConverter<Decimal>) new DecimalTrucatedConverter(2);
      this._intConverter = (IValueConverter<int>) new Int32Converter();
    }

    public Mid0045(CalibrationUnit calibrationValueUnit, Decimal calibrationValue)
      : this()
    {
      this.CalibrationValueUnit = calibrationValueUnit;
      this.CalibrationValue = calibrationValue;
    }

    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
      return new Dictionary<int, List<DataField>>()
      {
        {
          1,
          new List<DataField>()
          {
            new DataField(0, 20, 1),
            new DataField(1, 23, 6, '0', DataField.PaddingOrientations.LEFT_PADDED)
          }
        }
      };
    }

    public enum DataFields
    {
      CALIBRATION_VALUE_UNIT,
      CALIBRATION_VALUE,
    }
  }
}
