
// Type: OpenProtocolInterpreter.Job.Mid0032
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OpenProtocolInterpreter.Job
{
  public class Mid0032 : Mid, IJob, IIntegrator
  {
    private readonly IValueConverter<int> _intConverter;
    private const int LAST_REVISION = 3;
    public const int MID = 32;

    public int JobId
    {
      get => this.GetField(1, 0).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 0).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public Mid0032()
      : this(3)
    {
    }

    public Mid0032(int revision = 3)
      : base(32, revision)
    {
      this._intConverter = (IValueConverter<int>) new Int32Converter();
      this.HandleRevision();
    }

    public Mid0032(int jobId, int revision = 2)
      : this(revision)
    {
      this.JobId = jobId;
    }

    public override Mid Parse(string package)
    {
      this.HeaderData = this.ProcessHeader(package);
      this.HandleRevision();
      this.ProcessDataFields(package);
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
            new DataField(0, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED, false)
          }
        },
        {
          2,
          new List<DataField>()
        },
        {
          3,
          new List<DataField>()
        }
      };
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
      errors = (IEnumerable<string>) stringList;
      return errors.Any<string>();
    }

    private void HandleRevision()
    {
      if (this.HeaderData.Revision == 1)
        this.GetField(1, 0).Size = 2;
      else
        this.GetField(1, 0).Size = 4;
    }

    public enum DataFields
    {
      JOB_ID,
    }
  }
}
