
// Type: OpenProtocolInterpreter.IOInterface.Mid0220
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.IOInterface
{
  public class Mid0220 : Mid, IIOInterface, IIntegrator
  {
    private readonly IValueConverter<int> _intConverter;
    private const int LAST_REVISION = 1;
    public const int MID = 220;

    public DigitalInputNumber DigitalInputNumber
    {
      get
      {
        return (DigitalInputNumber) this.GetField(1, 0).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 0).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public Mid0220()
      : this(new int?(0))
    {
    }

    public Mid0220(int? noAckFlag = 0)
      : base(220, 1, noAckFlag)
    {
      this._intConverter = (IValueConverter<int>) new Int32Converter();
    }

    public Mid0220(DigitalInputNumber digitalInputNumber, int? noAckFlag = 0)
      : this(noAckFlag)
    {
      this.DigitalInputNumber = digitalInputNumber;
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
      DIGITAL_INPUT_NUMBER,
    }
  }
}
