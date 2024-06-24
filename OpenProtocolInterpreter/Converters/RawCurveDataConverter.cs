
// Type: OpenProtocolInterpreter.Converters.RawCurveDataConverter
using OpenProtocolInterpreter.Curve;


namespace OpenProtocolInterpreter.Converters
{
  internal class RawCurveDataConverter : BitConverter, IValueConverter<CurveData>
  {
    private readonly IValueConverter<byte[]> _byteArrayConverter;

    public RawCurveDataConverter(IValueConverter<byte[]> byteArrayConverter)
    {
      this._byteArrayConverter = byteArrayConverter;
    }

    public CurveData Convert(string value)
    {
      return this.ConvertFromBytes(this._byteArrayConverter.Convert(value));
    }

    public string Convert(CurveData value)
    {
      return this._byteArrayConverter.Convert(this.ConvertToBytes(value));
    }

    public string Convert(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      CurveData value)
    {
      return this.Convert(value);
    }

    public CurveData ConvertFromBytes(byte[] value)
    {
      return new CurveData() { rawData = value };
    }

    public byte[] ConvertToBytes(CurveData value) => value.rawData;

    public byte[] ConvertToBytes(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      CurveData value)
    {
      return this.ConvertToBytes(value);
    }
  }
}
