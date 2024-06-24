
// Type: OpenProtocolInterpreter.Converters.DateConverter
using System;


namespace OpenProtocolInterpreter.Converters
{
  public class DateConverter : AsciiConverter<DateTime>
  {
    public override DateTime Convert(string value)
    {
      DateTime result = DateTime.Now;
      if (!string.IsNullOrWhiteSpace(value.ToString()))
      {
        string str = value.ToString();
        DateTime.TryParse(str.Substring(0, 10) + " " + str.Substring(11, 8), out result);
      }
      return result;
    }

    public override string Convert(DateTime value) => value.ToString("yyyy-MM-dd:HH:mm:ss");

    public override string Convert(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      DateTime value)
    {
      return this.Convert(value);
    }
  }
}
