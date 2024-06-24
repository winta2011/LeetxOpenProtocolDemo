
// Type: OpenProtocolInterpreter.UserInterface.Mid0111
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.UserInterface
{
  public class Mid0111 : Mid, IUserInterface, IIntegrator
  {
    private readonly IValueConverter<int> _intConverter;
    private const int LAST_REVISION = 1;
    public const int MID = 111;

    public int TextDuration
    {
      get => this.GetField(1, 0).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 0).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public RemovalCondition RemovalCondition
    {
      get
      {
        return (RemovalCondition) this.GetField(1, 1).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(1, 1).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public string Line1
    {
      get => this.GetField(1, 2).Value;
      set => this.GetField(1, 2).SetValue(value);
    }

    public string Line2
    {
      get => this.GetField(1, 3).Value;
      set => this.GetField(1, 3).SetValue(value);
    }

    public string Line3
    {
      get => this.GetField(1, 4).Value;
      set => this.GetField(1, 4).SetValue(value);
    }

    public string Line4
    {
      get => this.GetField(1, 5).Value;
      set => this.GetField(1, 5).SetValue(value);
    }

    public Mid0111()
      : base(111, 1)
    {
      this._intConverter = (IValueConverter<int>) new Int32Converter();
    }

    public Mid0111(
      int textDuration,
      RemovalCondition removalCondition,
      string line1,
      string line2,
      string line3,
      string line4)
      : this()
    {
      this.TextDuration = textDuration;
      this.RemovalCondition = removalCondition;
      this.Line1 = line1;
      this.Line2 = line2;
      this.Line3 = line3;
      this.Line4 = line4;
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
            new DataField(1, 26, 1),
            new DataField(2, 29, 25, ' '),
            new DataField(3, 56, 25, ' '),
            new DataField(4, 83, 25, ' '),
            new DataField(5, 110, 25, ' ')
          }
        }
      };
    }

    public enum DataFields
    {
      TEXT_DURATION,
      REMOVAL_CONDITION,
      LINE_1_HEADER,
      LINE_2,
      LINE_3,
      LINE_4,
    }
  }
}
