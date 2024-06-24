
// Type: OpenProtocolInterpreter.Converters.ObjectDataListConverter
using OpenProtocolInterpreter.Result;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Converters
{
  public class ObjectDataListConverter : AsciiConverter<IEnumerable<ObjectData>>
  {
    private readonly IValueConverter<int> _intConverter;
    private readonly IValueConverter<bool> _boolConverter;

    public ObjectDataListConverter(
      IValueConverter<int> intConverter,
      IValueConverter<bool> boolConverter)
    {
      this._intConverter = intConverter;
      this._boolConverter = boolConverter;
    }

    public override IEnumerable<ObjectData> Convert(string value)
    {
      for (int i = 0; i < value.Length; i += 5)
        yield return new ObjectData()
        {
          Id = this._intConverter.Convert(value.Substring(i, 4)),
          Status = this._boolConverter.Convert(value.Substring(i + 4, 1))
        };
    }

    public override string Convert(IEnumerable<ObjectData> value)
    {
      string empty = string.Empty;
      foreach (ObjectData objectData in value)
      {
        empty += this._intConverter.Convert('0', 4, DataField.PaddingOrientations.LEFT_PADDED, objectData.Id);
        empty += this._boolConverter.Convert(objectData.Status);
      }
      return empty;
    }

    public override string Convert(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      IEnumerable<ObjectData> value)
    {
      return this.Convert(value);
    }
  }
}
