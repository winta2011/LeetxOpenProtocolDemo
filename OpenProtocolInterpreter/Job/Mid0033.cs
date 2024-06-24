
// Type: OpenProtocolInterpreter.Job.Mid0033
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OpenProtocolInterpreter.Job
{
  public class Mid0033 : Mid, IJob, IController
  {
    private readonly IValueConverter<int> _intConverter;
    private readonly IValueConverter<bool> _boolConverter;
    private IValueConverter<IEnumerable<ParameterSet>> _parameterSetListConverter;
    private const int LAST_REVISION = 3;
    public const int MID = 33;

    public int JobId
    {
      get => this.GetField(1, 0).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 0).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public string JobName
    {
      get => this.GetField(1, 1).Value;
      set => this.GetField(1, 1).SetValue(value);
    }

    public ForcedOrder ForcedOrder
    {
      get
      {
        return (ForcedOrder) this.GetField(1, 2).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 2).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public int MaxTimeForFirstTightening
    {
      get => this.GetField(1, 3).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 3).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int MaxTimeToCompleteJob
    {
      get => this.GetField(1, 4).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 4).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public JobBatchMode JobBatchMode
    {
      get
      {
        return (JobBatchMode) this.GetField(1, 5).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 5).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public bool LockAtJobDone
    {
      get
      {
        return this.GetField(1, 6).GetValue<bool>(new Func<string, bool>(this._boolConverter.Convert));
      }
      set
      {
        this.GetField(1, 6).SetValue<bool>(new Func<char, int, DataField.PaddingOrientations, bool, string>(this._boolConverter.Convert), value);
      }
    }

    public bool UseLineControl
    {
      get
      {
        return this.GetField(1, 7).GetValue<bool>(new Func<string, bool>(this._boolConverter.Convert));
      }
      set
      {
        this.GetField(1, 7).SetValue<bool>(new Func<char, int, DataField.PaddingOrientations, bool, string>(this._boolConverter.Convert), value);
      }
    }

    public bool RepeatJob
    {
      get
      {
        return this.GetField(1, 8).GetValue<bool>(new Func<string, bool>(this._boolConverter.Convert));
      }
      set
      {
        this.GetField(1, 8).SetValue<bool>(new Func<char, int, DataField.PaddingOrientations, bool, string>(this._boolConverter.Convert), value);
      }
    }

    public ToolLoosening ToolLoosening
    {
      get
      {
        return (ToolLoosening) this.GetField(1, 9).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 9).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public Reserved Reserved
    {
      get
      {
        return (Reserved) this.GetField(1, 10).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 10).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public int NumberOfParameterSets
    {
      get => this.GetField(1, 11).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 11).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public List<ParameterSet> ParameterSetList { get; set; }

    public Mid0033()
      : this(3)
    {
    }

    public Mid0033(int revision = 3)
      : base(33, revision)
    {
      this._intConverter = (IValueConverter<int>) new Int32Converter();
      this._boolConverter = (IValueConverter<bool>) new BoolConverter();
      if (this.ParameterSetList == null)
        this.ParameterSetList = new List<ParameterSet>();
      this.HandleRevisions();
    }

    public Mid0033(
      int jobId,
      string jobName,
      ForcedOrder forcedOrder,
      int maxTimeForFirstTightening,
      int maxTimeToCompleteJob,
      JobBatchMode jobBatchMode,
      bool lockAtJobDone,
      bool useLineControl,
      bool repeatJob,
      ToolLoosening toolLoosening,
      Reserved reserved,
      int numberOfParameterSets,
      IEnumerable<ParameterSet> parameterSetList,
      int revision = 3)
      : this(revision)
    {
      this.JobId = jobId;
      this.JobName = jobName;
      this.ForcedOrder = forcedOrder;
      this.MaxTimeForFirstTightening = maxTimeForFirstTightening;
      this.MaxTimeToCompleteJob = maxTimeToCompleteJob;
      this.JobBatchMode = jobBatchMode;
      this.LockAtJobDone = lockAtJobDone;
      this.UseLineControl = useLineControl;
      this.RepeatJob = repeatJob;
      this.ToolLoosening = toolLoosening;
      this.Reserved = reserved;
      this.NumberOfParameterSets = numberOfParameterSets;
      this.ParameterSetList = parameterSetList.ToList<ParameterSet>();
    }

    public override string Pack()
    {
      this.HandleRevisions();
      this._parameterSetListConverter = (IValueConverter<IEnumerable<ParameterSet>>) new ParameterSetListConverter(this._intConverter, this._boolConverter, this.HeaderData.Revision);
      DataField field = this.GetField(1, 12);
      field.Size = this.ParameterSetList.Count * (this.HeaderData.Revision < 3 ? 12 : 44);
      field.Value = this._parameterSetListConverter.Convert((IEnumerable<ParameterSet>) this.ParameterSetList);
      return base.Pack();
    }

    public override Mid Parse(string package)
    {
      this.HeaderData = this.ProcessHeader(package);
      this.HandleRevisions();
      this._parameterSetListConverter = (IValueConverter<IEnumerable<ParameterSet>>) new ParameterSetListConverter(this._intConverter, this._boolConverter, this.HeaderData.Revision);
      DataField field = this.GetField(1, 12);
      field.Size = package.Length - field.Index - 2;
      base.Parse(package);
      this.ParameterSetList = this._parameterSetListConverter.Convert(field.Value).ToList<ParameterSet>();
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
            new DataField(0, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(1, 24, 25, ' '),
            new DataField(2, 51, 1),
            new DataField(3, 54, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(4, 60, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(5, 67, 1),
            new DataField(6, 70, 1),
            new DataField(7, 73, 1),
            new DataField(8, 76, 1),
            new DataField(9, 79, 1),
            new DataField(10, 82, 1),
            new DataField(11, 85, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(12, 89, 0)
          }
        }
      };
    }

    private void HandleRevisions()
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

    public enum DataFields
    {
      JOB_ID,
      JOB_NAME,
      FORCED_ORDER,
      MAX_TIME_FOR_FIRST_TIGHTENING,
      MAX_TIME_TO_COMPLETE_JOB,
      JOB_BATCH_MODE,
      LOCK_AT_JOB_DONE,
      USE_LINE_CONTROL,
      REPEAT_JOB,
      TOOL_LOOSENING,
      RESERVED,
      NUMBER_OF_PARAMETER_SETS,
      PARAMETER_SET_LIST,
    }
  }
}
