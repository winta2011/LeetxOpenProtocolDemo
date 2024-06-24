using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Leetx.OpenProtocol
{
    public class TighteningResult:PropertyChangedEvent
    {
    
        bool _ResultOK = false;
        public bool ResultOK { get { return _ResultOK; } set { _ResultOK = value; RaisePropertyChanged(); } }
        string _BorderColor = "LightGray";
        public string BorderColor { get { return _BorderColor; } set { _BorderColor = value; RaisePropertyChanged(); } }
        string _ToolSerialNumber = "";
        public string ToolSerialNumber { get { return _ToolSerialNumber; } set { _ToolSerialNumber = value; RaisePropertyChanged(); } }
        public int ChannelId { get; set; }
        long _TighteningID = 0;
        public long TighteningID { get { return _TighteningID; } set { _TighteningID = value; RaisePropertyChanged(); } }
        public float TorqueMinLimit { get; set; }
        public float TorqueMaxLimit { get; set; }
        public float TorqueFinalTarget { get; set; }
        float _Torque;
        public float Torque { get { return _Torque; } set { _Torque = value; RaisePropertyChanged(); } }
        public float AngleMinLimit { get; set; }
        public float AngleMaxLimit { get; set; }
        public float AngleFinalTarget { get; set; }
        float _Angle;
        public float Angle { get { return _Angle; } set { _Angle = value; RaisePropertyChanged(); } }
        public DateTime Timestamp { get; set; }
        public DateTime ReceiveTimestamp { get; set; }
        public string VinNumber { get; set; }
        public int PSetId { get; set; }
        public int JobId { get; set; }

        int _TorqueOK = 0;
        public int TorqueOK { get { return _TorqueOK; } set { _TorqueOK = value; RaisePropertyChanged(); } }
        int _AngleOK = 0;
        public int AngleOK { get { return _AngleOK; } set { _AngleOK = value; RaisePropertyChanged(); } }
        int _CurveOK = 0;
        public int CurveOK { get { return _CurveOK; } set { _CurveOK = value; RaisePropertyChanged(); } }
        float[] _CurveTorque = new float[2000]; //最大2000个点
        public float[] CurveTorque { get { return _CurveTorque; } set { _CurveTorque = value; RaisePropertyChanged(); } }
        float[] _CurveAngle = new float[2000];
        public float[] CurveAngle { get { return _CurveAngle; } set { _CurveAngle = value; RaisePropertyChanged(); } }
        int _CurveFraming = 0;
        public int CurveFraming { get { return _CurveFraming; } set { _CurveFraming = value; RaisePropertyChanged(); } }
        int _CurveCurrentFrame = 0;
        public int CurveCurrentFrame { get { return _CurveCurrentFrame; } set { _CurveCurrentFrame = value; RaisePropertyChanged(); } }

    }
}
