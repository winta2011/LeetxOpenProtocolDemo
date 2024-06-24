
// Type: OpenProtocolInterpreter.Communication.Mid0006
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Communication
{
  public class Mid0006 : Mid, ICommunication, IIntegrator
  {
    private readonly IValueConverter<int> _intConverter;
    private const int LAST_REVISION = 1;
    public const int MID = 6;

    public string RequestedMid
    {
      get => this.GetField(1, 0).Value;
      set => this.GetField(1, 0).SetValue(value);
    }

    public int WantedRevision
    {
      get => this.GetField(1, 1).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 1).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int ExtraDataLength
    {
      get => this.GetField(1, 2).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 2).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public string ExtraData
    {
      get => this.GetField(1, 3).Value;
      set => this.GetField(1, 3).SetValue(value);
    }

    public Mid0006()
      : base(6, 1)
    {
      this._intConverter = (IValueConverter<int>) new Int32Converter();
    }

    public Mid0006(string requestedMid, int wantedRevision, string extraData)
      : this()
    {
      this.RequestedMid = requestedMid;
      this.WantedRevision = wantedRevision;
      this.ExtraData = extraData;
      this.ExtraDataLength = this.ExtraData.Length;
    }

    public override Mid Parse(string package)
    {
      this.HeaderData = this.ProcessHeader(package);
      this.GetField(1, 3).Size = package.Length - 29;
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
            new DataField(0, 20, 4, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
            new DataField(1, 24, 3, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
            new DataField(2, 27, 2, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
            new DataField(3, 29, 0, ' ', hasPrefix: false)
          }
        }
      };
    }

    public enum DataFields
    {
      REQUESTED_MID,
      WANTED_REVISION,
      EXTRA_DATA_LENGTH,
      EXTRA_DATA,
    }
  }
}
