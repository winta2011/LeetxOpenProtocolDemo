
// Type: OpenProtocolInterpreter.IOInterface.Mid0211
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.IOInterface
{
  public class Mid0211 : Mid, IIOInterface, IController
  {
    private readonly IValueConverter<bool> _boolConverter;
    private const int LAST_REVISION = 1;
    public const int MID = 211;

    public bool StatusDigInOne
    {
      get
      {
        return this.GetField(1, 0).GetValue<bool>(new Func<string, bool>(this._boolConverter.Convert));
      }
      set
      {
        this.GetField(1, 0).SetValue<bool>(new Func<char, int, DataField.PaddingOrientations, bool, string>(this._boolConverter.Convert), value);
      }
    }

    public bool StatusDigInTwo
    {
      get
      {
        return this.GetField(1, 1).GetValue<bool>(new Func<string, bool>(this._boolConverter.Convert));
      }
      set
      {
        this.GetField(1, 1).SetValue<bool>(new Func<char, int, DataField.PaddingOrientations, bool, string>(this._boolConverter.Convert), value);
      }
    }

    public bool StatusDigInThree
    {
      get
      {
        return this.GetField(1, 2).GetValue<bool>(new Func<string, bool>(this._boolConverter.Convert));
      }
      set
      {
        this.GetField(1, 2).SetValue<bool>(new Func<char, int, DataField.PaddingOrientations, bool, string>(this._boolConverter.Convert), value);
      }
    }

    public bool StatusDigInFour
    {
      get
      {
        return this.GetField(1, 3).GetValue<bool>(new Func<string, bool>(this._boolConverter.Convert));
      }
      set
      {
        this.GetField(1, 3).SetValue<bool>(new Func<char, int, DataField.PaddingOrientations, bool, string>(this._boolConverter.Convert), value);
      }
    }

    public bool StatusDigInFive
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

    public bool StatusDigInSix
    {
      get
      {
        return this.GetField(1, 5).GetValue<bool>(new Func<string, bool>(this._boolConverter.Convert));
      }
      set
      {
        this.GetField(1, 5).SetValue<bool>(new Func<char, int, DataField.PaddingOrientations, bool, string>(this._boolConverter.Convert), value);
      }
    }

    public bool StatusDigInSeven
    {
      get
      {
        return this.GetField(1, 6).GetValue<bool>(new Func<string, bool>(this._boolConverter.Convert));
      }
      set
      {
        this.GetField(1, 6).SetValue<bool>(new Func<char, int, DataField.PaddingOrientations, bool, string>(this._boolConverter.Convert), value);
      }
    }

    public bool StatusDigInEight
    {
      get
      {
        return this.GetField(1, 7).GetValue<bool>(new Func<string, bool>(this._boolConverter.Convert));
      }
      set
      {
        this.GetField(1, 7).SetValue<bool>(new Func<char, int, DataField.PaddingOrientations, bool, string>(this._boolConverter.Convert), value);
      }
    }

    public Mid0211()
      : this(new int?(0))
    {
    }

    public Mid0211(int? noAckFlag = 0)
      : base(211, 1, noAckFlag)
    {
      this._boolConverter = (IValueConverter<bool>) new BoolConverter();
    }

    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
      return new Dictionary<int, List<DataField>>()
      {
        {
          1,
          new List<DataField>()
          {
            new DataField(0, 20, 1, false),
            new DataField(1, 21, 1, false),
            new DataField(2, 22, 1, false),
            new DataField(3, 23, 1, false),
            new DataField(4, 24, 1, false),
            new DataField(5, 25, 1, false),
            new DataField(6, 26, 1, false),
            new DataField(7, 27, 1, false)
          }
        }
      };
    }

    public enum DataFields
    {
      STATUS_DIG_IN_1,
      STATUS_DIG_IN_2,
      STATUS_DIG_IN_3,
      STATUS_DIG_IN_4,
      STATUS_DIG_IN_5,
      STATUS_DIG_IN_6,
      STATUS_DIG_IN_7,
      STATUS_DIG_IN_8,
    }
  }
}
