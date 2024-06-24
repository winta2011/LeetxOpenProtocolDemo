
// Type: OpenProtocolInterpreter.PowerMACS.Mid0108
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.PowerMACS
{
  public class Mid0108 : Mid, IPowerMACS, IIntegrator
  {
    private readonly IValueConverter<bool> _boolConverter;
    private const int LAST_REVISION = 4;
    public const int MID = 108;

    public bool BoltData
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

    public Mid0108()
      : this(4)
    {
    }

    public Mid0108(int revision = 4)
      : base(108, revision)
    {
      this._boolConverter = (IValueConverter<bool>) new BoolConverter();
    }

    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
      return new Dictionary<int, List<DataField>>()
      {
        {
          1,
          new List<DataField>() { new DataField(0, 20, 1, false) }
        },
        {
          2,
          new List<DataField>()
        },
        {
          3,
          new List<DataField>()
        },
        {
          4,
          new List<DataField>()
        }
      };
    }

    public enum DataFields
    {
      BOLT_DATA,
    }
  }
}
