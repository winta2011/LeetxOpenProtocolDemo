
// Type: OpenProtocolInterpreter.PLCUserData.Mid0240
using System.Collections.Generic;


namespace OpenProtocolInterpreter.PLCUserData
{
  public class Mid0240 : Mid, IPLCUserData, IIntegrator
  {
    private const int LAST_REVISION = 1;
    public const int MID = 240;

    public string UserData
    {
      get => this.GetField(1, 0).Value;
      set => this.GetField(1, 0).SetValue(value);
    }

    public Mid0240()
      : base(240, 1)
    {
    }

    public Mid0240(string userData)
      : this()
    {
      this.UserData = userData;
    }

    public override string Pack()
    {
      this.GetField(1, 0).Size = this.UserData.Length;
      return base.Pack();
    }

    public override Mid Parse(string package)
    {
      this.HeaderData = this.ProcessHeader(package);
      this.GetField(1, 0).Size = package.Length - 20;
      this.ProcessDataFields(package);
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
            new DataField(0, 20, 200, ' ', hasPrefix: false)
          }
        }
      };
    }

    internal enum DataFields
    {
      USER_DATA,
    }
  }
}
