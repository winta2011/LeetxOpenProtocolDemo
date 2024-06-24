
// Type: OpenProtocolInterpreter.Converters.JobIdListConverter
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Converters
{
  public class JobIdListConverter : AsciiConverter<IEnumerable<int>>
  {
    private readonly IValueConverter<int> _intConverter;
    private readonly int _jobSize;

    public JobIdListConverter(IValueConverter<int> intConverter, int revision)
    {
      this._intConverter = intConverter;
      this._jobSize = revision > 1 ? 4 : 2;
    }

    public override IEnumerable<int> Convert(string value)
    {
      for (int i = 0; i < value.Length; i += this._jobSize)
        yield return this._intConverter.Convert(value.Substring(i, this._jobSize));
    }

    public override string Convert(IEnumerable<int> value)
    {
      string empty = string.Empty;
      foreach (int num in value)
        empty += this._intConverter.Convert('0', this._jobSize, DataField.PaddingOrientations.LEFT_PADDED, num);
      return empty;
    }

    public override string Convert(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      IEnumerable<int> value)
    {
      return this.Convert(value);
    }
  }
}
