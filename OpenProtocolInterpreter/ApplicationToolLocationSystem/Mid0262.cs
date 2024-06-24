
// Type: OpenProtocolInterpreter.ApplicationToolLocationSystem.Mid0262
using System.Collections.Generic;


namespace OpenProtocolInterpreter.ApplicationToolLocationSystem
{
  public class Mid0262 : Mid, IApplicationToolLocationSystem, IController
  {
    private const int LAST_REVISION = 1;
    public const int MID = 262;

    public string ToolTagId
    {
      get => this.GetField(1, 0).Value;
      set => this.GetField(1, 0).SetValue(value);
    }

    public Mid0262()
      : this(new int?(0))
    {
    }

    public Mid0262(int? noAckFlag = 0)
      : base(262, 1, noAckFlag)
    {
    }

    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
      return new Dictionary<int, List<DataField>>()
      {
        {
          1,
          new List<DataField>() { new DataField(0, 20, 8) }
        }
      };
    }

    public enum DataFields
    {
      TOOL_TAG_ID,
    }
  }
}
