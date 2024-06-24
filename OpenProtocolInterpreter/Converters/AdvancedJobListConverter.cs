
// Type: OpenProtocolInterpreter.Converters.AdvancedJobListConverter
using OpenProtocolInterpreter.Job.Advanced;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Converters
{
  public class AdvancedJobListConverter : AsciiConverter<IEnumerable<AdvancedJob>>
  {
    private readonly IValueConverter<int> _intConverter;
    private readonly IValueConverter<bool> _boolConverter;
    private readonly int _revision;

    public AdvancedJobListConverter(
      IValueConverter<int> intConverter,
      IValueConverter<bool> boolConverter,
      int revision)
    {
      this._intConverter = intConverter;
      this._boolConverter = boolConverter;
      this._revision = revision;
    }

    public override string Convert(IEnumerable<AdvancedJob> value)
    {
      List<string> values1 = new List<string>();
      foreach (AdvancedJob advancedJob in value)
      {
        List<string> values2 = new List<string>()
        {
          this._intConverter.Convert('0', 2, DataField.PaddingOrientations.LEFT_PADDED, advancedJob.ChannelId),
          this._intConverter.Convert('0', 3, DataField.PaddingOrientations.LEFT_PADDED, advancedJob.ProgramId),
          this._boolConverter.Convert(advancedJob.AutoSelect),
          this._intConverter.Convert('0', 2, DataField.PaddingOrientations.LEFT_PADDED, advancedJob.BatchSize),
          this._intConverter.Convert('0', 2, DataField.PaddingOrientations.LEFT_PADDED, advancedJob.MaxCoherentNok)
        };
        if (this._revision == 999)
          values2.Add(this._intConverter.Convert('0', 2, DataField.PaddingOrientations.LEFT_PADDED, advancedJob.BatchCounter));
        values1.Add(string.Join(":", (IEnumerable<string>) values2));
      }
      return string.Join(";", (IEnumerable<string>) values1);
    }

    public override string Convert(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      IEnumerable<AdvancedJob> value)
    {
      return this.Convert(value);
    }

    public override IEnumerable<AdvancedJob> Convert(string value)
    {
      string[] strArray = value.Split(';');
      for (int index = 0; index < strArray.Length; ++index)
      {
        string advancedJob = strArray[index];
        string[] fields = advancedJob.Split(':');
        yield return new AdvancedJob()
        {
          ChannelId = this._intConverter.Convert(fields[0]),
          ProgramId = this._intConverter.Convert(fields[1]),
          AutoSelect = this._boolConverter.Convert(fields[2]),
          BatchSize = this._intConverter.Convert(fields[3]),
          MaxCoherentNok = this._intConverter.Convert(fields[4]),
          BatchCounter = this._revision == 999 ? this._intConverter.Convert(fields[5]) : 0
        };
        fields = (string[]) null;
        advancedJob = (string) null;
      }
      strArray = (string[]) null;
    }
  }
}
