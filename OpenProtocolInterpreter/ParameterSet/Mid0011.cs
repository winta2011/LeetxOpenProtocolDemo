
// Type: OpenProtocolInterpreter.ParameterSet.Mid0011
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OpenProtocolInterpreter.ParameterSet
{
  public class Mid0011 : Mid, IParameterSet, IController
  {
    private readonly IValueConverter<int> _intConverter;
    private readonly IValueConverter<IEnumerable<int>> _intListConverter;
    private const int LAST_REVISION = 1;
    public const int MID = 11;

    public int TotalParameterSets
    {
      get => this.GetField(1, 0).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      private set
      {
        this.GetField(1, 0).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public List<int> ParameterSets { get; set; }

    public Mid0011()
      : base(11, 1)
    {
      this._intConverter = (IValueConverter<int>) new Int32Converter();
      this._intListConverter = (IValueConverter<IEnumerable<int>>) new ParameterSetIdListConverter(this._intConverter);
      if (this.ParameterSets != null)
        return;
      this.ParameterSets = new List<int>();
    }

    public Mid0011(IEnumerable<int> parameterSets)
      : this()
    {
      this.ParameterSets = parameterSets.ToList<int>();
    }

    public override string Pack()
    {
      this.TotalParameterSets = this.ParameterSets.Count;
      DataField field = this.GetField(1, 1);
      field.Value = this._intListConverter.Convert((IEnumerable<int>) this.ParameterSets);
      field.Size = field.Value.Length;
      return base.Pack();
    }

    public override Mid Parse(string package)
    {
      this.HeaderData = this.ProcessHeader(package);
      this.GetField(1, 1).Size = package.Length - this.GetField(1, 1).Index;
      this.ProcessDataFields(package);
      this.ParameterSets = this._intListConverter.Convert(this.GetField(1, 1).Value).ToList<int>();
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
            new DataField(0, 20, 3, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
            new DataField(1, 23, 3, false)
          }
        }
      };
    }

    public enum DataFields
    {
      TOTAL_PARAMETER_SETS,
      EACH_PARAMETER_SET,
    }
  }
}
