
// Type: OpenProtocolInterpreter.OpenProtocolCommandsDisabled.Mid0421
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.OpenProtocolCommandsDisabled
{
  public class Mid0421 : Mid, IOpenProtocolCommandsDisabled, IController
  {
    private readonly IValueConverter<bool> _boolConverter;
    private const int LAST_REVISION = 1;
    public const int MID = 421;

    public bool DigitalInputStatus
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

    public Mid0421()
      : this(new int?(0))
    {
    }

    public Mid0421(int? noAckFlag = 0)
      : base(421, 1, noAckFlag)
    {
      this._boolConverter = (IValueConverter<bool>) new BoolConverter();
    }

    public Mid0421(bool digitalInputStatus, int? noAckFlag = 0)
      : this(noAckFlag)
    {
      this.DigitalInputStatus = digitalInputStatus;
    }

    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
      return new Dictionary<int, List<DataField>>()
      {
        {
          1,
          new List<DataField>() { new DataField(0, 20, 1, false) }
        }
      };
    }

    public enum DataFields
    {
      DIGITAL_INPUT_STATUS,
    }
  }
}
