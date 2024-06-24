
// Type: OpenProtocolInterpreter.Communication.Mid0004
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Communication
{
  public class Mid0004 : Mid, ICommunication, IController
  {
    private readonly IValueConverter<int> _intConverter;
    private const int LAST_REVISION = 1;
    public const int MID = 4;

    public int FailedMid
    {
      get => this.GetField(1, 0).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 0).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public Error ErrorCode
    {
      get
      {
        return (Error) this.GetField(1, 1).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 1).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public Mid0004()
      : base(4, 1)
    {
      this._intConverter = (IValueConverter<int>) new Int32Converter();
    }

    public Mid0004(int failedMid, Error errorCode)
      : this()
    {
      this.FailedMid = failedMid;
      this.ErrorCode = errorCode;
    }

    public bool Validate(out IEnumerable<string> errors)
    {
      List<string> stringList = new List<string>();
      if (this.FailedMid < 1 || this.FailedMid > 9999)
        stringList.Add(new ArgumentOutOfRangeException("FailedMid", "Range: 0000-9999").Message);
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
            new DataField(0, 20, 4, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
            new DataField(1, 24, 2, '0', DataField.PaddingOrientations.LEFT_PADDED, false)
          }
        }
      };
    }

    public enum DataFields
    {
      MID,
      ERROR_CODE,
    }
  }
}
