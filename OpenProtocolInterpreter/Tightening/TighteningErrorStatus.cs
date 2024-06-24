
// Type: OpenProtocolInterpreter.Tightening.TighteningErrorStatus

namespace OpenProtocolInterpreter.Tightening
{
  public class TighteningErrorStatus
  {
    public bool RundownAngleMaxShutOff { get; set; }

    public bool RundownAngleMinShutOff { get; set; }

    public bool TorqueMaxShutOff { get; set; }

    public bool AngleMaxShutOff { get; set; }

    public bool SelftapTorqueMaxShutOff { get; set; }

    public bool SelftapTorqueMinShutOff { get; set; }

    public bool PrevailTorqueMaxShutOff { get; set; }

    public bool PrevailTorqueMinShutOff { get; set; }

    public bool PrevailTorqueCompensateOverflow { get; set; }

    public bool CurrentMonitoringMaxShutOff { get; set; }

    public bool PostViewTorqueMinTorqueShutOff { get; set; }

    public bool PostViewTorqueMaxTorqueShutOff { get; set; }

    public bool PostViewTorqueAngleTooSmall { get; set; }

    public bool TriggerLost { get; set; }

    public bool TorqueLessThanTarget { get; set; }

    public bool ToolHot { get; set; }

    public bool MultistageAbort { get; set; }

    public bool Rehit { get; set; }

    public bool DsMeasureFailed { get; set; }

    public bool CurrentLimitReached { get; set; }

    public bool EndTimeOutShutOff { get; set; }

    public bool RemoveFastenerLimitExceeded { get; set; }

    public bool DisableDrive { get; set; }

    public bool TransducerLost { get; set; }

    public bool TransducerShorted { get; set; }

    public bool TransducerCorrupt { get; set; }

    public bool SyncTimeout { get; set; }

    public bool DynamicCurrentMonitoringMin { get; set; }

    public bool DynamicCurrentMonitoringMax { get; set; }

    public bool AngleMaxMonitor { get; set; }

    public bool YieldNutOff { get; set; }

    public bool YieldTooFewSamples { get; set; }
  }
}
