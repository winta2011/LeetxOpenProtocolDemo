
// Type: OpenProtocolInterpreter.Communication.Mid0005
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Communication
{
  public class Mid0005 : Mid, ICommunication, IController
  {
    private readonly IValueConverter<int> _intConverter;
    public const int MID = 5;
    private const int LAST_REVISION = 1;

    public int MidAccepted
    {
      get => this.GetField(1, 0).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 0).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public Mid0005()
      : base(5, 1)
    {
      this._intConverter = (IValueConverter<int>) new Int32Converter();
    }

    public Mid0005(int midAccepted)
      : this()
    {
      this.MidAccepted = midAccepted;
    }

    public bool Validate(out IEnumerable<string> errors)
    {
      List<string> stringList = new List<string>();
      if (this.MidAccepted < 1 || this.MidAccepted > 9999)
        stringList.Add(new ArgumentOutOfRangeException("MidAccepted", "Range: 0000-9999").Message);
      errors = (IEnumerable<string>) stringList;
      return stringList.Count > 0;
    }

    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
      return new Dictionary<int, List<DataField>>()
      {
        {
          1,
          new List<DataField>()
          {
            new DataField(0, 20, 4, '0', DataField.PaddingOrientations.LEFT_PADDED, false)
          }
        }
      };
    }

    public enum DataFields
    {
      MID_ACCEPTED,
    }
  }
}
