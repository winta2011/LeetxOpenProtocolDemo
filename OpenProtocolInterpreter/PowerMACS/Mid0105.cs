
// Type: OpenProtocolInterpreter.PowerMACS.Mid0105
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.PowerMACS
{
  public class Mid0105 : Mid, IPowerMACS, IIntegrator
  {
    private readonly IValueConverter<bool> _boolConverter;
    private readonly IValueConverter<int> _intConverter;
    private const int LAST_REVISION = 4;
    public const int MID = 105;

    public int DataNumberSystem
    {
      get => this.GetField(2, 0).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(2, 0).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
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

    public Mid0105()
      : this(4, new int?(0))
    {
    }

    public Mid0105(int revision = 4, int? noAckFlag = 0)
      : base(105, revision, noAckFlag)
    {
      this._boolConverter = (IValueConverter<bool>) new BoolConverter();
      this._intConverter = (IValueConverter<int>) new Int32Converter();
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
          new List<DataField>() { new DataField(1, 30, 1, false) }
        },
        {
          4,
          new List<DataField>()
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
