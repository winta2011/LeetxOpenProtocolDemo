
// Type: OpenProtocolInterpreter.Vin.Mid0050
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Vin
{
  public class Mid0050 : Mid, IVin, IIntegrator
  {
    private const int LAST_REVISION = 1;
    public const int MID = 50;

    public string VinNumber
    {
      get => this.GetField(1, 0).Value;
      set => this.GetField(1, 0).SetValue(value);
    }

    public Mid0050()
      : base(50, 1)
    {
    }

    public Mid0050(string vinNumber)
      : this()
    {
      this.VinNumber = vinNumber;
    }

    public override string Pack()
    {
      this.GetField(1, 0).Size = this.VinNumber.Length;
      return base.Pack();
    }

    public override Mid Parse(string package)
    {
      this.HeaderData = this.ProcessHeader(package);
      this.GetField(1, 0).Size = this.HeaderData.Length - 20;
      this.ProcessDataFields(package);
      return (Mid) this;
    }

    public bool Validate(out string error)
    {
      error = string.Empty;
      if (this.VinNumber.Length > 25)
        error = new ArgumentOutOfRangeException("VinNumber", "Max of 25 characters").Message;
      return !string.IsNullOrEmpty(error);
    }

    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
      return new Dictionary<int, List<DataField>>()
      {
        {
          1,
          new List<DataField>() { new DataField(0, 20, 0, false) }
        }
      };
    }

    public enum DataFields
    {
      VIN_NUMBER,
    }
  }
}
