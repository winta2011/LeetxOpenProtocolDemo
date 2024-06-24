
// Type: OpenProtocolInterpreter.ParameterSet.Mid0022
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.ParameterSet
{
  public class Mid0022 : Mid, IParameterSet, IController
  {
    private readonly IValueConverter<bool> _boolConverter;
    public const int MID = 22;
    private const int LAST_REVISION = 1;

    public bool RelayStatus
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

    public Mid0022()
      : this(new int?(0))
    {
    }

    public Mid0022(int? noAckFlag = 0)
      : base(22, 1, noAckFlag)
    {
      this._boolConverter = (IValueConverter<bool>) new BoolConverter();
    }

    public Mid0022(bool relayStatus, int? noAckFlag = 0)
      : this(noAckFlag)
    {
      this.RelayStatus = relayStatus;
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
      RELAY_STATUS,
    }
  }
}
