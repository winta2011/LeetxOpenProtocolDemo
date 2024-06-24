
// Type: OpenProtocolInterpreter.Tightening.TighteningErrorStatus2

namespace OpenProtocolInterpreter.Tightening
{
  public class TighteningErrorStatus2
  {
    public bool DriveDeactivated { get; set; }

    public bool ToolStall { get; set; }

    public bool DriveHot { get; set; }

    public bool GradientMonitoringHigh { get; set; }

    public bool GradientMonitoringLow { get; set; }

    public bool ReactionBarFailed { get; set; }

    public byte[] Reserved { get; set; }
  }
}
