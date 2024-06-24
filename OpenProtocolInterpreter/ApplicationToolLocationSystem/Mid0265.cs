
// Type: OpenProtocolInterpreter.ApplicationToolLocationSystem.Mid0265
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.ApplicationToolLocationSystem
{
  public class Mid0265 : Mid, IApplicationToolLocationSystem, IIntegrator
  {
    private readonly IValueConverter<int> _intConverter;
    private const int LAST_REVISION = 1;
    public const int MID = 265;

    public string ToolTagId
    {
      get => this.GetField(1, 0).Value;
      set => this.GetField(1, 0).SetValue(value);
    }

    public ToolStatus ToolStatus
    {
      get
      {
        return (ToolStatus) this.GetField(1, 1).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 1).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public Mid0265()
      : base(265, 1)
    {
      this._intConverter = (IValueConverter<int>) new Int32Converter();
    }

    public Mid0265(string toolTagId, ToolStatus toolStatus)
      : this()
    {
      this.ToolTagId = toolTagId;
      this.ToolStatus = toolStatus;
    }

    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
      return new Dictionary<int, List<DataField>>()
      {
        {
          1,
          new List<DataField>()
          {
            new DataField(0, 20, 8),
            new DataField(1, 30, 2, '0', DataField.PaddingOrientations.LEFT_PADDED)
          }
        }
      };
    }

    public enum DataFields
    {
      TOOL_TAG_ID,
      TOOL_STATUS,
    }
  }
}
