using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.Curve
{

    /// <summary>
    /// Job结果
    /// </summary>
    public class Mid7406 : Mid, ICurve, IController
    {
        private const int LAST_REVISION = 1;
        public const int MID = 7406;

        /// <summary>
        /// 轴号
        /// </summary>
        public int SpindleNumber { get; set; }
        /// <summary>
        /// Pset
        /// </summary>
        public int CyCleNumber { get; set; }
        /// <summary>
        /// Vin/SN
        /// </summary>
        public string Vin { get; set; }

        public string TimeStamp { get; set; }

        public string SpindleName { get; set; }

        /// <summary>
        /// 工具序列号
        /// </summary>
        public string SpindleSN { get; set; }

        /// <summary>
        /// It’s the total number of tightenings of the tool
        /// </summary>
        public long ToolTightedCnt{ get; set; }

        /// <summary>
        /// It’s the partial number of tightenings of the tool
        /// </summary>
        public long ToolPartialCnt { get; set; }

        public int BatchSize { get; set; }
        public int BatchCnt { get; set; }
        public Mid7406() : base(MID, LAST_REVISION)
        {

        }
        public Mid7406( int revision=1, bool noAckFlag = false) : base(MID, revision, noAckFlag)
        {
        }

        public override Mid Parse(byte[] data)
        {

            base.Parse(data);
            var s =Encoding.ASCII.GetString(data);
            SpindleNumber=int.Parse(s.Substring(22,2)); //22+2+2 =26
            CyCleNumber =int.Parse(s.Substring(26,3));  // 26+3+2 = 31
            Vin =s.Substring(31,25); //31 + 25 + 2  = 58
            TimeStamp = s.Substring(58, 19); //58+19+2 =79
            SpindleName = s.Substring(79, 11); //79 + 11 + 2 = 92
            SpindleSN = s.Substring(92, 11); // 92 + 11 + 2 = 105
            ToolTightedCnt = long.Parse(s.Substring(105,10)); // 105 + 10 + 2 = 117
            ToolPartialCnt = long.Parse(s.Substring(117, 10)); // 117+ 10 +2 = 129
            BatchSize = int.Parse(s.Substring(129, 3)); // 129 + 3 + 2 = 124
            BatchSize = int.Parse(s.Substring(134, 3)); //134+3=137

            return this;
        }
    }
}
