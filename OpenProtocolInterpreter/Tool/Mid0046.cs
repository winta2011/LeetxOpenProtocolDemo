
// Type: OpenProtocolInterpreter.Tool.Mid0046
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Tool
{
  public class Mid0046 : Mid, ITool, IIntegrator
  {
    private readonly IValueConverter<int> _intConverter;
    private const int LAST_REVISION = 1;
    public const int MID = 46;

    public PrimaryTool PrimaryTool
    {
      get
      {
        return (PrimaryTool) this.GetField(1, 0).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 0).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public Mid0046()
      : base(46, 1)
    {
      this._intConverter = (IValueConverter<int>) new Int32Converter();
    }

    public Mid0046(PrimaryTool primaryTool)
      : this()
    {
      this.PrimaryTool = primaryTool;
    }

    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
      return new Dictionary<int, List<DataField>>()
      {
        {
          1,
          new List<DataField>()
          {
            new DataField(0, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED)
          }
        }
      };
    }

    public enum DataFields
    {
      PRIMARY_TOOL,
    }
  }
}
