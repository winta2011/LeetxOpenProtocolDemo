
// Type: OpenProtocolInterpreter.MultiSpindle.SpindleOrPressStatus
using System;


namespace OpenProtocolInterpreter.MultiSpindle
{
  public class SpindleOrPressStatus
  {
    public int SpindleOrPressNumber { get; set; }

    public int ChannelId { get; set; }

    public bool OverallStatus { get; set; }

    public TighteningValueStatus TorqueOrForceStatus { get; set; }

    public Decimal TorqueOrForce { get; set; }

    public bool AngleOrStrokeStatus { get; set; }

    public int AngleOrStroke { get; set; }
  }
}
