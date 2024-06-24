
// Type: OpenProtocolInterpreter.Job.Mid0035
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OpenProtocolInterpreter.Job
{
  public class Mid0035 : Mid, IJob, IController
  {
    private readonly IValueConverter<int> _intConverter;
    private readonly IValueConverter<DateTime> _datetimeConverter;
    public const int MID = 35;
    private const int LAST_REVISION = 4;

    public int JobId
    {
      get => this.GetField(1, 0).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 0).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public JobStatus JobStatus
    {
      get
      {
        return (JobStatus) this.GetField(1, 1).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 1).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public JobBatchMode JobBatchMode
    {
      get
      {
        return (JobBatchMode) this.GetField(1, 2).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 2).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public int JobBatchSize
    {
      get => this.GetField(1, 3).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 3).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int JobBatchCounter
    {
      get => this.GetField(1, 4).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 4).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public DateTime TimeStamp
    {
      get
      {
        return this.GetField(1, 5).GetValue<DateTime>(new Func<string, DateTime>(this._datetimeConverter.Convert));
      }
      set
      {
        this.GetField(1, 5).SetValue<DateTime>(new Func<char, int, DataField.PaddingOrientations, DateTime, string>(this._datetimeConverter.Convert), value);
      }
    }

    public int JobCurrentStep
    {
      get => this.GetField(3, 6).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(3, 6).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int JobTotalNumberOfSteps
    {
      get => this.GetField(3, 7).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(3, 7).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int JobStepType
    {
      get => this.GetField(3, 8).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(3, 8).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public JobTighteningStatus JobTighteningStatus
    {
      get
      {
        return (JobTighteningStatus) this.GetField(4, 9).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(4, 9).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public int JobSequenceNumber
    {
      get => this.GetField(5, 10).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(5, 10).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public string VinNumber
    {
      get => this.GetField(5, 11).Value;
      set => this.GetField(5, 11).SetValue(value);
    }

    public string IdentifierResultPart2
    {
      get => this.GetField(5, 12).Value;
      set => this.GetField(5, 12).SetValue(value);
    }

    public string IdentifierResultPart3
    {
      get => this.GetField(5, 13).Value;
      set => this.GetField(5, 13).SetValue(value);
    }

    public string IdentifierResultPart4
    {
      get => this.GetField(5, 14).Value;
      set => this.GetField(5, 14).SetValue(value);
    }

    public Mid0035()
      : this(4, new int?(0))
    {
    }

    public Mid0035(int revision = 4, int? noAckFlag = 0)
      : base(35, revision, noAckFlag)
    {
      this._intConverter = (IValueConverter<int>) new Int32Converter();
      this._datetimeConverter = (IValueConverter<DateTime>) new DateConverter();
      this.HandleRevision();
    }

    public Mid0035(
      int jobId,
      JobStatus jobStatus,
      JobBatchMode jobBatchMode,
      int jobBatchSize,
      int jobBatchCounter,
      DateTime timestamp,
      int revision = 2,
      int? noAckFlag = 0)
      : this(revision, noAckFlag)
    {
      this.JobId = jobId;
      this.JobStatus = jobStatus;
      this.JobBatchMode = jobBatchMode;
      this.JobBatchSize = jobBatchSize;
      this.JobBatchCounter = jobBatchCounter;
      this.TimeStamp = timestamp;
    }

    public Mid0035(
      int jobId,
      JobStatus jobStatus,
      JobBatchMode jobBatchMode,
      int jobBatchSize,
      int jobBatchCounter,
      DateTime timestamp,
      int jobCurrentStep,
      int jobTotalNumberOfSteps,
      int jobStepType,
      int revision = 3,
      int? noAckFlag = 0)
      : this(jobId, jobStatus, jobBatchMode, jobBatchSize, jobBatchCounter, timestamp, revision, noAckFlag)
    {
      this.JobCurrentStep = jobCurrentStep;
      this.JobTotalNumberOfSteps = jobTotalNumberOfSteps;
      this.JobStepType = jobStepType;
    }

    public Mid0035(
      int jobId,
      JobStatus jobStatus,
      JobBatchMode jobBatchMode,
      int jobBatchSize,
      int jobBatchCounter,
      DateTime timestamp,
      JobTighteningStatus jobTighteningStatus,
      int revision = 4,
      int? noAckFlag = 0)
      : this(jobId, jobStatus, jobBatchMode, jobBatchSize, jobBatchCounter, timestamp, revision, noAckFlag)
    {
      this.JobTighteningStatus = jobTighteningStatus;
    }

    public override Mid Parse(string package)
    {
      this.HeaderData = this.ProcessHeader(package);
      this.HandleRevision();
      this.ProcessDataFields(package);
      return (Mid) this;
    }

    public bool Validate(out IEnumerable<string> errors)
    {
      List<string> stringList = new List<string>();
      if (this.HeaderData.Revision == 1)
      {
        if (this.JobId < 0 || this.JobId > 99)
          stringList.Add(new ArgumentOutOfRangeException("JobId", "Range: 00-99").Message);
      }
      else if (this.JobId < 0 || this.JobId > 9999)
        stringList.Add(new ArgumentOutOfRangeException("JobId", "Range: 0000-9999").Message);
      if (this.JobBatchSize < 0 || this.JobBatchSize > 9999)
        stringList.Add(new ArgumentOutOfRangeException("JobBatchSize", "Range: 0000-9999").Message);
      if (this.JobBatchCounter < 0 || this.JobBatchCounter > 9999)
        stringList.Add(new ArgumentOutOfRangeException("JobBatchCounter", "Range: 0000-9999").Message);
      if (this.HeaderData.Revision == 3)
      {
        if (this.JobCurrentStep < 0 || this.JobCurrentStep > 999)
          stringList.Add(new ArgumentOutOfRangeException("JobCurrentStep", "Range: 000-999").Message);
        if (this.JobTotalNumberOfSteps < 0 || this.JobTotalNumberOfSteps > 999)
          stringList.Add(new ArgumentOutOfRangeException("JobTotalNumberOfSteps", "Range: 000-999").Message);
        if (this.JobStepType < 0 || this.JobStepType > 99)
          stringList.Add(new ArgumentOutOfRangeException("JobStepType", "Range: 00-99").Message);
      }
      errors = (IEnumerable<string>) stringList;
      return errors.Any<string>();
    }

    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
      return new Dictionary<int, List<DataField>>()
      {
        {
          1,
          new List<DataField>()
          {
            new DataField(0, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(1, 24, 1),
            new DataField(2, 27, 1),
            new DataField(3, 30, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(4, 36, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(5, 42, 19)
          }
        },
        {
          2,
          new List<DataField>()
        },
        {
          3,
          new List<DataField>()
          {
            new DataField(6, 65, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(7, 70, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(8, 75, 2, '0', DataField.PaddingOrientations.LEFT_PADDED)
          }
        },
        {
          4,
          new List<DataField>()
          {
            new DataField(9, 79, 2, ' ', DataField.PaddingOrientations.LEFT_PADDED)
          }
        },
        {
          5,
          new List<DataField>()
          {
            new DataField(10, 83, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(11, 90, 25, ' ', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(12, 117, 25, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(13, 144, 25, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(14, 171, 25, '0', DataField.PaddingOrientations.LEFT_PADDED)
          }
        }
      };
    }

    private void HandleRevision()
    {
      DataField field1 = this.GetField(1, 0);
      field1.Size = this.HeaderData.Revision <= 1 ? 2 : 4;
      int num = field1.Index + field1.Size;
      for (int field2 = 1; field2 < this.RevisionsByFields[1].Count; ++field2)
      {
        DataField field3 = this.GetField(1, field2);
        field3.Index = 2 + num;
        num = field3.Index + field3.Size;
      }
    }
  }
}
