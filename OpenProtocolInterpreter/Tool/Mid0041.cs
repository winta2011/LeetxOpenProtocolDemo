
// Type: OpenProtocolInterpreter.Tool.Mid0041
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OpenProtocolInterpreter.Tool
{
  public class Mid0041 : Mid, ITool, IController
  {
    private readonly IValueConverter<int> _intConverter;
    private readonly IValueConverter<long> _longConverter;
    private readonly IValueConverter<DateTime> _dateConverter;
    private readonly IValueConverter<Decimal> _decimalConverter;
    private readonly IValueConverter<Mid0041.OpenEndDatas> _openEndDataConverter;
    private const int LAST_REVISION = 5;
    public const int MID = 41;

    public string ToolSerialNumber
    {
      get => this.GetField(1, 0).Value;
      set => this.GetField(1, 0).SetValue(value);
    }

    public long ToolNumberOfTightenings
    {
      get
      {
        return this.GetField(1, 1).GetValue<long>(new Func<string, long>(this._longConverter.Convert));
      }
      set
      {
        this.GetField(1, 1).SetValue<long>(new Func<char, int, DataField.PaddingOrientations, long, string>(this._longConverter.Convert), value);
      }
    }

    public DateTime LastCalibrationDate
    {
      get
      {
        return this.GetField(1, 2).GetValue<DateTime>(new Func<string, DateTime>(this._dateConverter.Convert));
      }
      set
      {
        this.GetField(1, 2).SetValue<DateTime>(new Func<char, int, DataField.PaddingOrientations, DateTime, string>(this._dateConverter.Convert), value);
      }
    }

    public string ControllerSerialNumber
    {
      get => this.GetField(1, 3).Value;
      set => this.GetField(1, 3).SetValue(value);
    }

    public Decimal CalibrationValue
    {
      get
      {
        return this.GetField(2, 4).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(2, 4).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public DateTime LastServiceDate
    {
      get
      {
        return this.GetField(2, 5).GetValue<DateTime>(new Func<string, DateTime>(this._dateConverter.Convert));
      }
      set
      {
        this.GetField(2, 5).SetValue<DateTime>(new Func<char, int, DataField.PaddingOrientations, DateTime, string>(this._dateConverter.Convert), value);
      }
    }

    public long TighteningsSinceService
    {
      get
      {
        return this.GetField(2, 6).GetValue<long>(new Func<string, long>(this._longConverter.Convert));
      }
      set
      {
        this.GetField(2, 6).SetValue<long>(new Func<char, int, DataField.PaddingOrientations, long, string>(this._longConverter.Convert), value);
      }
    }

    public ToolType ToolType
    {
      get
      {
        return (ToolType) this.GetField(2, 7).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(2, 7).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public int MotorSize
    {
      get => this.GetField(2, 8).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(2, 8).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public Mid0041.OpenEndDatas OpenEndData
    {
      get
      {
        return this.GetField(2, 9).GetValue<Mid0041.OpenEndDatas>(new Func<string, Mid0041.OpenEndDatas>(this._openEndDataConverter.Convert));
      }
      set
      {
        this.GetField(2, 9).SetValue<Mid0041.OpenEndDatas>(new Func<char, int, DataField.PaddingOrientations, Mid0041.OpenEndDatas, string>(this._openEndDataConverter.Convert), value);
      }
    }

    public string ControllerSoftwareVersion
    {
      get => this.GetField(2, 10).Value;
      set => this.GetField(2, 10).SetValue(value);
    }

    public Decimal ToolMaxTorque
    {
      get
      {
        return this.GetField(3, 11).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(3, 11).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public Decimal GearRatio
    {
      get
      {
        return this.GetField(3, 12).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(3, 12).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public Decimal ToolFullSpeed
    {
      get
      {
        return this.GetField(3, 13).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(3, 13).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public PrimaryTool PrimaryTool
    {
      get
      {
        return (PrimaryTool) this.GetField(4, 14).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(4, 14).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public string ToolModel
    {
      get => this.GetField(5, 15).Value;
      set => this.GetField(5, 15).SetValue(value);
    }

    public Mid0041()
      : this(5)
    {
    }

    public Mid0041(int revision = 5)
      : base(41, revision)
    {
      this._intConverter = (IValueConverter<int>) new Int32Converter();
      this._longConverter = (IValueConverter<long>) new Int64Converter();
      this._dateConverter = (IValueConverter<DateTime>) new DateConverter();
      this._decimalConverter = (IValueConverter<Decimal>) new DecimalTrucatedConverter(2);
      this._openEndDataConverter = (IValueConverter<Mid0041.OpenEndDatas>) new OpenEndDataConverter(this._intConverter, (IValueConverter<bool>) new BoolConverter());
    }

    public Mid0041(
      string toolSerialNumber,
      long toolNumberOfTightenings,
      DateTime lastCalibrationDate,
      string controllerSerialNumber,
      int revision = 1)
      : this(revision)
    {
      this.ToolSerialNumber = toolSerialNumber;
      this.ToolNumberOfTightenings = toolNumberOfTightenings;
      this.LastCalibrationDate = lastCalibrationDate;
      this.ControllerSerialNumber = controllerSerialNumber;
    }

    public Mid0041(
      string toolSerialNumber,
      long toolNumberOfTightenings,
      DateTime lastCalibrationDate,
      string controllerSerialNumber,
      Decimal calibrationValue,
      DateTime lastServiceDate,
      long tighteningsSinceService,
      ToolType toolType,
      int motorSize,
      Mid0041.OpenEndDatas openEndData,
      string controllerSoftwareVersion,
      int revision = 2)
      : this(toolSerialNumber, toolNumberOfTightenings, lastCalibrationDate, controllerSerialNumber, revision)
    {
      this.CalibrationValue = calibrationValue;
      this.LastServiceDate = lastServiceDate;
      this.TighteningsSinceService = tighteningsSinceService;
      this.ToolType = toolType;
      this.MotorSize = motorSize;
      this.OpenEndData = openEndData;
      this.ControllerSoftwareVersion = controllerSoftwareVersion;
    }

    public Mid0041(
      string toolSerialNumber,
      long toolNumberOfTightenings,
      DateTime lastCalibrationDate,
      string controllerSerialNumber,
      Decimal calibrationValue,
      DateTime lastServiceDate,
      long tighteningsSinceService,
      ToolType toolType,
      int motorSize,
      Mid0041.OpenEndDatas openEndData,
      string controllerSoftwareVersion,
      Decimal toolMaxTorque,
      Decimal gearRatio,
      Decimal toolFullSpeed,
      int revision = 3)
      : this(toolSerialNumber, toolNumberOfTightenings, lastCalibrationDate, controllerSerialNumber, calibrationValue, lastServiceDate, tighteningsSinceService, toolType, motorSize, openEndData, controllerSoftwareVersion, revision)
    {
      this.ToolMaxTorque = toolMaxTorque;
      this.GearRatio = gearRatio;
      this.ToolFullSpeed = toolFullSpeed;
    }

    public Mid0041(
      string toolSerialNumber,
      long toolNumberOfTightenings,
      DateTime lastCalibrationDate,
      string controllerSerialNumber,
      Decimal calibrationValue,
      DateTime lastServiceDate,
      long tighteningsSinceService,
      ToolType toolType,
      int motorSize,
      Mid0041.OpenEndDatas openEndData,
      string controllerSoftwareVersion,
      Decimal toolMaxTorque,
      Decimal gearRatio,
      Decimal toolFullSpeed,
      PrimaryTool primaryTool,
      int revision = 4)
      : this(toolSerialNumber, toolNumberOfTightenings, lastCalibrationDate, controllerSerialNumber, calibrationValue, lastServiceDate, tighteningsSinceService, toolType, motorSize, openEndData, controllerSoftwareVersion, toolMaxTorque, gearRatio, toolFullSpeed, revision)
    {
      this.PrimaryTool = primaryTool;
    }

    public Mid0041(
      string toolSerialNumber,
      long toolNumberOfTightenings,
      DateTime lastCalibrationDate,
      string controllerSerialNumber,
      Decimal calibrationValue,
      DateTime lastServiceDate,
      long tighteningsSinceService,
      ToolType toolType,
      int motorSize,
      Mid0041.OpenEndDatas openEndData,
      string controllerSoftwareVersion,
      Decimal toolMaxTorque,
      Decimal gearRatio,
      Decimal toolFullSpeed,
      PrimaryTool primaryTool,
      string toolModel,
      int revision = 5)
      : this(toolSerialNumber, toolNumberOfTightenings, lastCalibrationDate, controllerSerialNumber, calibrationValue, lastServiceDate, tighteningsSinceService, toolType, motorSize, openEndData, controllerSoftwareVersion, toolMaxTorque, gearRatio, toolFullSpeed, primaryTool, revision)
    {
      this.ToolModel = toolModel;
    }

    public bool Validate(out IEnumerable<string> errors)
    {
      List<string> stringList = new List<string>();
      if (this.ToolSerialNumber.Length > 14)
        stringList.Add(new ArgumentOutOfRangeException("ToolSerialNumber", "Max of 14 characters").Message);
      if (this.ToolNumberOfTightenings < 0L || this.ToolNumberOfTightenings > (long) uint.MaxValue)
        stringList.Add(new ArgumentOutOfRangeException("ToolNumberOfTightenings", "Range: 0000000000-4294967295").Message);
      if (this.ControllerSerialNumber.Length > 10)
        stringList.Add(new ArgumentOutOfRangeException("ControllerSerialNumber", "Max of 10 characters").Message);
      if (this.HeaderData.Revision > 1)
      {
        if (this.TighteningsSinceService < 0L || this.TighteningsSinceService > (long) uint.MaxValue)
          stringList.Add(new ArgumentOutOfRangeException("TighteningsSinceService", "Range: 0000000000-4294967295").Message);
        if (this.MotorSize < 0 || this.MotorSize > 99)
          stringList.Add(new ArgumentOutOfRangeException("MotorSize", "Range: 00-99").Message);
        if (this.ControllerSoftwareVersion.Length > 19)
          stringList.Add(new ArgumentOutOfRangeException("ControllerSoftwareVersion", "Max of 19 characters").Message);
        if (this.HeaderData.Revision > 4 && this.ToolModel.Length > 12)
          stringList.Add(new ArgumentOutOfRangeException("ToolModel", "Max of 12 characters").Message);
      }
      errors = (IEnumerable<string>) stringList;
      return errors.Any<string>();
    }

    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
      return new Dictionary<int, List<DataField>>()
      {
        {
          1,
          new List<DataField>()
          {
            new DataField(0, 20, 14, ' '),
            new DataField(1, 36, 10, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(2, 48, 19),
            new DataField(3, 69, 10, ' ')
          }
        },
        {
          2,
          new List<DataField>()
          {
            new DataField(4, 81, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(5, 89, 19),
            new DataField(6, 110, 10, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(7, 122, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(8, 126, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(9, 130, 3),
            new DataField(10, 135, 19, ' ')
          }
        },
        {
          3,
          new List<DataField>()
          {
            new DataField(11, 156, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(12, 164, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(13, 172, 6, '0', DataField.PaddingOrientations.LEFT_PADDED)
          }
        },
        {
          4,
          new List<DataField>()
          {
            new DataField(14, 180, 2, '0', DataField.PaddingOrientations.LEFT_PADDED)
          }
        },
        {
          5,
          new List<DataField>() { new DataField(15, 184, 12, ' ') }
        }
      };
    }

    public enum DataFields
    {
      TOOL_SERIAL_NUMBER,
      TOOL_NUMBER_OF_TIGHTENINGS,
      LAST_CALIBRATION_DATE,
      CONTROLLER_SERIAL_NUMBER,
      CALIBRATION_VALUE,
      LAST_SERVICE_DATE,
      TIGHTENINGS_SINCE_SERVICE,
      TOOL_TYPE,
      MOTOR_SIZE,
      OPEN_END_DATA,
      CONTROLLER_SOFTWARE_VERSION,
      TOOL_MAX_TORQUE,
      GEAR_RATIO,
      TOOL_FULL_SPEED,
      PRIMARY_TOOL,
      TOOL_MODEL,
    }

    public class OpenEndDatas
    {
      public bool UseOpenEnd { get; set; }

      public TighteningDirection TighteningDirection { get; set; }

      public MotorRotation MotorRotation { get; set; }

      public OpenEndDatas()
      {
      }

      public OpenEndDatas(
        bool useOpenEnd,
        TighteningDirection tighteningDirection,
        MotorRotation motorRotation)
      {
        this.UseOpenEnd = useOpenEnd;
        this.TighteningDirection = tighteningDirection;
        this.MotorRotation = motorRotation;
      }
    }
  }
}
