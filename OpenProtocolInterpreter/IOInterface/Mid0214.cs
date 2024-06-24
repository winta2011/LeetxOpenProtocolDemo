﻿
// Type: OpenProtocolInterpreter.IOInterface.Mid0214
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;


namespace OpenProtocolInterpreter.IOInterface
{
  public class Mid0214 : Mid, IIOInterface, IIntegrator
  {
    private readonly IValueConverter<int> _intConverter;
    private const int LAST_REVISION = 2;
    public const int MID = 214;

    public int DeviceNumber
    {
      get => this.GetField(1, 0).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 0).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public Mid0214()
      : this(2)
    {
    }

    public Mid0214(int revision = 2)
      : base(214, revision)
    {
      this._intConverter = (IValueConverter<int>) new Int32Converter();
    }

    public Mid0214(int deviceNumber, int revision = 2)
      : this(revision)
    {
      this.DeviceNumber = deviceNumber;
    }

    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
      return new Dictionary<int, List<DataField>>()
      {
        {
          1,
          new List<DataField>()
          {
            new DataField(0, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED, false)
          }
        },
        {
          2,
          new List<DataField>()
        }
      };
    }

    public enum DataFields
    {
      DEVICE_NUMBER,
    }
  }
}
