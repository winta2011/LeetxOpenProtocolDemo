
// Type: OpenProtocolInterpreter.IOInterface.Mid0217
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.IOInterface
{
  public class Mid0217 : Mid, IIOInterface, IController
  {
    private readonly IValueConverter<int> _intConverter;
    private readonly IValueConverter<bool> _boolConverter;
    private const int LAST_REVISION = 1;
    public const int MID = 217;

    public RelayNumber RelayNumber
    {
      get
      {
        return (RelayNumber) this.GetField(1, 0).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 0).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public bool RelayStatus
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

    public Mid0217()
      : this(new int?(0))
    {
    }

    public Mid0217(int? noAckFlag = 0)
      : base(217, 1, noAckFlag)
    {
      this._intConverter = (IValueConverter<int>) new Int32Converter();
      this._boolConverter = (IValueConverter<bool>) new BoolConverter();
    }

    public Mid0217(RelayNumber relayNumber, bool relayStatus, int? noAckFlag = 0)
      : this(noAckFlag)
    {
      this.RelayNumber = relayNumber;
      this.RelayStatus = relayStatus;
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
            new DataField(1, 25, 1)
          }
        }
      };
    }

    public enum DataFields
    {
      RELAY_NUMBER,
      RELAY_STATUS,
    }
  }
}
