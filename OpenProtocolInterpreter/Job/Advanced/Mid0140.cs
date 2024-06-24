
// Type: OpenProtocolInterpreter.Job.Advanced.Mid0140
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OpenProtocolInterpreter.Job.Advanced
{
  public class Mid0140 : Mid, IAdvancedJob, IIntegrator
  {
    private readonly IValueConverter<int> _intConverter;
    private readonly IValueConverter<bool> _boolConverter;
    private IValueConverter<IEnumerable<AdvancedJob>> _jobListConverter;
    private const int LAST_REVISION = 1;
    public const int MID = 140;

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

    public int NumberOfParameterSets
    {
      get => this.GetField(1, 2).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 2).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public List<AdvancedJob> JobList { get; set; }

    public ForcedOrder ForcedOrder
    {
      get
      {
        return (ForcedOrder) this.GetField(1, 4).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 4).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public bool LockAtJobDone
    {
      get
      {
        return this.GetField(1, 5).GetValue<bool>(new Func<string, bool>(this._boolConverter.Convert));
      }
      set
      {
        this.GetField(1, 5).SetValue<bool>(new Func<char, int, DataField.PaddingOrientations, bool, string>(this._boolConverter.Convert), value);
      }
    }

    public ToolLoosening ToolLoosening
    {
      get
      {
        return (ToolLoosening) this.GetField(1, 6).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 6).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public bool RepeatJob
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

    public BatchMode BatchMode
    {
      get
      {
        return (BatchMode) this.GetField(1, 8).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 8).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public bool BatchStatusAtIncrement
    {
      get
      {
        return this.GetField(1, 9).GetValue<bool>(new Func<string, bool>(this._boolConverter.Convert));
      }
      set
      {
        this.GetField(1, 9).SetValue<bool>(new Func<char, int, DataField.PaddingOrientations, bool, string>(this._boolConverter.Convert), value);
      }
    }

    public bool DecrementBatchAtOkLoosening
    {
      get
      {
        return this.GetField(1, 10).GetValue<bool>(new Func<string, bool>(this._boolConverter.Convert));
      }
      set
      {
        this.GetField(1, 10).SetValue<bool>(new Func<char, int, DataField.PaddingOrientations, bool, string>(this._boolConverter.Convert), value);
      }
    }

    public int MaxTimeForFirstTightening
    {
      get => this.GetField(1, 11).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 11).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int MaxTimeToCompleteJob
    {
      get => this.GetField(1, 12).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 12).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int DisplayResultAtAutoSelect
    {
      get => this.GetField(1, 13).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 13).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public bool UsingLineControl
    {
      get
      {
        return this.GetField(1, 14).GetValue<bool>(new Func<string, bool>(this._boolConverter.Convert));
      }
      set
      {
        this.GetField(1, 14).SetValue<bool>(new Func<char, int, DataField.PaddingOrientations, bool, string>(this._boolConverter.Convert), value);
      }
    }

    public IdentifierPart IdentifierResultPart
    {
      get
      {
        return (IdentifierPart) this.GetField(1, 15).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 15).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public bool ResultOfNonTightenings
    {
      get
      {
        return this.GetField(1, 16).GetValue<bool>(new Func<string, bool>(this._boolConverter.Convert));
      }
      set
      {
        this.GetField(1, 16).SetValue<bool>(new Func<char, int, DataField.PaddingOrientations, bool, string>(this._boolConverter.Convert), value);
      }
    }

    public bool ResetAllIdentifiersAtJobDone
    {
      get
      {
        return this.GetField(1, 17).GetValue<bool>(new Func<string, bool>(this._boolConverter.Convert));
      }
      set
      {
        this.GetField(1, 17).SetValue<bool>(new Func<char, int, DataField.PaddingOrientations, bool, string>(this._boolConverter.Convert), value);
      }
    }

    public Reserved Reserved
    {
      get
      {
        return (Reserved) this.GetField(1, 18).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 18).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public Mid0140()
      : this(1)
    {
    }

    public Mid0140(int revision = 1)
      : base(140, revision)
    {
      this.JobList = new List<AdvancedJob>();
      this._intConverter = (IValueConverter<int>) new Int32Converter();
      this._boolConverter = (IValueConverter<bool>) new BoolConverter();
      this._jobListConverter = (IValueConverter<IEnumerable<AdvancedJob>>) new AdvancedJobListConverter(this._intConverter, this._boolConverter, revision);
    }

    public override string Pack()
    {
      this.GetField(1, 3).Size = this.JobList.Count * (this.HeaderData.Revision == 999 ? 18 : 15);
      this.AdjustDataFieldsIndexes();
      this.GetField(1, 3).Value = this._jobListConverter.Convert((IEnumerable<AdvancedJob>) this.JobList);
      return base.Pack();
    }

    public override Mid Parse(string package)
    {
      this.HeaderData = this.ProcessHeader(package);
      this._jobListConverter = (IValueConverter<IEnumerable<AdvancedJob>>) new AdvancedJobListConverter(this._intConverter, this._boolConverter, this.HeaderData.Revision);
      int length = this.HeaderData.Length;
      foreach (DataField dataField in this.RevisionsByFields[1])
        length -= dataField.Size;
      this.GetField(1, 3).Size = length;
      this.AdjustDataFieldsIndexes();
      this.ProcessDataFields(package);
      this.JobList = this._jobListConverter.Convert(this.GetField(1, 3).Value).ToList<AdvancedJob>();
      return (Mid) this;
    }

    private void AdjustDataFieldsIndexes()
    {
      int num = this.GetField(1, 3).Index + this.GetField(1, 3).Size + 2;
      for (int field = 4; field < this.RevisionsByFields[1].Count; ++field)
      {
        this.GetField(1, field).Index = num;
        num += 2 + this.GetField(1, field).Size;
      }
      this.GetField(1, 3).Size = this.NumberOfParameterSets * 15;
    }

    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
      return new Dictionary<int, List<DataField>>()
      {
        {
          1,
          new List<DataField>()
          {
            new DataField(0, 20, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(1, 26, 25, ' '),
            new DataField(2, 53, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(3, 57, 0),
            new DataField(4, 0, 1),
            new DataField(5, 0, 1),
            new DataField(6, 0, 1),
            new DataField(7, 0, 1),
            new DataField(8, 0, 1),
            new DataField(9, 0, 1),
            new DataField(10, 0, 1),
            new DataField(11, 0, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(12, 0, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(13, 0, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(14, 0, 1),
            new DataField(15, 0, 1),
            new DataField(16, 0, 1),
            new DataField(17, 0, 1),
            new DataField(18, 0, 1)
          }
        }
      };
    }

    public enum DataFields
    {
      JOB_ID,
      JOB_NAME,
      NUMBER_OF_PARAMETER_SETS,
      JOB_LIST,
      FORCED_ORDER,
      LOCK_AT_JOB_DONE,
      TOOL_LOOSENING,
      REPEAT_JOB,
      JOB_BATCH_MODE,
      BATCH_STATUS_AT_INCREMENT,
      DECREMENT_BATCH_AT_OK_LOOSENING,
      MAX_TIME_FOR_FIRST_TIGHTENING,
      MAX_TIME_TO_COMPLETE_JOB,
      DISPLAY_RESULT_AT_AUTO_SELECT,
      USE_LINE_CONTROL,
      IDENTIFIER_RESULT_PART,
      RESULT_OF_NON_TIGHTENINGS,
      RESET_ALL_IDENTIFIERS_AT_JOB_DONE,
      RESERVED,
    }
  }
}
