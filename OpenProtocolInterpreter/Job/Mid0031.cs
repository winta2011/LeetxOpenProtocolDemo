
// Type: OpenProtocolInterpreter.Job.Mid0031
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OpenProtocolInterpreter.Job
{
  public class Mid0031 : Mid, IJob, IController
  {
    private readonly IValueConverter<int> _intConverter;
    private JobIdListConverter _jobListConverter;
    private const int LAST_REVISION = 1;
    public const int MID = 31;

    public int TotalJobs
    {
      get => this.GetField(1, 0).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      private set
      {
        this.GetField(1, 0).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public List<int> JobIds { get; set; }

    public Mid0031()
      : this(1)
    {
    }

    public Mid0031(int revision = 1)
      : base(31, revision)
    {
      this._intConverter = (IValueConverter<int>) new Int32Converter();
      if (this.JobIds == null)
        this.JobIds = new List<int>();
      this.HandleRevisions();
    }

    public Mid0031(int totalJobs, IEnumerable<int> jobIds, int revision = 1)
      : this(revision)
    {
      this.TotalJobs = totalJobs;
      this.JobIds = jobIds.ToList<int>();
    }

    public override string Pack()
    {
      this._jobListConverter = new JobIdListConverter(this._intConverter, this.HeaderData.Revision);
      this.TotalJobs = this.JobIds.Count;
      DataField field = this.GetField(1, 1);
      field.Size = (this.HeaderData.Revision > 1 ? 4 : 2) * this.TotalJobs;
      field.Value = this._jobListConverter.Convert((IEnumerable<int>) this.JobIds);
      return base.Pack();
    }

    public override Mid Parse(string package)
    {
      this.HeaderData = this.ProcessHeader(package);
      this.HandleRevisions();
      this._jobListConverter = new JobIdListConverter(this._intConverter, this.HeaderData.Revision);
      DataField field = this.GetField(1, 1);
      field.Size = package.Length - field.Index;
      base.Parse(package);
      this.JobIds = this._jobListConverter.Convert(field.Value).ToList<int>();
      return (Mid) this;
    }

    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
      return new Dictionary<int, List<DataField>>()
      {
        {
          1,
          new List<DataField>()
          {
            new DataField(0, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
            new DataField(1, 22, 2, '0', DataField.PaddingOrientations.LEFT_PADDED, false)
          }
        },
        {
          2,
          new List<DataField>()
        }
      };
    }

    public bool Validate(out IEnumerable<string> errors)
    {
      List<string> stringList = new List<string>();
      if (this.HeaderData.Revision > 1)
      {
        if (this.TotalJobs < 0 || this.TotalJobs > 9999)
          stringList.Add(new ArgumentOutOfRangeException("TotalJobs", "Range: 0000-9999").Message);
        for (int index = 0; index < this.JobIds.Count; ++index)
        {
          int jobId = this.JobIds[index];
          if (jobId < 0 || jobId > 9999)
            stringList.Add(new ArgumentOutOfRangeException("JobIds", string.Format("Failed at index[{0}] => Range: 0000-9999", (object) index)).Message);
        }
      }
      else
      {
        if (this.TotalJobs < 0 || this.TotalJobs > 99)
          stringList.Add(new ArgumentOutOfRangeException("TotalJobs", "Range: 00-99").Message);
        for (int index = 0; index < this.JobIds.Count; ++index)
        {
          int jobId = this.JobIds[index];
          if (jobId < 0 || jobId > 99)
            stringList.Add(new ArgumentOutOfRangeException("JobIds", string.Format("Failed at index[{0}] => Range: 00-99", (object) index)).Message);
        }
      }
      errors = (IEnumerable<string>) stringList;
      return errors.Any<string>();
    }

    private void HandleRevisions()
    {
      if (this.HeaderData.Revision > 1)
      {
        this.GetField(1, 1).Index = 24;
        this.GetField(1, 0).Size = 4;
      }
      else
        this.GetField(1, 0).Size = this.GetField(1, 1).Size = 2;
    }

    public enum DataFields
    {
      NUMBER_OF_JOBS,
      EACH_JOB_ID,
    }
  }
}
