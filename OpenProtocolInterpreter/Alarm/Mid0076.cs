
// Type: OpenProtocolInterpreter.Alarm.Mid0076
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Alarm
{
  public class Mid0076 : Mid, IAlarm, IController
  {
    private readonly IValueConverter<bool> _boolConverter;
    private readonly IValueConverter<int> _intConverter;
    private readonly IValueConverter<DateTime> _dateConverter;
    private const int LAST_REVISION = 3;
    public const int MID = 76;

    public bool AlarmStatus
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

    public string ErrorCode
    {
      get => this.GetField(1, 1).Value;
      set => this.GetField(1, 1).SetValue(value);
    }

    public bool ControllerReadyStatus
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

    public bool ToolReadyStatus
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

    public DateTime Time
    {
      get
      {
        return this.GetField(1, 4).GetValue<DateTime>(new Func<string, DateTime>(this._dateConverter.Convert));
      }
      set
      {
        this.GetField(1, 4).SetValue<DateTime>(new Func<char, int, DataField.PaddingOrientations, DateTime, string>(this._dateConverter.Convert), value);
      }
    }

    public ToolHealth ToolHealth
    {
      get
      {
        return (ToolHealth) this.GetField(3, 5).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(3, 5).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public Mid0076()
      : this(3)
    {
    }

    public Mid0076(int revision = 3)
      : base(76, revision)
    {
      this._boolConverter = (IValueConverter<bool>) new BoolConverter();
      this._dateConverter = (IValueConverter<DateTime>) new DateConverter();
      this._intConverter = (IValueConverter<int>) new Int32Converter();
      this.HandleRevision();
    }

    public Mid0076(
      bool alarmStatus,
      string errorCode,
      bool controllerReadyStatus,
      bool toolReadyStatus,
      DateTime time)
      : this()
    {
      this.AlarmStatus = alarmStatus;
      this.ErrorCode = errorCode;
      this.ControllerReadyStatus = controllerReadyStatus;
      this.ToolReadyStatus = toolReadyStatus;
      this.Time = time;
    }

    public Mid0076(
      bool alarmStatus,
      string errorCode,
      bool controllerReadyStatus,
      bool toolReadyStatus,
      DateTime time,
      ToolHealth toolHealth)
      : this(alarmStatus, errorCode, controllerReadyStatus, toolReadyStatus, time)
    {
      this.ToolHealth = toolHealth;
    }

    public override Mid Parse(string package)
    {
      this.HeaderData = this.ProcessHeader(package);
      this.HandleRevision();
      this.ProcessDataFields(package);
      return (Mid) this;
    }

    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
      return new Dictionary<int, List<DataField>>()
      {
        {
          1,
          new List<DataField>()
          {
            new DataField(0, 20, 1),
            new DataField(1, 23, 4, ' ', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(2, 29, 1),
            new DataField(3, 32, 1),
            new DataField(4, 35, 19)
          }
        },
        {
          2,
          new List<DataField>()
        },
        {
          3,
          new List<DataField>() { new DataField(5, 57, 1) }
        }
      };
    }

    private void HandleRevision()
    {
      DataField field1 = this.GetField(1, 1);
      field1.Size = this.HeaderData.Revision > 1 ? 5 : 4;
      int num = field1.Index + field1.Size;
      for (int field2 = 2; field2 < this.RevisionsByFields[1].Count; ++field2)
      {
        DataField field3 = this.GetField(1, field2);
        field3.Index = 2 + num;
        num = field3.Index + field3.Size;
      }
    }

    public enum DataFields
    {
      ALARM_STATUS,
      ERROR_CODE,
      CONTROLLER_READY_STATUS,
      TOOL_READY_STATUS,
      TIME,
      TOOL_HEALTH,
    }
  }
}
