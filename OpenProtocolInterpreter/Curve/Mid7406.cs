﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.Curve
{
    public class Mid7406 : Mid, ICurve, IController
    {
        private const int LAST_REVISION = 1;
        public const int MID = 7406;

        public Mid7406( int revision=1, bool noAckFlag = false) : base(MID, revision, noAckFlag)
        {
        }
    }
}
