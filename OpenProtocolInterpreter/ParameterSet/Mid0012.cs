
// Type: OpenProtocolInterpreter.ParameterSet.Mid0012
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.ParameterSet
{
  public class Mid0012 : Mid, IParameterSet, IIntegrator
  {
    private readonly IValueConverter<int> _intConverter;
    private const int LAST_REVISION = 4;
    public const int MID = 12;

    public int ParameterSetId
    {
      get => this.GetField(1, 0).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 0).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int ParameterSetFileVersion
    {
      get => this.GetField(3, 1).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(3, 1).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public Mid0012()
      : this(4)
    {
    }

    public Mid0012(int revision = 4)
      : base(12, revision)
    {
      this._intConverter = (IValueConverter<int>) new Int32Converter();
    }

    public Mid0012(int parameterSetId, int revision)
      : this(revision)
    {
      this.ParameterSetId = parameterSetId;
    }

    public Mid0012(int parameterSetId, int parameterSetFileVersion, int revision)
      : this(parameterSetId, revision)
    {
      this.ParameterSetFileVersion = parameterSetFileVersion;
    }

    public bool Validate(out IEnumerable<string> errors)
    {
      List<string> stringList = new List<string>();
      if (this.ParameterSetId < 1 || this.ParameterSetId > 999)
        stringList.Add(new ArgumentOutOfRangeException("ParameterSetId", "Range: 000-999").Message);
      if (this.HeaderData.Revision > 2 && (this.ParameterSetFileVersion < 0 || this.ParameterSetFileVersion > 99999999))
        stringList.Add(new ArgumentOutOfRangeException("ParameterSetFileVersion", "Range: 00000000-99999999").Message);
      errors = (IEnumerable<string>) stringList;
      return stringList.Count > 0;
    }

    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
      return new Dictionary<int, List<DataField>>()
      {
        {
          1,
          new List<DataField>()
          {
            new DataField(0, 20, 3, '0', DataField.PaddingOrientations.LEFT_PADDED, false)
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
            new DataField(1, 23, 8, '0', DataField.PaddingOrientations.LEFT_PADDED, false)
          }
        },
        {
          4,
          new List<DataField>()
        }
      };
    }

    public enum DataFields
    {
      PARAMETER_SET_ID,
      PSET_FILE_VERSION,
    }
  }
}
