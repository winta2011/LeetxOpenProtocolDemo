
// Type: OpenProtocolInterpreter.Job.Advanced.Mid0130
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Job.Advanced
{
  public class Mid0130 : Mid, IAdvancedJob, IIntegrator
  {
    private readonly IValueConverter<bool> _boolConverter;
    private const int LAST_REVISION = 1;
    public const int MID = 130;

    public bool JobOffStatus
    {
      get
      {
        return this.GetField(1, 0).GetValue<bool>(new Func<string, bool>(this._boolConverter.Convert));
      }
      set
      {
        this.GetField(1, 0).SetValue<bool>(new Func<char, int, DataField.PaddingOrientations, bool, string>(this._boolConverter.Convert), value);
      }
    }

    public Mid0130()
      : base(130, 1)
    {
      this._boolConverter = (IValueConverter<bool>) new BoolConverter();
    }

    public Mid0130(bool jobOffStatus)
      : this()
    {
      this.JobOffStatus = jobOffStatus;
    }

    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
      return new Dictionary<int, List<DataField>>()
      {
        {
          1,
          new List<DataField>() { new DataField(0, 20, 1, false) }
        }
      };
    }

    public enum DataFields
    {
      JOB_OFF_STATUS,
    }
  }
}
