
// Type: OpenProtocolInterpreter.LinkCommunication.Mid9998
using System.Collections.Generic;
using System.Linq;


namespace OpenProtocolInterpreter.LinkCommunication
{
  internal class Mid9998 : Mid
  {
    private const int length = 27;
    public const int MID = 9998;
    private const int revision = 1;

    public Mid9998()
      : base(9998, 1, usedAs: (IEnumerable<DataField>) new DataField[3]
      {
        new DataField(2, 16, 2),
        new DataField(1, 18, 1),
        new DataField(0, 19, 1)
      })
    {
    }

    protected override string BuildHeader()
    {
      string str1 = string.Empty + this.HeaderData.Length.ToString().PadLeft(4, '0') + this.HeaderData.Mid.ToString().PadLeft(4, '0') + this.HeaderData.Revision.ToString().PadLeft(3, '0') + this.HeaderData.NoAckFlag.ToString().PadLeft(1, ' ') + (this.HeaderData.StationID.HasValue ? this.HeaderData.StationID.ToString().PadLeft(2, '0') : this.HeaderData.StationID.ToString().PadLeft(2, ' '));
      int? spindleId = this.HeaderData.SpindleID;
      string str2;
      if (!spindleId.HasValue)
      {
        spindleId = this.HeaderData.SpindleID;
        str2 = spindleId.ToString().PadLeft(2, ' ');
      }
      else
      {
        spindleId = this.HeaderData.SpindleID;
        str2 = spindleId.ToString().PadLeft(2, '0');
      }
      string str3 = str1 + str2;
      string str4 = "    ";
      if (this.HeaderData.UsedAs != null)
      {
        str4 = string.Empty;
        foreach (DataField usedA in this.HeaderData.UsedAs)
          str4 += usedA.Value.ToString().PadLeft(usedA.Size, ' ');
      }
      return str3 + str4;
    }

    protected override Mid.Header ProcessHeader(string package)
    {
      Mid.Header header = base.ProcessHeader(package);
      header.UsedAs.ToList<DataField>()[2].Value = !string.IsNullOrWhiteSpace(package.Substring(16, 2)) ? package.Substring(16, 2) : (string) null;
      header.UsedAs.ToList<DataField>()[1].Value = !string.IsNullOrWhiteSpace(package.Substring(18, 1)) ? package.Substring(18, 1) : (string) null;
      header.UsedAs.ToList<DataField>()[0].Value = !string.IsNullOrWhiteSpace(package.Substring(19, 1)) ? package.Substring(19, 1) : (string) null;
      return header;
    }

    public override string Pack() => base.Pack();

    public override Mid Parse(string package)
    {
      this.ProcessHeader(package);
      return (Mid) this;
    }

    public enum UsedsAs
    {
      SEQUENCE_NUMBER,
      NUMBER_OF_MESSAGES,
      MESSAGE_NUMBER,
    }

    public enum ErroCodes
    {
      INVALID_LENGTH = 1,
      INVALID_REVISION = 2,
      INVALID_SEQUENCE_NUMBER = 3,
      INCONSISTENCY_OF_NUMBER_OF_MESSAGES = 4,
    }
  }
}
