using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.Curve
{
    public class Mid7404 : Mid, ICurve, IController
    {
        private const int LAST_REVISION = 1;
        public const int MID = 7404;

        public Mid7404():base(7404,1)
        {

        }
        public Mid7404( int revision=1, bool noAckFlag = false) : base(MID, revision, noAckFlag)
        {
        }

        public int SpindleNO { get; set; }
        /// <summary>
        /// Pset
        /// </summary>
        public int CycleNumber { get; set; }
        /// <summary>
        /// 分步号
        /// </summary>
        public int PhaseNumber { get; set; }
        public string PhaseName { get; set; }

        public int MethodName { get; set; }

        public double MinTorque { get; set; }
        public double MaxTorque { get; set; }
        public double SafeTorque { get; set; }
        public double TargetTorque { get; set; }

        public double AngleThreshold { get; set; }
        public double ResultTorque { get; set; }
        public double MinAngle { get; set; }
        public double MaxAngle { get; set; }
        public double SafeAngle { get; set; }
        public double TargetAngle { get; set; }
        public double ResulttAngle { get; set; }
        public int CurveIndex1 { get; set; }
        public int CurveIndex2 { get; set; }
        public bool IsOK { get; set; }

        public override Mid Parse(byte[] buff)
        {
            base.Parse(buff);
            var s = Encoding.ASCII.GetString(buff);

            SpindleNO = int.Parse(s.Substring(22, 2));  
            CycleNumber = int.Parse(s.Substring(26, 3)); 
            PhaseNumber = int.Parse(s.Substring(31, 2)); 
    
            MinTorque = double.Parse(s.Substring(43, 6))/100;  
            MaxTorque = double.Parse(s.Substring(51, 6)) / 100;
            SafeTorque = double.Parse(s.Substring(59, 6)) / 100;
            AngleThreshold = double.Parse(s.Substring(67, 6)) / 100;
            TargetTorque = double.Parse(s.Substring(75, 6)) / 100;
            ResultTorque = double.Parse(s.Substring(83, 6)) / 100;
            MinAngle = double.Parse(s.Substring(91, 6)) / 10;
            MaxAngle = double.Parse(s.Substring(99, 6)) / 10;
            SafeAngle = double.Parse(s.Substring(107, 6)) / 10;
            TargetAngle = double.Parse(s.Substring(115, 2)) / 10;
            ResulttAngle = double.Parse(s.Substring(123, 6)) / 10;
     
            CurveIndex1 = int.Parse(s.Substring(207,4));
            CurveIndex2 = int.Parse(s.Substring(213,4)); 
        
            IsOK = s.Substring(267, 10)== "0268435456";

            return this;
        }
    }
}
