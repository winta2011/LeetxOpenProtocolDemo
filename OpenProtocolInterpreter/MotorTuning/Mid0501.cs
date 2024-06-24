
// Type: OpenProtocolInterpreter.MotorTuning.Mid0501
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.MotorTuning
{
  public class Mid0501 : Mid, IMotorTuning, IController
  {
    private readonly IValueConverter<bool> _boolConverter;
    private const int LAST_REVISION = 1;
    public const int MID = 501;

    public bool MotorTuneResult
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

    public Mid0501()
      : this(new int?(0))
    {
    }

    public Mid0501(int? noAckFlag = 0)
      : base(501, 1, noAckFlag)
    {
      this._boolConverter = (IValueConverter<bool>) new BoolConverter();
    }

    public Mid0501(bool motorTuneResult, int? noAckFlag = 0)
      : this(noAckFlag)
    {
      this.MotorTuneResult = motorTuneResult;
    }

    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
      return new Dictionary<int, List<DataField>>()
      {
        {
          1,
          new List<DataField>() { new DataField(0, 20, 1) }
        }
      };
    }

    public enum DataFields
    {
      MOTOR_TUNE_RESULT,
    }
  }
}
