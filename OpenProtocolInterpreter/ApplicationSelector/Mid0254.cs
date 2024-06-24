
// Type: OpenProtocolInterpreter.ApplicationSelector.Mid0254
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OpenProtocolInterpreter.ApplicationSelector
{
  public class Mid0254 : Mid, IApplicationSelector, IIntegrator
  {
    private readonly IValueConverter<IEnumerable<LightCommand>> _lightsConverter;
    private readonly IValueConverter<int> _intConverter;
    private const int LAST_REVISION = 1;
    public const int MID = 254;

    public int DeviceId
    {
      get => this.GetField(1, 0).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 0).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public List<LightCommand> GreenLights { get; set; }

    public Mid0254()
      : base(254, 1)
    {
      this._intConverter = (IValueConverter<int>) new Int32Converter();
      this._lightsConverter = (IValueConverter<IEnumerable<LightCommand>>) new LightCommandListConverter(this._intConverter);
      if (this.GreenLights != null)
        return;
      this.GreenLights = new List<LightCommand>();
    }

    public Mid0254(int deviceId, IEnumerable<LightCommand> greenLights)
      : this()
    {
      this.DeviceId = deviceId;
      this.GreenLights = greenLights.ToList<LightCommand>();
    }

    public override string Pack()
    {
      this.GetField(1, 1).Value = this._lightsConverter.Convert((IEnumerable<LightCommand>) this.GreenLights);
      return base.Pack();
    }

    public override Mid Parse(string package)
    {
      base.Parse(package);
      this.GreenLights = this._lightsConverter.Convert(this.GetField(1, 1).Value).ToList<LightCommand>();
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
            new DataField(1, 24, 8)
          }
        }
      };
    }

    public enum DataFields
    {
      DEVICE_ID,
      GREEN_LIGHT_COMMAND,
    }
  }
}
