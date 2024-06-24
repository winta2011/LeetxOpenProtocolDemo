
// Type: OpenProtocolInterpreter.Time.Mid0082
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Time
{
  public class Mid0082 : Mid, ITime, IIntegrator
  {
    private readonly IValueConverter<DateTime> _dateConverter;
    private const int LAST_REVISION = 1;
    public const int MID = 82;

    public DateTime Time
    {
      get
      {
        return this.GetField(1, 0).GetValue<DateTime>(new Func<string, DateTime>(this._dateConverter.Convert));
      }
      set
      {
        this.GetField(1, 0).SetValue<DateTime>(new Func<char, int, DataField.PaddingOrientations, DateTime, string>(this._dateConverter.Convert), value);
      }
    }

    public Mid0082()
      : base(82, 1)
    {
      this._dateConverter = (IValueConverter<DateTime>) new DateConverter();
    }

    public Mid0082(DateTime time)
      : this()
    {
      this.Time = time;
    }

    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
      return new Dictionary<int, List<DataField>>()
      {
        {
          1,
          new List<DataField>() { new DataField(0, 20, 19, false) }
        }
      };
    }

    public enum DataFields
    {
      TIME,
    }
  }
}
