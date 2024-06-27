using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.Curve
{
    public class Mid7405 : Mid, ICurve, IController
    {
        private const int LAST_REVISION = 1;
        public const int MID = 7405;

        public Mid7405( int revision=1, bool noAckFlag = false) : base(MID, revision, noAckFlag)
        {
        }
    }
}
