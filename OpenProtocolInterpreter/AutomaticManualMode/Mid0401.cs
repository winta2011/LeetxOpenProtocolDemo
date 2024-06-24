
// Type: OpenProtocolInterpreter.AutomaticManualMode.Mid0401
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.AutomaticManualMode
{
  public class Mid0401 : Mid, IAutomaticManualMode, IController
  {
    private readonly IValueConverter<bool> _boolConverter;
    private const int LAST_REVISION = 1;
    public const int MID = 401;

    public bool ManualAutomaticMode
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

    public Mid0401()
      : this(new int?(0))
    {
    }

    public Mid0401(int? noAckFlag = 0)
      : base(401, 1, noAckFlag)
    {
      this._boolConverter = (IValueConverter<bool>) new BoolConverter();
    }

    public Mid0401(bool manualAutomaticMode, int? noAckFlag = 0)
      : this(noAckFlag)
    {
      this.ManualAutomaticMode = manualAutomaticMode;
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
      MANUAL_AUTOMATIC_MODE,
    }
  }
}
