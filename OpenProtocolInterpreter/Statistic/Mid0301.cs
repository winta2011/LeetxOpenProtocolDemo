
// Type: OpenProtocolInterpreter.Statistic.Mid0301
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Statistic
{
  public class Mid0301 : Mid, IStatistic, IController
  {
    private readonly IValueConverter<int> _intConverter;
    private readonly IValueConverter<Decimal> _decimalConverter;
    private const int LAST_REVISION = 1;
    public const int MID = 301;

    public int ParameterSetId
    {
      get => this.GetField(1, 0).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 0).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public HistogramType HistogramType
    {
      get
      {
        return (HistogramType) this.GetField(1, 1).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 1).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public Decimal SigmaHistogram
    {
      get
      {
        return this.GetField(1, 2).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(1, 2).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public Decimal MeanValueHistogram
    {
      get
      {
        return this.GetField(1, 3).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(1, 3).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public Decimal ClassRange
    {
      get
      {
        return this.GetField(1, 4).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(1, 4).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public int FirstBar
    {
      get => this.GetField(1, 5).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 5).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int SecondBar
    {
      get => this.GetField(1, 6).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 6).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int ThirdBar
    {
      get => this.GetField(1, 7).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 7).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int FourthBar
    {
      get => this.GetField(1, 8).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 8).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int FifthBar
    {
      get => this.GetField(1, 9).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 9).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int SixthBar
    {
      get => this.GetField(1, 10).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 10).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int SeventhBar
    {
      get => this.GetField(1, 11).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 11).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int EighthBar
    {
      get => this.GetField(1, 12).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 12).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int NinethBar
    {
      get => this.GetField(1, 13).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 13).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public Mid0301()
      : base(301, 1)
    {
      this._intConverter = (IValueConverter<int>) new Int32Converter();
      this._decimalConverter = (IValueConverter<Decimal>) new DecimalTrucatedConverter(2);
    }

    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
      return new Dictionary<int, List<DataField>>()
      {
        {
          1,
          new List<DataField>()
          {
            new DataField(0, 20, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(1, 25, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(2, 29, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(3, 37, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(4, 45, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(5, 53, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(6, 59, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(7, 65, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(8, 71, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(9, 77, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(10, 83, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(11, 89, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(12, 95, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(13, 101, 4, '0', DataField.PaddingOrientations.LEFT_PADDED)
          }
        }
      };
    }

    public enum DataFields
    {
      PARAMETER_SET_ID,
      HISTOGRAM_TYPE,
      SIGMA_HISTOGRAM,
      MEAN_VALUE_HISTOGRAM,
      CLASS_RANGE,
      BAR_1,
      BAR_2,
      BAR_3,
      BAR_4,
      BAR_5,
      BAR_6,
      BAR_7,
      BAR_8,
      BAR_9,
    }
  }
}
