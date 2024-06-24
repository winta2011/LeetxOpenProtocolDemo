
// Type: OpenProtocolInterpreter.IOInterface.Mid0219
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.IOInterface
{
  public class Mid0219 : Mid, IIOInterface, IIntegrator
  {
    private readonly IValueConverter<int> _intConverter;
    private const int LAST_REVISION = 1;
    public const int MID = 219;

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

    public Mid0219()
      : base(219, 1)
    {
      this._intConverter = (IValueConverter<int>) new Int32Converter();
    }

    public Mid0219(RelayNumber relayNumber)
      : this()
    {
      this.RelayNumber = relayNumber;
    }

    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
      return new Dictionary<int, List<DataField>>()
      {
        {
          1,
          new List<DataField>()
          {
            new DataField(0, 20, 3, '0', DataField.PaddingOrientations.LEFT_PADDED, false)
          }
        }
      };
    }

    public enum DataFields
    {
      RELAY_NUMBER,
    }
  }
}
