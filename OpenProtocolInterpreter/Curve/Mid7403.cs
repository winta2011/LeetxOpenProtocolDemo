using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.Curve
{
    /// <summary>
    /// 取消分布结果订阅
    /// </summary>
    public class Mid7403 : Mid, ICurve, IController
    {
        private const int LAST_REVISION = 1;
        public const int MID = 7403;

        public Mid7403(int revision = 1, bool noAckFlag = false) : base(MID, revision, noAckFlag)
        {
        }


    }
}
