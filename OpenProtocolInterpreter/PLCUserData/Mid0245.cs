
// Type: OpenProtocolInterpreter.PLCUserData.Mid0245
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.PLCUserData
{
  public class Mid0245 : Mid, IPLCUserData, IIntegrator
  {
    private readonly IValueConverter<int> _intConverter;
    private const int LAST_REVISION = 1;
    public const int MID = 245;

    public int Offset
    {
      get => this.GetField(1, 1).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 1).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public string UserData
    {
      get => this.GetField(1, 1).Value;
      set => this.GetField(1, 1).SetValue(value);
    }

    public Mid0245()
      : base(245, 1)
    {
      this._intConverter = (IValueConverter<int>) new Int32Converter();
    }

    public Mid0245(int offset, string userData)
      : this()
    {
      this.Offset = offset;
      this.UserData = userData;
    }

    public override string Pack()
    {
      this.GetField(1, 1).Size = this.UserData.Length;
      return base.Pack();
    }

    public override Mid Parse(string package)
    {
      this.HeaderData = this.ProcessHeader(package);
      this.GetField(1, 1).Size = package.Length - 23;
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
            new DataField(0, 20, 3, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
            new DataField(1, 23, 200, ' ', hasPrefix: false)
          }
        }
      };
    }

    internal enum DataFields
    {
      OFFSET,
      USER_DATA,
    }
  }
}
