
// Type: OpenProtocolInterpreter.Alarm.Mid0074
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Alarm
{
  public class Mid0074 : Mid, IAlarm, IController
  {
    private const int LAST_REVISION = 2;
    public const int MID = 74;

    public string ErrorCode
    {
      get => this.GetField(1, 0).Value;
      set => this.GetField(1, 0).SetValue(value);
    }

    public Mid0074()
      : this(2)
    {
    }

    public Mid0074(int revision = 2)
      : base(74, revision)
    {
    }

    public Mid0074(string errorCode, int revision = 2)
      : this(revision)
    {
      this.ErrorCode = errorCode;
    }

    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
      return new Dictionary<int, List<DataField>>()
      {
        {
          1,
          new List<DataField>()
          {
            new DataField(0, 20, 4, ' ', DataField.PaddingOrientations.LEFT_PADDED, false)
          }
        },
        {
          2,
          new List<DataField>()
        }
      };
    }

    public enum DataFields
    {
      ERROR_CODE,
    }
  }
}
