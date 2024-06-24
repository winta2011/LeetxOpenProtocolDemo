
// Type: OpenProtocolInterpreter.Mid
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace OpenProtocolInterpreter
{
    public abstract class Mid
    {
        public Dictionary<int, List<DataField>> RevisionsByFields { get; set; }

        public Mid.Header HeaderData { get; set; }

        public Mid(Mid.Header header)
        {
            this.HeaderData = header;
            this.RevisionsByFields = this.RegisterDatafields();
        }

        public Mid(
          int mid,
          int revision,
          int? noAckFlag = null,
          int? spindleID = null,
          int? stationID = null,
          IEnumerable<DataField> usedAs = null)
        {
            this.HeaderData = new Mid.Header()
            {
                Length = 20,
                Mid = mid,
                Revision = revision,
                NoAckFlag = noAckFlag,
                SpindleID = spindleID,
                StationID = stationID,
                UsedAs = usedAs
            };
            this.RevisionsByFields = this.RegisterDatafields();
        }

        protected virtual byte[] BuildRawHeader() => this.ToBytes(this.BuildHeader());

        protected virtual string BuildHeader()
        {
            if (this.RevisionsByFields.Any<KeyValuePair<int, List<DataField>>>())
            {
                this.HeaderData.Length = 20;
                for (int key = 1; key <= (this.HeaderData.Revision > 0 ? this.HeaderData.Revision : 1); ++key)
                {
                    foreach (DataField dataField in this.RevisionsByFields[key])
                        this.HeaderData.Length += (dataField.HasPrefix ? 2 : 0) + dataField.Size;
                }
            }
            return this.HeaderData.ToString();
        }

        public virtual string Pack()
        {
            if (!this.RevisionsByFields.Any<KeyValuePair<int, List<DataField>>>())
                return this.BuildHeader();
            string str = this.BuildHeader();
            int prefixIndex = 1;
            for (int key = 1; key <= (this.HeaderData.Revision > 0 ? this.HeaderData.Revision : 1); ++key)
                str += this.Pack(this.RevisionsByFields[key], ref prefixIndex);
            return str;
        }

        public virtual byte[] PackBytes() => Encoding.ASCII.GetBytes(this.Pack());

        protected virtual string Pack(List<DataField> dataFields, ref int prefixIndex)
        {
            string str = string.Empty;
            foreach (DataField dataField in dataFields)
            {
                if (dataField.HasPrefix)
                {
                    str = str + prefixIndex.ToString().PadLeft(2, '0') + dataField.Value;
                    ++prefixIndex;
                }
                else
                    str += dataField.Value;
            }
            return str;
        }

        protected virtual Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>();
        }

        protected virtual Mid.Header ProcessHeader(string package)
        {
            return new Mid.Header()
            {
                Length = Convert.ToInt32(package.Substring(0, 4)),
                Mid = Convert.ToInt32(package.Substring(4, 4)),
                Revision = package.Length < 11 || string.IsNullOrWhiteSpace(package.Substring(8, 3)) ? 0 : Convert.ToInt32(package.Substring(8, 3)),
                NoAckFlag = package.Length < 12 || string.IsNullOrWhiteSpace(package.Substring(11, 1)) ? new int?() : new int?(Convert.ToInt32(package.Substring(11, 1))),
                StationID = package.Length < 14 || string.IsNullOrWhiteSpace(package.Substring(12, 2)) ? new int?() : new int?(Convert.ToInt32(package.Substring(12, 2))),
                SpindleID = package.Length < 16 || string.IsNullOrWhiteSpace(package.Substring(14, 2)) ? new int?() : new int?(Convert.ToInt32(package.Substring(14, 2)))
            };
        }

        public virtual Mid Parse(string package)
        {
            this.HeaderData = this.ProcessHeader(package);
            this.ProcessDataFields(package);
            return this;
        }

        public virtual Mid Parse(byte[] package) => this.Parse(this.ToAscii(package));

        protected virtual void ProcessDataFields(string package)
        {
            if (!this.RevisionsByFields.Any<KeyValuePair<int, List<DataField>>>())
                return;
            int num = this.HeaderData.Revision > 0 ? this.HeaderData.Revision : 1;
            for (int key = 1; key <= num; ++key)
                this.ProcessDataFields(this.RevisionsByFields[key], package);
        }

        protected virtual void ProcessDataFields(List<DataField> dataFields, string package)
        {
            foreach (DataField dataField in dataFields)
                dataField.Value = this.GetValue(dataField, package);
        }

        protected string GetValue(DataField field, string package)
        {
            try
            {
                return field.HasPrefix ? package.Substring(2 + field.Index, field.Size) : package.Substring(field.Index, field.Size);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return (string)null;
            }
        }

        protected byte[] GetValue(DataField field, byte[] package)
        {
            try
            {
                byte[] numArray = new byte[field.Size];
                int num = field.HasPrefix ? 2 + field.Index : field.Index;
                int index1 = 0;
                for (int index2 = num; index2 < num + field.Size; ++index2)
                {
                    numArray[index1] = package[index2];
                    ++index1;
                }
                return numArray;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return (byte[])null;
            }
        }

        protected DataField GetField(int revision, int field)
        {
            return this.RevisionsByFields[revision].FirstOrDefault<DataField>((Func<DataField, bool>)(x => x.Field == field));
        }

        protected string ToAscii(byte[] bytes) => Encoding.ASCII.GetString(bytes);

        protected byte[] ToBytes(string value) => Encoding.ASCII.GetBytes(value);

        public class Header
        {
            public int Length { get; internal set; }

            public int Mid { get; internal set; }

            public int Revision { get; internal set; }

            public int? NoAckFlag { get; set; }

            public int? SpindleID { get; set; }

            public int? StationID { get; set; }

            public IEnumerable<DataField> UsedAs { get; set; }

            public override string ToString()
            {
                string str1 = string.Empty + this.Length.ToString().PadLeft(4, '0') + this.Mid.ToString().PadLeft(4, '0') + (this.Revision > 0 ? this.Revision.ToString().PadLeft(3, '0') : string.Empty.PadLeft(3, ' ')) + this.NoAckFlag.ToString().PadLeft(1, ' ');
                int? nullable = this.StationID;
                string str2;
                if (!nullable.HasValue)
                {
                    nullable = this.StationID;
                    str2 = nullable.ToString().PadLeft(2, ' ');
                }
                else
                {
                    nullable = this.StationID;
                    str2 = nullable.ToString().PadLeft(2, '0');
                }
                string str3 = str1 + str2;
                nullable = this.SpindleID;
                string str4;
                if (!nullable.HasValue)
                {
                    nullable = this.SpindleID;
                    str4 = nullable.ToString().PadLeft(2, ' ');
                }
                else
                {
                    nullable = this.SpindleID;
                    str4 = nullable.ToString().PadLeft(2, '0');
                }
                string str5 = str3 + str4;
                string str6 = "    ";
                if (this.UsedAs != null)
                {
                    str6 = string.Empty;
                    foreach (DataField usedA in this.UsedAs)
                        str6 += usedA.Value.ToString();
                }
                return str5 + str6;
            }
        }
    }
}
