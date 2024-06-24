
// Type: OpenProtocolInterpreter.Job.Advanced.Mid0129
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.Job.Advanced
{
  public class Mid0129 : Mid, IAdvancedJob, IIntegrator
  {
    private readonly IValueConverter<int> _intConverter;
    private const int LAST_REVISION = 2;
    public const int MID = 129;

    public int ChannelId
    {
      get => this.GetField(2, 0).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(2, 0).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int ParameterSetId
    {
      get => this.GetField(2, 1).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(2, 1).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public Mid0129()
      : this(2)
    {
    }

    public Mid0129(int revision = 2)
      : base(129, revision)
    {
      this._intConverter = (IValueConverter<int>) new Int32Converter();
    }

    public Mid0129(int channelId, int parameterSetId, int revision = 2)
      : this(revision)
    {
      this.ChannelId = channelId;
      this.ParameterSetId = parameterSetId;
    }

    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
      return new Dictionary<int, List<DataField>>()
      {
        {
          1,
          new List<DataField>()
        },
        {
          2,
          new List<DataField>()
          {
            new DataField(0, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(1, 24, 3, '0', DataField.PaddingOrientations.LEFT_PADDED)
          }
        }
      };
    }

    public enum DataFields
    {
      CHANNEL_ID,
      PARAMETER_SET_ID,
    }
  }
}
