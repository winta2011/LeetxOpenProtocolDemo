
// Type: OpenProtocolInterpreter.ParameterSet.Mid0015
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OpenProtocolInterpreter.ParameterSet
{
  public class Mid0015 : Mid, IParameterSet, IController
  {
    private readonly IValueConverter<int> _intConverter;
    private readonly IValueConverter<Decimal> _decimalConverter;
    private readonly IValueConverter<DateTime> _datetimeConverter;
    private const int LAST_REVISION = 2;
    public const int MID = 15;

    public int ParameterSetId
    {
      get
      {
        return this.GetField(this.HeaderData.Revision, 0).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(this.HeaderData.Revision, 0).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public DateTime LastChangeInParameterSet
    {
      get
      {
        return this.GetField(this.HeaderData.Revision, 1).GetValue<DateTime>(new Func<string, DateTime>(this._datetimeConverter.Convert));
      }
      set
      {
        this.GetField(this.HeaderData.Revision, 1).SetValue<DateTime>(new Func<char, int, DataField.PaddingOrientations, DateTime, string>(this._datetimeConverter.Convert), value);
      }
    }

    public string ParameterSetName
    {
      get => this.GetField(2, 2).Value;
      set => this.GetField(2, 2).SetValue(value);
    }

    public RotationDirection RotationDirection
    {
      get
      {
        return (RotationDirection) this.GetField(2, 3).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(2, 3).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public int BatchSize
    {
      get => this.GetField(2, 4).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(2, 4).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public Decimal MinTorque
    {
      get
      {
        return this.GetField(2, 5).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(2, 5).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public Decimal MaxTorque
    {
      get
      {
        return this.GetField(2, 6).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(2, 6).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public Decimal TorqueFinalTarget
    {
      get
      {
        return this.GetField(2, 7).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(2, 7).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public int MinAngle
    {
      get => this.GetField(2, 8).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(2, 8).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int MaxAngle
    {
      get => this.GetField(2, 9).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(2, 9).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int AngleFinalTarget
    {
      get => this.GetField(2, 10).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(2, 10).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public Decimal FirstTarget
    {
      get
      {
        return this.GetField(2, 11).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(2, 11).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public Decimal StartFinalAngle
    {
      get
      {
        return this.GetField(2, 12).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(2, 12).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public Mid0015()
      : this(2, new int?(0))
    {
    }

    public Mid0015(int revision = 2, int? noAckFlag = 0)
      : base(15, revision, noAckFlag)
    {
      this._intConverter = (IValueConverter<int>) new Int32Converter();
      this._datetimeConverter = (IValueConverter<DateTime>) new DateConverter();
      this._decimalConverter = (IValueConverter<Decimal>) new DecimalTrucatedConverter(2);
    }

    public Mid0015(
      int parameterSetId,
      DateTime lastChangeInParameterSet,
      int? noAckFlag = 0,
      int revision = 1)
      : this(revision, noAckFlag)
    {
      this.ParameterSetId = parameterSetId;
      this.LastChangeInParameterSet = lastChangeInParameterSet;
    }

    public Mid0015(
      int parameterSetId,
      string parameterSetName,
      DateTime lastChangeInParameterSet,
      RotationDirection rotationDirection,
      int batchSize,
      Decimal torqueMin,
      Decimal torqueMax,
      Decimal torqueFinalTarget,
      int angleMin,
      int angleMax,
      int finalAngleTarget,
      Decimal firstTarget,
      Decimal startFinalAngle,
      int? noAckFlag = 0,
      int revision = 2)
      : this(parameterSetId, lastChangeInParameterSet, noAckFlag, revision)
    {
      this.ParameterSetName = parameterSetName;
      this.RotationDirection = rotationDirection;
      this.BatchSize = batchSize;
      this.MinTorque = torqueMin;
      this.MaxTorque = torqueMax;
      this.TorqueFinalTarget = torqueFinalTarget;
      this.MinAngle = angleMin;
      this.MaxAngle = angleMax;
      this.AngleFinalTarget = finalAngleTarget;
      this.FirstTarget = firstTarget;
      this.StartFinalAngle = startFinalAngle;
    }

    protected override string BuildHeader()
    {
      this.HeaderData.Length = 20;
      foreach (DataField dataField in this.RevisionsByFields[this.HeaderData.Revision])
        this.HeaderData.Length += (dataField.HasPrefix ? 2 : 0) + dataField.Size;
      return this.HeaderData.ToString();
    }

    public override string Pack()
    {
      int prefixIndex = 1;
      return this.BuildHeader() + this.Pack(this.RevisionsByFields[this.HeaderData.Revision], ref prefixIndex);
    }

    public override Mid Parse(string package)
    {
      this.HeaderData = this.ProcessHeader(package);
      this.HeaderData.Revision = this.HeaderData.Revision > 0 ? this.HeaderData.Revision : 1;
      this.ProcessDataFields(this.RevisionsByFields[this.HeaderData.Revision], package);
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
            new DataField(0, 20, 3, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
            new DataField(1, 23, 19, false)
          }
        },
        {
          2,
          new List<DataField>()
          {
            new DataField(0, 20, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(2, 25, 25, ' '),
            new DataField(1, 52, 19),
            new DataField(3, 73, 1),
            new DataField(4, 76, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(5, 80, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(6, 88, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(7, 96, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(8, 104, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(9, 111, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(10, 118, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(11, 125, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(12, 133, 6, '0', DataField.PaddingOrientations.LEFT_PADDED)
          }
        }
      };
    }

    public bool Validate(out IEnumerable<string> errors)
    {
      List<string> stringList = new List<string>();
      if (this.ParameterSetId < 0 || this.ParameterSetId > 999)
        stringList.Add(new ArgumentOutOfRangeException("ParameterSetId", "Range: 000-999").Message);
      if (this.ParameterSetName.Length > 25)
        stringList.Add(new ArgumentOutOfRangeException("ParameterSetName", "Max of 25 characters").Message);
      if (this.BatchSize < 0 || this.BatchSize > 99)
        stringList.Add(new ArgumentOutOfRangeException("BatchSize", "Range: 00-99").Message);
      if (this.MinAngle < 0 || this.MinAngle > 99999)
        stringList.Add(new ArgumentOutOfRangeException("MinAngle", "Range: 00000-99999").Message);
      if (this.MaxAngle < 0 || this.MaxAngle > 99999)
        stringList.Add(new ArgumentOutOfRangeException("MaxAngle", "Range: 00000-99999").Message);
      if (this.AngleFinalTarget < 0 || this.AngleFinalTarget > 99999)
        stringList.Add(new ArgumentOutOfRangeException("AngleFinalTarget", "Range: 00000-99999").Message);
      errors = (IEnumerable<string>) stringList;
      return errors.Any<string>();
    }

    public enum DataFields
    {
      PARAMETER_SET_ID,
      LAST_CHANGE_IN_PARAMETER_SET,
      PARAMETER_SET_NAME,
      ROTATION_DIRECTION,
      BATCH_SIZE,
      TORQUE_MIN,
      TORQUE_MAX,
      TORQUE_FINAL_TARGET,
      ANGLE_MIN,
      ANGLE_MAX,
      FINAL_ANGLE_TARGET,
      FIRST_TARGET,
      START_FINAL_ANGLE,
    }
  }
}
