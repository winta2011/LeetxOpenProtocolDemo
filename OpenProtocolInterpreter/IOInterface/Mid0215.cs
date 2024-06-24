
// Type: OpenProtocolInterpreter.IOInterface.Mid0215
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OpenProtocolInterpreter.IOInterface
{
  public class Mid0215 : Mid, IIOInterface, IController
  {
    private readonly IValueConverter<int> _intConverter;
    private readonly IValueConverter<IEnumerable<Relay>> _relayListConverter;
    private readonly IValueConverter<IEnumerable<DigitalInput>> _digitalInputListConverter;
    private const int LAST_REVISION = 2;
    public const int MID = 215;

    public int IODeviceId
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

    public List<Relay> Relays { get; set; }

    public List<DigitalInput> DigitalInputs { get; set; }

    public int NumberOfRelays
    {
      get => this.GetField(2, 3).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      private set
      {
        this.GetField(2, 3).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int NumberOfDigitalInputs
    {
      get => this.GetField(2, 4).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      private set
      {
        this.GetField(2, 4).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public Mid0215()
      : this(2)
    {
    }

    public Mid0215(int revision = 2)
      : base(215, revision)
    {
      BoolConverter boolConverter = new BoolConverter();
      this._intConverter = (IValueConverter<int>) new Int32Converter();
      this._relayListConverter = (IValueConverter<IEnumerable<Relay>>) new RelayListConverter(this._intConverter, (IValueConverter<bool>) boolConverter);
      this._digitalInputListConverter = (IValueConverter<IEnumerable<DigitalInput>>) new DigitalInputListConverter(this._intConverter, (IValueConverter<bool>) boolConverter);
      this.Relays = new List<Relay>();
      this.DigitalInputs = new List<DigitalInput>();
    }

    protected override string BuildHeader()
    {
      if (this.RevisionsByFields.Any<KeyValuePair<int, List<DataField>>>())
      {
        this.HeaderData.Length = 20;
        foreach (DataField dataField in this.RevisionsByFields[this.HeaderData.Revision > 0 ? this.HeaderData.Revision : 1])
          this.HeaderData.Length += (dataField.HasPrefix ? 2 : 0) + dataField.Size;
      }
      return this.HeaderData.ToString();
    }

    public override string Pack()
    {
      if (this.HeaderData.Revision > 1)
      {
        this.NumberOfRelays = this.Relays.Count;
        this.NumberOfDigitalInputs = this.DigitalInputs.Count;
        DataField field = this.GetField(2, 1);
        field.Size = this.NumberOfRelays * 4;
        field.Value = this._relayListConverter.Convert((IEnumerable<Relay>) this.Relays);
        this.GetField(2, 4).Index = field.Index + field.Size;
        this.GetField(2, 2).Index = this.GetField(2, 4).Index + 2;
        this.GetField(2, 2).Size = this.NumberOfDigitalInputs * 4;
        this.GetField(2, 2).Value = this._digitalInputListConverter.Convert((IEnumerable<DigitalInput>) this.DigitalInputs);
      }
      else
      {
        this.HeaderData.Revision = 1;
        this.GetField(1, 1).Value = this._relayListConverter.Convert((IEnumerable<Relay>) this.Relays);
        this.GetField(1, 2).Value = this._digitalInputListConverter.Convert((IEnumerable<DigitalInput>) this.DigitalInputs);
      }
      string str = this.BuildHeader();
      int num = 1;
      foreach (DataField dataField in this.RevisionsByFields[this.HeaderData.Revision])
      {
        str = str + num.ToString().PadLeft(2, '0') + dataField.Value;
        ++num;
      }
      return str;
    }

    public override Mid Parse(string package)
    {
      this.HeaderData = this.ProcessHeader(package);
      DataField field1;
      DataField field2;
      if (this.HeaderData.Revision > 1)
      {
        field1 = this.GetField(2, 1);
        field2 = this.GetField(2, 2);
        int num = this._intConverter.Convert(this.GetValue(this.GetField(2, 3), package));
        field1.Size = num * 4;
        DataField field3 = this.GetField(2, 4);
        field3.Index = field1.Index + 2 + field1.Size;
        field2.Index = field3.Index + 2 + field3.Size;
        field2.Size = package.Length - 2 - field2.Index;
      }
      else
      {
        field1 = this.GetField(1, 1);
        field2 = this.GetField(1, 2);
      }
      this.ProcessDataFields(package);
      this.Relays = this._relayListConverter.Convert(field1.Value).ToList<Relay>();
      this.DigitalInputs = this._digitalInputListConverter.Convert(field2.Value).ToList<DigitalInput>();
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
            new DataField(0, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(1, 24, 32),
            new DataField(2, 58, 32)
          }
        },
        {
          2,
          new List<DataField>()
          {
            new DataField(0, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(3, 24, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(1, 28, 0),
            new DataField(4, 0, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(2, 0, 0)
          }
        }
      };
    }

    public enum DataFields
    {
      IO_DEVICE_ID,
      RELAY_LIST,
      DIGITAL_INPUT_LIST,
      NUMBER_OF_RELAYS,
      NUMBER_OF_DIGITAL_INPUTS,
    }
  }
}
