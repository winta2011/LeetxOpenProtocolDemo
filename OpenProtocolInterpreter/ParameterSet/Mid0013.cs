
// Type: OpenProtocolInterpreter.ParameterSet.Mid0013
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OpenProtocolInterpreter.ParameterSet
{
  public class Mid0013 : Mid, IParameterSet, IController
  {
    private readonly IValueConverter<int> _intConverter;
    private readonly IValueConverter<Decimal> _decimalConverter;
    private const int LAST_REVISION = 2;
    public const int MID = 13;

    public int ParameterSetId
    {
      get => this.GetField(1, 0).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 0).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public string ParameterSetName
    {
      get => this.GetField(1, 1).Value;
      set => this.GetField(1, 1).SetValue(value);
    }

    public RotationDirection RotationDirection
    {
      get
      {
        return (RotationDirection) this.GetField(1, 2).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 2).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public int BatchSize
    {
      get => this.GetField(1, 3).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 3).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public Decimal MinTorque
    {
      get
      {
        return this.GetField(1, 4).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(1, 4).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public Decimal MaxTorque
    {
      get
      {
        return this.GetField(1, 5).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(1, 5).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public Decimal TorqueFinalTarget
    {
      get
      {
        return this.GetField(1, 6).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(1, 6).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public int MinAngle
    {
      get => this.GetField(1, 7).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 7).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int MaxAngle
    {
      get => this.GetField(1, 8).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 8).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int AngleFinalTarget
    {
      get => this.GetField(1, 9).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 9).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public Decimal FirstTarget
    {
      get
      {
        return this.GetField(2, 10).GetValue<Decimal>(new Func<string, Decimal>(this._decimalConverter.Convert));
      }
      set
      {
        this.GetField(2, 10).SetValue<Decimal>(new Func<char, int, DataField.PaddingOrientations, Decimal, string>(this._decimalConverter.Convert), value);
      }
    }

    public Decimal StartFinalAngle
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

    public Mid0013()
      : this(2)
    {
    }

    public Mid0013(int revision = 2)
      : base(13, revision)
    {
      this._intConverter = (IValueConverter<int>) new Int32Converter();
      this._decimalConverter = (IValueConverter<Decimal>) new DecimalTrucatedConverter(2);
    }

    public Mid0013(
      int parameterSetId,
      string parameterSetName,
      RotationDirection rotationDirection,
      int batchSize,
      Decimal minTorque,
      Decimal maxTorque,
      Decimal torqueFinalTarget,
      int minAngle,
      int maxAngle,
      int angleFinalTarget,
      int revision = 1)
      : this(revision)
    {
      this.ParameterSetId = parameterSetId;
      this.ParameterSetName = this.ParameterSetName;
      this.RotationDirection = rotationDirection;
      this.BatchSize = batchSize;
      this.MinTorque = minTorque;
      this.MaxTorque = maxTorque;
      this.TorqueFinalTarget = torqueFinalTarget;
      this.MinAngle = minAngle;
      this.MaxAngle = maxAngle;
      this.AngleFinalTarget = angleFinalTarget;
    }

    public Mid0013(
      int parameterSetId,
      string parameterSetName,
      RotationDirection rotationDirection,
      int batchSize,
      Decimal minTorque,
      Decimal maxTorque,
      Decimal torqueFinalTarget,
      int minAngle,
      int maxAngle,
      int angleFinalTarget,
      Decimal firstTarget,
      Decimal startFinalAngle,
      int revision = 2)
      : this(parameterSetId, parameterSetName, rotationDirection, batchSize, minTorque, maxTorque, torqueFinalTarget, minAngle, maxAngle, angleFinalTarget, revision)
    {
      this.FirstTarget = firstTarget;
      this.StartFinalAngle = startFinalAngle;
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

    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
      return new Dictionary<int, List<DataField>>()
      {
        {
          1,
          new List<DataField>()
          {
            new DataField(0, 20, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(1, 25, 25, ' '),
            new DataField(2, 52, 1, '0'),
            new DataField(3, 55, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(4, 59, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(5, 67, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(6, 75, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(7, 83, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(8, 90, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(9, 97, 5, '0', DataField.PaddingOrientations.LEFT_PADDED)
          }
        },
        {
          2,
          new List<DataField>()
          {
            new DataField(10, 104, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(11, 112, 6, '0', DataField.PaddingOrientations.LEFT_PADDED)
          }
        }
      };
    }

    public enum DataFields
    {
      PARAMETER_SET_ID,
      PARAMETER_SET_NAME,
      ROTATION_DIRECTION,
      BATCH_SIZE,
      MIN_TORQUE,
      MAX_TORQUE,
      TORQUE_FINAL_TARGET,
      MIN_ANGLE,
      MAX_ANGLE,
      ANGLE_FINAL_TARGET,
      FIRST_TARGET,
      START_FINAL_TARGET,
    }
  }
}
