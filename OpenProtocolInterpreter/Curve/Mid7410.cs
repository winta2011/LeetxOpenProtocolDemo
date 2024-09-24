
// Type: OpenProtocolInterpreter.Curve.Mid7410
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OpenProtocolInterpreter.Curve
{
    public class Mid7410 : Mid, ICurve, IController
    {
        private const int LAST_REVISION = 2;
        public const int MID = 7410;
        private const int MaxCurveDataLength = 750;

        public int ChannelId
        {
            get; set;
        }

        public int ParameterSetId
        {
            get; set;
        }

        public double TimeCoefficient
        {
            get; set;
        }

        public double TorqueCoefficient
        {
            get; set;
        }

        public double AngleCoefficient
        {
            get; set;
        }

        public int NumMeasurementPoints
        {
            get; set;
        }

        public int NumSegments
        {
            get; set;
        }

        public int SegmentID
        {
            get; set;
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
            Torque = new List<double>();
            Angle = new List<double>();
            Speed = new List<double>();
        }


        [Obsolete("Always Null", true)]
        protected override string BuildHeader()
        {

            return "";
        }

        [Obsolete("Always Null", true)]
        public override string Pack()
        {

            return "";
        }
        [Obsolete("Always Null", true)]
        public override byte[] PackBytes()
        {
            return null;
        }

        public override Mid Parse(string package)
        {
            return this.Parse(Encoding.ASCII.GetBytes(package));
        }




        public override Mid Parse(byte[] frame)
        {

            byte[] header = frame.Skip(0).Take(20).ToArray();
            byte[] dataArray = frame.Skip(20).Take(frame.Length - 20).ToArray();
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
            m7410.Header.Length = Length;
            m7410.Header.NoAckFlag = NoAckFlag == 1;
            m7410.Header.Revision = Revision;
            try
            {
                //1.数据信息
                m7410.ChannelId = int.Parse(Encoding.ASCII.GetString(dataArray.Skip(2).Take(2).ToArray()));
                m7410.ParameterSetId = int.Parse(Encoding.ASCII.GetString(dataArray.Skip(6).Take(3).ToArray()));   //pset号
                if (Revision == 2)
                {
                    m7410.TorqueCoefficient = double.Parse(Encoding.ASCII.GetString(dataArray.Skip(39).Take(14).ToArray()));  //扭矩系数
                    m7410.AngleCoefficient = double.Parse(Encoding.ASCII.GetString(dataArray.Skip(55).Take(14).ToArray()));   //角度系数
                    m7410.NumMeasurementPoints = int.Parse(Encoding.ASCII.GetString(dataArray.Skip(87).Take(4).ToArray()));   //点数
                    m7410.NumSegments = int.Parse(Encoding.ASCII.GetString(dataArray.Skip(93).Take(2).ToArray()));  //分了几帧
                    m7410.SegmentID = int.Parse(Encoding.ASCII.GetString(dataArray.Skip(97).Take(2).ToArray()));  //当前帧数
                    byte[] dataContent = dataArray.Skip(99).Take(dataArray.Length - 99).ToArray();
                    AnalysisCurveData(dataContent, ref m7410);
                }
                else
                {
                    m7410.TorqueCoefficient = double.Parse(Encoding.ASCII.GetString(dataArray.Skip(27).Take(14).ToArray()));  //扭矩系数
                    m7410.AngleCoefficient = double.Parse(Encoding.ASCII.GetString(dataArray.Skip(43).Take(14).ToArray()));   //角度系数
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
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            switch (m7410.Header.Revision)
            {

                case 1:
                    {
                        for (int j = 0; j < dindex - 1;)
                        {
                            if (m7410.TorqueCoefficient == 0.01)
                            {

                                m7410.Torque.Add(BitConverter.ToInt16(d, j) * m7410.TorqueCoefficient);
                                j += 2;
                                m7410.Angle.Add(BitConverter.ToInt32(d, j) * 0.1);
                                j += 4;
                            }

                            else
                            {
                                m7410.Torque.Add(BitConverter.ToUInt16(d, j) * m7410.TorqueCoefficient);
                                j += 2;
                                m7410.Angle.Add(BitConverter.ToUInt32(d, j) * 0.1);
                                j += 4;
                            }
                        }
                    }
                    break;
                case 2:
                    {
                        for (int j = 0; j < dindex - 1;)
                        {
                            if (m7410.TorqueCoefficient == 0.01)
                            {
                                m7410.Torque.Add(BitConverter.ToInt16(d, j) * 0.01);
                                j += 2;
                                m7410.Angle.Add(BitConverter.ToInt32(d, j) * 0.1);
                                j += 4;
                                m7410.Speed.Add(BitConverter.ToInt16(d, j) * 0.1);
                                j += 2;
                            }
                            else
                            {
                                m7410.Torque.Add(BitConverter.ToUInt16(d, j) * m7410.TorqueCoefficient);
                                j += 2;
                                m7410.Angle.Add(BitConverter.ToUInt32(d, j) * 0.1);
                                j += 4;
                                m7410.Speed.Add(BitConverter.ToUInt16(d, j) * 0.1);
                                j += 2;
                            }
                        }
                    }
                    break;
                default:
                    break;
            }

        }
    }
}
