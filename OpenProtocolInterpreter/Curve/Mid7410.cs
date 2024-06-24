
// Type: OpenProtocolInterpreter.Curve.Mid7410
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OpenProtocolInterpreter.Curve
{
    public class Mid7410 : Mid, ICurve, IController
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<CurveData> _curveDataConvter;
        private readonly IValueConverter<long> _longConverter;
        private readonly IValueConverter<double> _float64Converter;
        private readonly IValueConverter<bool> _boolConverter;
        private readonly IValueConverter<Decimal> _decimalConverter;
        private readonly IValueConverter<DateTime> _dateConverter;
        private const int LAST_REVISION = 2;
        public const int MID = 7410;
        private const int MaxCurveDataLength = 750;

        public int ChannelId
        {
            get
            {
                return this.GetField(this.GetCurrentRevisionIndex(), 0).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
            }
            set
            {
                this.GetField(this.GetCurrentRevisionIndex(), 0).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
            }
        }

        public int ParameterSetId
        {
            get
            {
                return this.GetField(this.GetCurrentRevisionIndex(), 1).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
            }
            set
            {
                this.GetField(this.GetCurrentRevisionIndex(), 1).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
            }
        }

        public double TimeCoefficient
        {
            get
            {
                return this.GetField(this.GetCurrentRevisionIndex(), 2).GetValue<double>(new Func<string, double>(this._float64Converter.Convert));
            }
            set
            {
                this.GetField(this.GetCurrentRevisionIndex(), 2).SetValue<double>(new Func<char, int, DataField.PaddingOrientations, double, string>(this._float64Converter.Convert), value);
            }
        }

        public double TorqueCoefficient
        {
            get
            {
                return this.GetField(this.GetCurrentRevisionIndex(), 3).GetValue<double>(new Func<string, double>(this._float64Converter.Convert));
            }
            set
            {
                this.GetField(this.GetCurrentRevisionIndex(), 3).SetValue<double>(new Func<char, int, DataField.PaddingOrientations, double, string>(this._float64Converter.Convert), value);
            }
        }

        public double AngleCoefficient
        {
            get
            {
                return this.GetField(this.GetCurrentRevisionIndex(), 4).GetValue<double>(new Func<string, double>(this._float64Converter.Convert));
            }
            set
            {
                this.GetField(this.GetCurrentRevisionIndex(), 4).SetValue<double>(new Func<char, int, DataField.PaddingOrientations, double, string>(this._float64Converter.Convert), value);
            }
        }

        public int NumMeasurementPoints
        {
            get
            {
                return this.GetField(this.GetCurrentRevisionIndex(), 5).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
            }
            set
            {
                this.GetField(this.GetCurrentRevisionIndex(), 5).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
            }
        }

        public int NumSegments
        {
            get
            {
                return this.GetField(this.GetCurrentRevisionIndex(), 6).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
            }
            set
            {
                this.GetField(this.GetCurrentRevisionIndex(), 6).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
            }
        }

        public int SegmentID
        {
            get
            {
                return this.GetField(this.GetCurrentRevisionIndex(), 7).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
            }
            set
            {
                this.GetField(this.GetCurrentRevisionIndex(), 7).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
            }
        }

        public CurveData RawCurveData
        {
            get
            {
                return this.GetField(this.GetCurrentRevisionIndex(), 8).GetValue<CurveData>(new Func<string, CurveData>(this._curveDataConvter.Convert));
            }
            set
            {
                this.GetField(this.GetCurrentRevisionIndex(), 8).SetValue<CurveData>(new Func<char, int, DataField.PaddingOrientations, CurveData, string>(this._curveDataConvter.Convert), value);
            }
        }

        public List<double> Torque { get; private set; }

        public List<double> Angle { get; private set; }

        public List<double> Speed { get; private set; }

        public Mid7410()
          : this(2)
        {
       
        }

        public Mid7410(int revision = 2)
          : base(7410, revision)
        {
            this._curveDataConvter = (IValueConverter<CurveData>)new RawCurveDataConverter((IValueConverter<byte[]>)new ByteArrayConverter());
            this._intConverter = (IValueConverter<int>)new Int32Converter();
            this._float64Converter = (IValueConverter<double>)new Float64Converter();
            this._longConverter = (IValueConverter<long>)new Int64Converter();
            this._boolConverter = (IValueConverter<bool>)new BoolConverter();
            this._decimalConverter = (IValueConverter<Decimal>)new DecimalTrucatedConverter(2);
            this._dateConverter = (IValueConverter<DateTime>)new DateConverter();
            Torque = new List<double>();
            Angle = new List<double>();
            Speed = new List<double>();
        }

        protected override string BuildHeader()
        {
            if (this.RevisionsByFields.Any<KeyValuePair<int, List<DataField>>>())
            {
                this.HeaderData.Length = 20;
                this.HeaderData.Revision = this.HeaderData.Revision > 0 ? this.HeaderData.Revision : 1;
                if (this.HeaderData.Revision == 1 || this.HeaderData.Revision == 999)
                {
                    foreach (DataField dataField in this.RevisionsByFields[this.HeaderData.Revision])
                        this.HeaderData.Length += (dataField.HasPrefix ? 2 : 0) + dataField.Size;
                }
                else
                {
                    int num = this.HeaderData.Revision != 998 ? this.HeaderData.Revision : 6;
                    for (int key = 2; key <= num; ++key)
                    {
                        foreach (DataField dataField in this.RevisionsByFields[key])
                            this.HeaderData.Length += (dataField.HasPrefix ? 2 : 0) + dataField.Size;
                    }
                }
            }
            return this.HeaderData.ToString();
        }

        [Obsolete("Use PackBytes(), this method will convert everything to ASCII, which will break packages above revision 1 because of byte fields")]
        public override string Pack()
        {
            string str = this.BuildHeader();
            if (this.HeaderData.Revision == 1 || this.HeaderData.Revision == 999)
            {
                str += this.BuildDataFieldsPackage(1, this.RevisionsByFields[this.HeaderData.Revision]);
            }
            else
            {
                int num = this.HeaderData.Revision != 998 ? this.HeaderData.Revision : 6;
                int prefixIndex = 1;
                for (int key = 2; key <= num; ++key)
                {
                    str += this.BuildDataFieldsPackage(prefixIndex, this.RevisionsByFields[key]);
                    prefixIndex += this.RevisionsByFields[key].Count<DataField>((Func<DataField, bool>)(x => x.HasPrefix));
                }
            }
            return str;
        }

        public override byte[] PackBytes()
        {
            List<byte> byteList = new List<byte>();
            byteList.AddRange((IEnumerable<byte>)this.BuildRawHeader());
            if (this.HeaderData.Revision == 1 || this.HeaderData.Revision == 999)
            {
                byte[] bytes = this.ToBytes(this.BuildDataFieldsPackage(1, this.RevisionsByFields[this.HeaderData.Revision]));
                byteList.AddRange((IEnumerable<byte>)bytes);
            }
            else
            {
                int num = this.HeaderData.Revision != 998 ? this.HeaderData.Revision : 6;
                int prefixIndex = 1;
                for (int key = 2; key <= num; ++key)
                {
                    byte[] collection = this.BuildDataFieldsRawPackage(prefixIndex, this.RevisionsByFields[key]);
                    byteList.AddRange((IEnumerable<byte>)collection);
                    prefixIndex += this.RevisionsByFields[key].Count<DataField>((Func<DataField, bool>)(x => x.HasPrefix));
                }
            }
            return byteList.ToArray();
        }

        [Obsolete("Use Parse(byte[] package), this method will parse everything as ASCII, which will break packages above revision 1 because of byte fields")]
        public override Mid Parse(string package)
        {
            base.Parse(package);
            this.GetField(this.HeaderData.Revision, 8).Size = package.Length - this.GetField(this.HeaderData.Revision, 8).Index;
            this.ProcessDataFields(package, this.RevisionsByFields[this.HeaderData.Revision]);
            return (Mid)this;
        }

        private void ProcessDataFields(string package, List<DataField> fields)
        {
            byte[] bytes = Encoding.Default.GetBytes(package);
            foreach (DataField field in fields)
            {
                try
                {
                    Enumerable.Empty<byte>();
                    IEnumerable<byte> source = (IEnumerable<byte>)this.GetValue(field, bytes);
                    if (this.IsByteField(field))
                        field.RawValue = source.ToArray<byte>();
                    else
                        field.Value = this.ToAscii(source.ToArray<byte>());
                }
                catch (ArgumentOutOfRangeException ex)
                {
                }
            }
            int index = this.GetField(this.HeaderData.Revision, 8).Index;
            Array.Copy((Array)bytes, index, (Array)this.RawCurveData.rawData, 0, bytes.Length - index);
            if (this.RawCurveData.rawData.Length > 750)
                Array.Copy((Array)this.RawCurveData.rawData, 0, (Array)this.RawCurveData.rawData, 0, 750);
            this.CurveDecode();
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
      {
        {
          1,
          new List<DataField>()
          {
            new DataField(0, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(1, 24, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(2, 29, 14, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(3, 45, 14, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(4, 61, 14, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(5, 77, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(6, 83, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(7, 87, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(8, 91, 6, false)
          }
        },
        {
          2,
          new List<DataField>()
          {
            new DataField(0, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(1, 24, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(9, 29, 10, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(2, 41, 14, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(3, 57, 14, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(4, 73, 14, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(10, 89, 14, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(5, 105, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(6, 111, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(7, 115, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(8, 117, 6, false)
          }
        }
      };
        }

        private int GetCurrentRevisionIndex()
        {
            if (this.HeaderData.Revision == 999)
                return 999;
            return this.HeaderData.Revision > 1 ? 2 : 1;
        }

        private string BuildDataFieldsPackage(int prefixIndex, List<DataField> fields)
        {
            string str = string.Empty;
            foreach (DataField field in fields)
            {
                if (field.HasPrefix)
                {
                    str = str + prefixIndex.ToString().PadLeft(2, '0') + field.Value;
                    ++prefixIndex;
                }
                else
                    str += field.Value;
            }
            return str;
        }

        private byte[] BuildDataFieldsRawPackage(int prefixIndex, List<DataField> fields)
        {
            List<byte> byteList = new List<byte>();
            foreach (DataField field in fields)
            {
                if (field.HasPrefix)
                {
                    byte[] bytes = this.ToBytes(prefixIndex.ToString().PadLeft(2, '0'));
                    byteList.AddRange((IEnumerable<byte>)bytes);
                    ++prefixIndex;
                }
                if (this.IsByteField(field))
                    byteList.AddRange((IEnumerable<byte>)field.RawValue);
                else
                    byteList.AddRange((IEnumerable<byte>)this.ToBytes(field.Value));
            }
            return byteList.ToArray();
        }

        private bool IsByteField(DataField dataField) => dataField.Field == 8;

        private void CurveDecode()
        {
            byte[] rawData = this.RawCurveData.rawData;
            byte num1 = 0;
            int index1 = 0;
            foreach (byte num2 in this.RawCurveData.rawData)
            {
                if (num1 == byte.MaxValue)
                {
                    if (num2 == (byte)254)
                    {
                        this.RawCurveData.rawData[index1] = (byte)0;
                        ++index1;
                    }
                    else
                    {
                        if (num2 != byte.MaxValue)
                            throw new NotSupportedException();
                        this.RawCurveData.rawData[index1] = byte.MaxValue;
                        ++index1;
                    }
                }
                else
                {
                    switch (num2)
                    {
                        case 0:
                            throw new NotSupportedException();
                        case byte.MaxValue:
                            break;
                        default:
                            this.RawCurveData.rawData[index1] = (byte)((uint)num2 - 1U);
                            ++index1;
                            break;
                    }
                }
                num1 = num2;
            }
            int num3 = index1;
            int curveIndex = 0;
            int num4 = num3 % 6;
            for (int index2 = 0; index2 < num4; ++index2)
            {
                short t = System.BitConverter.ToInt16(this.RawCurveData.rawData, curveIndex);//.Skip<byte>(curveIndex).Take<byte>(2).Reverse<byte>().ToArray<byte>(), 0);
                curveIndex += 2;
                this.Torque.Add(t * (float)this.TorqueCoefficient);
                int andle = System.BitConverter.ToInt32(this.RawCurveData.rawData, curveIndex);
                curveIndex += 4;
                this.Angle.Add(andle * (float)this.AngleCoefficient);
                if (this.HeaderData.Revision == 2)
                {
                    int spd = System.BitConverter.ToInt32(this.RawCurveData.rawData, curveIndex);
                    curveIndex += 4;
                    this.Speed.Add(spd * 0.1f);
                }
            }
        }
        public override Mid Parse(byte[] frame)
        {

            byte[] header = frame.Skip(0).Take(20).ToArray();
            byte[] data = frame.Skip(20).Take(frame.Length - 20).ToArray();
            //帧头的解析
            int Length = int.Parse(Encoding.ASCII.GetString(header.Skip(0).Take(4).ToArray()));
            int Mid = int.Parse(Encoding.ASCII.GetString(header.Skip(4).Take(4).ToArray()));
            int Revision = int.Parse(Encoding.ASCII.GetString(header.Skip(8).Take(3).ToArray()));
            int NoAckFlag = header[11] - 30;
            if (Mid != 7410)
            {
                Console.WriteLine($" Mid {Mid} Not Curve ");
                return null;
            }
            Mid7410 m7410 = new Mid7410(Revision);
            m7410.HeaderData.NoAckFlag = NoAckFlag;
            m7410.HeaderData.Revision = Revision;
            try
            {
                //1.数据信息
                byte[] dataArray = data;
                m7410.ChannelId = int.Parse(Encoding.ASCII.GetString(dataArray.Skip(2).Take(2).ToArray()));
                m7410.ParameterSetId = int.Parse(Encoding.ASCII.GetString(dataArray.Skip(6).Take(3).ToArray()));   //pset号
                if (Revision == 2)
                {
                    m7410.TorqueCoefficient = float.Parse(Encoding.ASCII.GetString(dataArray.Skip(39).Take(14).ToArray()));  //扭矩系数
                    m7410.AngleCoefficient = float.Parse(Encoding.ASCII.GetString(dataArray.Skip(55).Take(14).ToArray()));   //角度系数

                    m7410.NumMeasurementPoints = int.Parse(Encoding.ASCII.GetString(dataArray.Skip(87).Take(4).ToArray()));   //点数
                    m7410.NumSegments = int.Parse(Encoding.ASCII.GetString(dataArray.Skip(93).Take(2).ToArray()));  //分了几帧
                    m7410.SegmentID = int.Parse(Encoding.ASCII.GetString(dataArray.Skip(97).Take(2).ToArray()));  //当前帧数
                    byte[] dataContent = dataArray.Skip(99).Take(dataArray.Length - 99).ToArray();
                    AnalysisCurveData(dataContent, ref m7410);
                }
                else
                {
                    m7410.TorqueCoefficient = float.Parse(Encoding.ASCII.GetString(dataArray.Skip(27).Take(14).ToArray()));  //扭矩系数
                    m7410.AngleCoefficient = float.Parse(Encoding.ASCII.GetString(dataArray.Skip(43).Take(14).ToArray()));   //角度系数
                    m7410.NumMeasurementPoints = int.Parse(Encoding.ASCII.GetString(dataArray.Skip(59).Take(4).ToArray()));   //点数
                    m7410.NumSegments = int.Parse(Encoding.ASCII.GetString(dataArray.Skip(65).Take(2).ToArray()));  //分了几帧
                    m7410.SegmentID = int.Parse(Encoding.ASCII.GetString(dataArray.Skip(69).Take(2).ToArray()));  //当前帧数
                    byte[] dataContent = dataArray.Skip(71).Take(dataArray.Length - 71).ToArray();
                    AnalysisCurveData(dataContent, ref m7410);
                }
                Console.WriteLine($"曲线解析 点数-> {m7410.Angle?.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"曲线解析出错 -> {ex.Message}");
                Console.WriteLine($"曲线解析出错 路径 -> {ex.StackTrace}");
            }
            return m7410;
        }
        private void AnalysisCurveData(byte[] oriData, ref Mid7410 m7410)
        {
            byte[] d = new byte[oriData.Length];
            int dindex = 0;
            for (int i = 0; i < oriData.Length; i++)
            {
                if (oriData[i] == 0xff)
                {
                    if (oriData[i + 1] == 0xff)
                    {
                        d[dindex++] = 0xfe;
                        i++;

                    }
                    else if (oriData[i + 1] == 0xfe)
                    {
                        d[dindex++] = 0xff;
                        i++;
                    }
                    else
                    {
                        d[dindex++] = (byte)(oriData[i] - 1);
                    }
                }
                else
                {
                    d[dindex++] = (byte)(oriData[i] - 1);
                }
            }
   

            switch (m7410.HeaderData.Revision)
            {
                case 1:
                    {
                        for (int j = 0; j < dindex - 1;)
                        {
                            m7410.Torque.Add(System.BitConverter.ToInt16(d, j) *0.01);
                            j += 2;
                            m7410.Angle.Add(System.BitConverter.ToInt32(d, j) * 0.1);
                            j += 4;
                        }
                    }
                    break;
                case 2:
                    {
                        for (int j = 0; j < dindex - 1; )
                        {
                            m7410.Torque.Add(System.BitConverter.ToInt16(d, j) * 0.01);
                            j += 2;
                            m7410.Angle.Add(System.BitConverter.ToInt32(d, j) * 0.1);
                            j += 4;
                            m7410.Speed.Add(System.BitConverter.ToInt16(d, j) * 0.1);
                            j += 2;
                        }
                    }
                    break;
                default:
                    break;
            }

        }
        public enum DataFields
        {
            CHANNEL_ID,
            PARAMETER_SET_ID,
            TIME_COEFFICIENT,
            TORQUE_COEFFICIENT,
            ANGLE_COEFFICIENT,
            NUM_MEASUREMENT_POINTS,
            NUM_SEGMENTS,
            SEGMENT_ID,
            CURVE_DATA,
            TIGHTENING_ID,
            SPEED_COEFFICIENT,
        }
    }
}
