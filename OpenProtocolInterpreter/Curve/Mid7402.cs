using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.Curve
{
    /// <summary>
    /// 分步结果订阅
    /// </summary>
    public class Mid7402 : Mid, ICurve, IController
    {
        private const int LAST_REVISION = 1;
        public const int MID = 7402;

        public Mid7402( int revision=1, bool noAckFlag = false) : base(MID, revision, noAckFlag)
        {
        }
    }
}
