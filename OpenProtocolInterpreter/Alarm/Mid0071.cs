
// Type: OpenProtocolInterpreter.Alarm.Mid0071
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Alarm
{
  public class Mid0071 : Mid, IAlarm, IController
  {
    private IValueConverter<bool> _boolConverter;
    private IValueConverter<DateTime> _dateConverter;
    private const int LAST_REVISION = 2;
    public const int MID = 71;

    public string ErrorCode
    {
      get => this.GetField(1, 0).Value;
      set => this.GetField(1, 0).SetValue(value);
    }

    public bool ControllerReadyStatus
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

    public bool ToolReadyStatus
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

    public DateTime Time
    {
      get
      {
        return this.GetField(1, 3).GetValue<DateTime>(new Func<string, DateTime>(this._dateConverter.Convert));
      }
      set
      {
        this.GetField(1, 3).SetValue<DateTime>(new Func<char, int, DataField.PaddingOrientations, DateTime, string>(this._dateConverter.Convert), value);
      }
    }

    public string AlarmText
    {
      get => this.GetField(2, 4).Value;
      set => this.GetField(2, 4).SetValue(value);
    }

    public Mid0071()
      : this(2, new int?(0))
    {
    }

    public Mid0071(int revision = 2, int? noAckFlag = 0)
      : base(71, revision, noAckFlag)
    {
      this._boolConverter = (IValueConverter<bool>) new BoolConverter();
      this._dateConverter = (IValueConverter<DateTime>) new DateConverter();
      this.HandleRevision();
    }

    public Mid0071(
      string errorCode,
      bool controllerReadyStatus,
      bool toolReadyStatus,
      DateTime time,
      int revision = 1,
      int? noAckFlag = 0)
      : this(revision, noAckFlag)
    {
      this.ErrorCode = errorCode;
      this.ControllerReadyStatus = controllerReadyStatus;
      this.ToolReadyStatus = toolReadyStatus;
      this.Time = time;
    }

    public Mid0071(
      string errorCode,
      bool controllerReadyStatus,
      bool toolReadyStatus,
      DateTime time,
      string alarmText,
      int revision = 2,
      int? noAckFlag = 0)
      : this(errorCode, controllerReadyStatus, toolReadyStatus, time, revision, noAckFlag)
    {
      this.AlarmText = alarmText;
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
            new DataField(0, 20, 4, ' ', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(1, 26, 1),
            new DataField(2, 29, 1, ' '),
            new DataField(3, 32, 19)
          }
        },
        {
          2,
          new List<DataField>() { new DataField(4, 54, 50, ' ') }
        }
      };
    }

    private void HandleRevision()
    {
      DataField field1 = this.GetField(1, 0);
      field1.Size = this.HeaderData.Revision <= 1 ? 4 : 5;
      int num = field1.Index + field1.Size;
      for (int field2 = 1; field2 < this.RevisionsByFields[1].Count; ++field2)
      {
        DataField field3 = this.GetField(1, field2);
        field3.Index = 2 + num;
        num = field3.Index + field3.Size;
      }
    }

    public enum DataFields
    {
      ERROR_CODE,
      CONTROLLER_READY_STATUS,
      TOOL_READY_STATUS,
      TIME,
      ALARM_TEXT,
    }
  }
}
