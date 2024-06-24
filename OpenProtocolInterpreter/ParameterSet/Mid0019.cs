
// Type: OpenProtocolInterpreter.ParameterSet.Mid0019
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OpenProtocolInterpreter.ParameterSet
{
  public class Mid0019 : Mid, IParameterSet, IIntegrator
  {
    private readonly IValueConverter<int> _intConverter;
    private const int LAST_REVISION = 1;
    public const int MID = 19;

    public int ParameterSetId
    {
      get => this.GetField(1, 0).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 0).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int BatchSize
    {
      get => this.GetField(1, 1).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 1).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public Mid0019()
      : base(19, 1)
    {
      this._intConverter = (IValueConverter<int>) new Int32Converter();
    }

    public Mid0019(int parameterSetId, int batchSize)
      : this()
    {
      this.ParameterSetId = parameterSetId;
      this.BatchSize = batchSize;
    }

    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
      return new Dictionary<int, List<DataField>>()
      {
        {
          1,
          new List<DataField>()
          {
            new DataField(0, 20, 3, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
            new DataField(1, 23, 2, '0', DataField.PaddingOrientations.LEFT_PADDED, false)
          }
        }
      };
    }

    public bool Validate(out IEnumerable<string> errors)
    {
      List<string> stringList = new List<string>();
      if (this.ParameterSetId < 0 || this.ParameterSetId > 999)
        stringList.Add(new ArgumentOutOfRangeException("ParameterSetId", "Range: 000-999").Message);
      if (this.BatchSize < 0 || this.BatchSize > 99)
        stringList.Add(new ArgumentOutOfRangeException("BatchSize", "Range: 00-99").Message);
      errors = (IEnumerable<string>) stringList;
      return errors.Any<string>();
    }

    public enum DataFields
    {
      PARAMETER_SET_ID,
      BATCH_SIZE,
    }
  }
}
