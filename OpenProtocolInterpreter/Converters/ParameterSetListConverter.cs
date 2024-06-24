using System.Collections.Generic;
using System.Linq;


namespace OpenProtocolInterpreter.Converters
{
    public class ParameterSetListConverter : AsciiConverter<IEnumerable<Job.ParameterSet>>
  {
    private readonly int _revision;
    private readonly IValueConverter<int> _intConverter;
    private readonly IValueConverter<bool> _boolConverter;

    public ParameterSetListConverter(
      IValueConverter<int> intConverter,
      IValueConverter<bool> boolConverter,
      int revision)
    {
      this._revision = revision;
      this._intConverter = intConverter;
      this._boolConverter = boolConverter;
    }

    public override IEnumerable<Job.ParameterSet> Convert(string value)
    {
      List<string> parameterSets = ((IEnumerable<string>) value.Split(';')).ToList<string>();
      parameterSets.RemoveAt(parameterSets.Count - 1);
      foreach (string psetData in parameterSets)
      {
        string[] fields = psetData.Split(':');
                Job.ParameterSet pset = new Job.ParameterSet()
        {
          ChannelId = this._intConverter.Convert(fields[0]),
          TypeId = this._intConverter.Convert(fields[1]),
          AutoValue = this._boolConverter.Convert(fields[2]),
          BatchSize = this._intConverter.Convert(fields[3])
        };
        if (this._revision > 2)
        {
          pset.Socket = this._intConverter.Convert(fields[4]);
          pset.JobStepName = fields[5];
          pset.JobStepType = this._intConverter.Convert(fields[6]);
        }
        yield return pset;
        fields = (string[]) null;
        pset = (Job.ParameterSet) null;
      }
    }

    public override string Convert(IEnumerable<Job.ParameterSet> value)
    {
      List<string> values1 = new List<string>();
      foreach (Job.ParameterSet parameterSet in value)
      {
        List<string> values2 = new List<string>()
        {
          this._intConverter.Convert('0', 2, DataField.PaddingOrientations.LEFT_PADDED, parameterSet.ChannelId),
          this._intConverter.Convert('0', 3, DataField.PaddingOrientations.LEFT_PADDED, parameterSet.TypeId),
          this._boolConverter.Convert(parameterSet.AutoValue),
          this._intConverter.Convert('0', 2, DataField.PaddingOrientations.LEFT_PADDED, parameterSet.BatchSize)
        };
        if (this._revision > 2)
        {
          values2.Add(this._intConverter.Convert('0', 2, DataField.PaddingOrientations.LEFT_PADDED, parameterSet.Socket));
          values2.Add(parameterSet.JobStepName.PadRight(25));
          values2.Add(this._intConverter.Convert('0', 2, DataField.PaddingOrientations.LEFT_PADDED, parameterSet.JobStepType));
        }
        values1.Add(string.Join(":", (IEnumerable<string>) values2));
      }
      return string.Join(";", (IEnumerable<string>) values1) + ";";
    }

    public override string Convert(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      IEnumerable<Job.ParameterSet> value)
    {
      return this.Convert(value);
    }
  }
}
