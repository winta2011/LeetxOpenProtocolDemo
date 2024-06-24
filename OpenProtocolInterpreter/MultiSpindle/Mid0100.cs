
// Type: OpenProtocolInterpreter.MultiSpindle.Mid0100
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.MultiSpindle
{
  public class Mid0100 : Mid, IMultiSpindle, IIntegrator
  {
    private readonly IValueConverter<long> _longConverter;
    private readonly IValueConverter<bool> _boolConverter;
    private const int LAST_REVISION = 4;
    public const int MID = 100;

    public long DataNumberSystem
    {
      get
      {
        return this.GetField(2, 0).GetValue<long>(new Func<string, long>(this._longConverter.Convert));
      }
      set
      {
        this.GetField(2, 0).SetValue<long>(new Func<char, int, DataField.PaddingOrientations, long, string>(this._longConverter.Convert), value);
      }
    }

    public bool SendOnlyNewData
    {
      get
      {
        return this.GetField(3, 1).GetValue<bool>(new Func<string, bool>(this._boolConverter.Convert));
      }
      set
      {
        this.GetField(3, 1).SetValue<bool>(new Func<char, int, DataField.PaddingOrientations, bool, string>(this._boolConverter.Convert), value);
      }
    }

    public Mid0100()
      : this(4)
    {
    }

    public Mid0100(int revision = 4)
      : base(100, revision)
    {
      this._longConverter = (IValueConverter<long>) new Int64Converter();
      this._boolConverter = (IValueConverter<bool>) new BoolConverter();
    }

    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
      return new Dictionary<int, List<DataField>>()
      {
        {
          1,
          new List<DataField>()
        },
        {
          2,
          new List<DataField>()
          {
            new DataField(0, 20, 10, '0', DataField.PaddingOrientations.LEFT_PADDED, false)
          }
        },
        {
          3,
          new List<DataField>()
          {
            new DataField(1, 30, 1, '0', DataField.PaddingOrientations.LEFT_PADDED, false)
          }
        }
      };
    }

    public enum DataFields
    {
      DATA_NUMBER_SYSTEM,
      SEND_ONLY_NEW_DATA,
    }
  }
}
