
// Type: OpenProtocolInterpreter.PowerMACS.BoltData
using System;


namespace OpenProtocolInterpreter.PowerMACS
{
  public class BoltData
  {
    public int OrdinalBoltNumber { get; set; }

    public bool SimpleBoltStatus { get; set; }

    public TorqueStatus TorqueStatus { get; set; }

    public AngleStatus AngleStatus { get; set; }

    public Decimal BoltTorque { get; set; }

    public Decimal BoltAngle { get; set; }

    public Decimal BoltTorqueHighLimit { get; set; }

    public Decimal BoltTorqueLowLimit { get; set; }

    public Decimal BoltAngleHighLimit { get; set; }

    public Decimal BoltAngleLowLimit { get; set; }
  }
}
