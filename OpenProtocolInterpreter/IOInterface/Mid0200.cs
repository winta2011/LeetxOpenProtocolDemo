
// Type: OpenProtocolInterpreter.IOInterface.Mid0200
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.IOInterface
{
  public class Mid0200 : Mid, IIOInterface, IIntegrator
  {
    private readonly IValueConverter<int> _intConverter;
    private const int LAST_REVISION = 1;
    public const int MID = 200;

    public RelayStatus StatusRelayOne
    {
      get
      {
        return (RelayStatus) this.GetField(1, 0).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 0).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public RelayStatus StatusRelayTwo
    {
      get
      {
        return (RelayStatus) this.GetField(1, 1).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 1).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public RelayStatus StatusRelayThree
    {
      get
      {
        return (RelayStatus) this.GetField(1, 2).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 2).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public RelayStatus StatusRelayFour
    {
      get
      {
        return (RelayStatus) this.GetField(1, 3).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 3).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public RelayStatus StatusRelayFive
    {
      get
      {
        return (RelayStatus) this.GetField(1, 4).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 4).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public RelayStatus StatusRelaySix
    {
      get
      {
        return (RelayStatus) this.GetField(1, 5).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 5).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public RelayStatus StatusRelaySeven
    {
      get
      {
        return (RelayStatus) this.GetField(1, 6).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 6).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public RelayStatus StatusRelayEight
    {
      get
      {
        return (RelayStatus) this.GetField(1, 7).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 7).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public RelayStatus StatusRelayNine
    {
      get
      {
        return (RelayStatus) this.GetField(1, 8).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 8).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public RelayStatus StatusRelayTen
    {
      get
      {
        return (RelayStatus) this.GetField(1, 9).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 9).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public Mid0200()
      : base(200, 1)
    {
      this._intConverter = (IValueConverter<int>) new Int32Converter();
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
            new DataField(7, 27, 1, false),
            new DataField(8, 28, 1, false),
            new DataField(9, 29, 1, false)
          }
        }
      };
    }

    public enum DataFields
    {
      STATUS_RELAY_1,
      STATUS_RELAY_2,
      STATUS_RELAY_3,
      STATUS_RELAY_4,
      STATUS_RELAY_5,
      STATUS_RELAY_6,
      STATUS_RELAY_7,
      STATUS_RELAY_8,
      STATUS_RELAY_9,
      STATUS_RELAY_10,
    }
  }
}
