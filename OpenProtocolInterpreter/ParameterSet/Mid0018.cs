﻿
// Type: OpenProtocolInterpreter.ParameterSet.Mid0018
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OpenProtocolInterpreter.ParameterSet
{
  public class Mid0018 : Mid, IParameterSet, IIntegrator
  {
    private readonly IValueConverter<int> _intConverter;
    private const int LAST_REVISION = 1;
    public const int MID = 18;

    public int ParameterSetId
    {
      get => this.GetField(1, 0).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 0).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public Mid0018()
      : base(18, 1)
    {
      this._intConverter = (IValueConverter<int>) new Int32Converter();
    }

    public Mid0018(int parameterSetId)
      : this()
    {
      this.ParameterSetId = parameterSetId;
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
        }
      };
    }

    public bool Validate(out IEnumerable<string> errors)
    {
      List<string> stringList = new List<string>();
      if (this.ParameterSetId < 0 || this.ParameterSetId > 999)
        stringList.Add(new ArgumentOutOfRangeException("ParameterSetId", "Range: 000-999").Message);
      errors = (IEnumerable<string>) stringList;
      return errors.Any<string>();
    }

    public enum DataFields
    {
      PARAMETER_SET_ID,
    }
  }
}
