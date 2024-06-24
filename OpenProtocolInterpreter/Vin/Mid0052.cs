
// Type: OpenProtocolInterpreter.Vin.Mid0052
using System;
using System.Collections.Generic;
using System.Linq;


namespace OpenProtocolInterpreter.Vin
{
  public class Mid0052 : Mid, IVin, IController
  {
    private const int LAST_REVISION = 2;
    public const int MID = 52;

    public string VinNumber
    {
      get => this.GetField(1, 0).Value;
      set => this.GetField(1, 0).SetValue(value);
    }

    public string IdentifierResultPart2
    {
      get => this.GetField(2, 1).Value;
      set => this.GetField(2, 1).SetValue(value);
    }

    public string IdentifierResultPart3
    {
      get => this.GetField(2, 2).Value;
      set => this.GetField(2, 2).SetValue(value);
    }

    public string IdentifierResultPart4
    {
      get => this.GetField(2, 3).Value;
      set => this.GetField(2, 3).SetValue(value);
    }

    public Mid0052()
      : this(2)
    {
    }

    public Mid0052(int revision = 2)
      : base(52, revision)
    {
    }

    public Mid0052(string vinNumber, int revision = 1)
      : this(revision)
    {
      this.VinNumber = vinNumber;
    }

    public Mid0052(
      string vinNumber,
      string identifierResultPart2,
      string identifierResultPart3,
      string identifierResultPart4,
      int revision = 2)
      : this(vinNumber, revision)
    {
      this.IdentifierResultPart2 = identifierResultPart2;
      this.IdentifierResultPart3 = identifierResultPart3;
      this.IdentifierResultPart4 = identifierResultPart4;
    }

    public override string Pack()
    {
      DataField field = this.GetField(1, 0);
      if (this.HeaderData.Revision > 1)
        field.HasPrefix = true;
      field.Size = this.VinNumber.Length > 25 ? this.VinNumber.Length : 25;
      return base.Pack();
    }

    public override Mid Parse(string package)
    {
      this.HeaderData = this.ProcessHeader(package);
      if (this.HeaderData.Revision > 1)
      {
        DataField field = this.GetField(1, 0);
        field.HasPrefix = true;
        field.Size = package.Length - 103;
        if (field.Size > 25)
        {
          int num = field.Size - 25;
          this.GetField(2, 1).Index += num;
          this.GetField(2, 2).Index += num;
          this.GetField(2, 3).Index += num;
        }
      }
      else
        this.GetField(1, 0).Size = package.Length - 20;
      this.ProcessDataFields(package);
      return (Mid) this;
    }

    public bool Validate(out IEnumerable<string> errors)
    {
      List<string> stringList = new List<string>();
      if (this.HeaderData.Revision == 1)
      {
        if (this.VinNumber.Length > 45)
          stringList.Add(new ArgumentOutOfRangeException("VinNumber", "Max of 45 characters").Message);
      }
      else
      {
        if (this.VinNumber.Length > 25)
          stringList.Add(new ArgumentOutOfRangeException("VinNumber", "Max of 25 characters").Message);
        if (this.IdentifierResultPart2.Length > 25)
          stringList.Add(new ArgumentOutOfRangeException("IdentifierResultPart2", "Max of 25 characters").Message);
        if (this.IdentifierResultPart3.Length > 25)
          stringList.Add(new ArgumentOutOfRangeException("IdentifierResultPart3", "Max of 25 characters").Message);
        if (this.IdentifierResultPart4.Length > 25)
          stringList.Add(new ArgumentOutOfRangeException("IdentifierResultPart4", "Max of 25 characters").Message);
      }
      errors = (IEnumerable<string>) stringList;
      return errors.Any<string>();
    }

    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
      return new Dictionary<int, List<DataField>>()
      {
        {
          1,
          new List<DataField>()
          {
            new DataField(0, 20, 25, ' ', hasPrefix: false)
          }
        },
        {
          2,
          new List<DataField>()
          {
            new DataField(1, 47, 25, ' '),
            new DataField(2, 74, 25, ' '),
            new DataField(3, 101, 25, ' ')
          }
        }
      };
    }

    public enum DataFields
    {
      VIN_NUMBER,
      IDENTIFIER_RESULT_PART2,
      IDENTIFIER_RESULT_PART3,
      IDENTIFIER_RESULT_PART4,
    }
  }
}
