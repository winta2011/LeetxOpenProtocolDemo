
// Type: OpenProtocolInterpreter.PLCUserData.Mid0242
using System.Collections.Generic;


namespace OpenProtocolInterpreter.PLCUserData
{
  public class Mid0242 : Mid, IPLCUserData, IController
  {
    private const int LAST_REVISION = 1;
    public const int MID = 242;

    public string UserData
    {
      get => this.GetField(1, 0).Value;
      set => this.GetField(1, 0).SetValue(value);
    }

    public Mid0242()
      : this(new int?(0))
    {
    }

    public Mid0242(int? noAckFlag = 0)
      : base(242, 1, noAckFlag)
    {
    }

    public Mid0242(string userData, int? noAckFlag = 0)
      : this(noAckFlag)
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
