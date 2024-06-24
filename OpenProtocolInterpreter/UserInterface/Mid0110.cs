
// Type: OpenProtocolInterpreter.UserInterface.Mid0110
using System.Collections.Generic;


namespace OpenProtocolInterpreter.UserInterface
{
  public class Mid0110 : Mid, IUserInterface, IIntegrator
  {
    private const int LAST_REVISION = 1;
    public const int MID = 110;

    public string UserText
    {
      get => this.GetField(1, 0).Value;
      set => this.GetField(1, 0).SetValue(value);
    }

    public Mid0110()
      : base(110, 1)
    {
    }

    public Mid0110(string userText)
      : this()
    {
      this.UserText = userText;
    }

    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
      return new Dictionary<int, List<DataField>>()
      {
        {
          1,
          new List<DataField>()
          {
            new DataField(0, 20, 4, ' ', hasPrefix: false)
          }
        }
      };
    }

    public enum DataFields
    {
      USER_TEXT,
    }
  }
}
