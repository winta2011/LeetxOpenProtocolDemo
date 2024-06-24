
// Type: OpenProtocolInterpreter.Tightening.Mid0064
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Tightening
{
  public class Mid0064 : Mid, ITightening, IIntegrator
  {
    private readonly IValueConverter<long> _longConverter;
    private const int LAST_REVISION = 6;
    public const int MID = 64;

    public long TighteningId
    {
      get
      {
        return this.GetField(1, 0).GetValue<long>(new Func<string, long>(this._longConverter.Convert));
      }
      set
      {
        this.GetField(1, 0).SetValue<long>(new Func<char, int, DataField.PaddingOrientations, long, string>(this._longConverter.Convert), value);
      }
    }

    public Mid0064()
      : this(6)
    {
    }

    public Mid0064(int revision = 6)
      : base(64, revision)
    {
      this._longConverter = (IValueConverter<long>) new Int64Converter();
    }

    public Mid0064(int tighteningId, int revision = 6)
      : this(revision)
    {
      this.TighteningId = (long) tighteningId;
    }

    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
      return new Dictionary<int, List<DataField>>()
      {
        {
          1,
          new List<DataField>()
          {
            new DataField(0, 20, 10, '0', DataField.PaddingOrientations.LEFT_PADDED, false)
          }
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
        },
        {
          5,
          new List<DataField>()
        },
        {
          6,
          new List<DataField>()
        }
      };
    }

    public enum DataFields
    {
      TIGHTENING_ID,
    }
  }
}
