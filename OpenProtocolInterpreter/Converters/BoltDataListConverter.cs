
// Type: OpenProtocolInterpreter.Converters.BoltDataListConverter
using OpenProtocolInterpreter.PowerMACS;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Converters
{
  public class BoltDataListConverter : AsciiConverter<IEnumerable<BoltData>>
  {
    private readonly IValueConverter<int> _intConverter;
    private readonly IValueConverter<bool> _boolConverter;
    private readonly IValueConverter<Decimal> _decimalConverter;
    private readonly int _totalBolts;

    public BoltDataListConverter(
      IValueConverter<int> intConverter,
      IValueConverter<bool> boolConverter,
      IValueConverter<Decimal> decimalConverter,
      int totalBolts)
    {
      this._intConverter = intConverter;
      this._boolConverter = boolConverter;
      this._decimalConverter = decimalConverter;
      this._totalBolts = totalBolts;
    }

    public override IEnumerable<BoltData> Convert(string value)
    {
      List<string> bolts = new List<string>();
      for (int i = 0; i < this._totalBolts; ++i)
        bolts.Add(value.Substring(i * 67, 67));
      foreach (string bolt in bolts)
        yield return new BoltData()
        {
          OrdinalBoltNumber = this._intConverter.Convert(bolt.Substring(2, 2)),
          SimpleBoltStatus = this._boolConverter.Convert(bolt.Substring(6, 1)),
          TorqueStatus = (TorqueStatus) this._intConverter.Convert(bolt.Substring(9, 1)),
          AngleStatus = (AngleStatus) this._intConverter.Convert(bolt.Substring(12, 1)),
          BoltTorque = this._decimalConverter.Convert(bolt.Substring(15, 7)),
          BoltAngle = this._decimalConverter.Convert(bolt.Substring(24, 7)),
          BoltTorqueHighLimit = this._decimalConverter.Convert(bolt.Substring(33, 7)),
          BoltTorqueLowLimit = this._decimalConverter.Convert(bolt.Substring(42, 7)),
          BoltAngleHighLimit = this._decimalConverter.Convert(bolt.Substring(51, 7)),
          BoltAngleLowLimit = this._decimalConverter.Convert(bolt.Substring(60, 7))
        };
    }

    public override string Convert(IEnumerable<BoltData> value)
    {
      string str = string.Empty;
      foreach (BoltData boltData in value)
      {
        str = str + "13" + this._intConverter.Convert('0', 2, DataField.PaddingOrientations.LEFT_PADDED, boltData.OrdinalBoltNumber);
        str = str + "14" + this._boolConverter.Convert(boltData.SimpleBoltStatus);
        str = str + "15" + this._intConverter.Convert((int) boltData.TorqueStatus);
        str = str + "16" + this._intConverter.Convert((int) boltData.AngleStatus);
        str = str + "17" + this._decimalConverter.Convert('0', 7, DataField.PaddingOrientations.RIGHT_PADDED, boltData.BoltTorque);
        str = str + "18" + this._decimalConverter.Convert('0', 7, DataField.PaddingOrientations.RIGHT_PADDED, boltData.BoltAngle);
        str = str + "19" + this._decimalConverter.Convert('0', 7, DataField.PaddingOrientations.RIGHT_PADDED, boltData.BoltTorqueHighLimit);
        str = str + "20" + this._decimalConverter.Convert('0', 7, DataField.PaddingOrientations.RIGHT_PADDED, boltData.BoltTorqueLowLimit);
        str = str + "21" + this._decimalConverter.Convert('0', 7, DataField.PaddingOrientations.RIGHT_PADDED, boltData.BoltAngleHighLimit);
        str = str + "22" + this._decimalConverter.Convert('0', 7, DataField.PaddingOrientations.RIGHT_PADDED, boltData.BoltAngleLowLimit);
      }
      return str;
    }

    public override string Convert(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      IEnumerable<BoltData> value)
    {
      return this.Convert(value);
    }
  }
}
