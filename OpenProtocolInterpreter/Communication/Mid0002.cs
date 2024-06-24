
// Type: OpenProtocolInterpreter.Communication.Mid0002
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OpenProtocolInterpreter.Communication
{
  public class Mid0002 : Mid, ICommunication, IController
  {
    private readonly IValueConverter<int> _intConverter;
    private readonly IValueConverter<bool> _boolConverter;
    private const int LAST_REVISION = 6;
    public const int MID = 2;

    public int CellId
    {
      get => this.GetField(1, 0).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 0).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public int ChannelId
    {
      get => this.GetField(1, 1).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      set
      {
        this.GetField(1, 1).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), value);
      }
    }

    public string ControllerName
    {
      get => this.GetField(1, 2).Value;
      set => this.GetField(1, 2).SetValue(value);
    }

    public string SupplierCode
    {
      get => this.GetField(2, 3).Value;
      set => this.GetField(2, 3).SetValue(value);
    }

    public string OpenProtocolVersion
    {
      get => this.GetField(3, 4).Value;
      set => this.GetField(3, 4).SetValue(value);
    }

    public string ControllerSoftwareVersion
    {
      get => this.GetField(3, 5).Value;
      set => this.GetField(3, 5).SetValue(value);
    }

    public string ToolSoftwareVersion
    {
      get => this.GetField(3, 6).Value;
      set => this.GetField(3, 6).SetValue(value);
    }

    public string RBUType
    {
      get => this.GetField(4, 7).Value;
      set => this.GetField(4, 7).SetValue(value);
    }

    public string ControllerSerialNumber
    {
      get => this.GetField(4, 8).Value;
      set => this.GetField(4, 8).SetValue(value);
    }

    public SystemType SystemType
    {
      get
      {
        return (SystemType) this.GetField(5, 9).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(5, 9).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public SystemSubType SystemSubType
    {
      get
      {
        return (SystemSubType) this.GetField(5, 10).GetValue<int>(new Func<string, int>(this._intConverter.Convert));
      }
      set
      {
        this.GetField(5, 10).SetValue<int>(new Func<char, int, DataField.PaddingOrientations, int, string>(this._intConverter.Convert), (int) value);
      }
    }

    public bool SequenceNumberSupport
    {
      get
      {
        return this.GetField(6, 11).GetValue<bool>(new Func<string, bool>(this._boolConverter.Convert));
      }
      set
      {
        this.GetField(6, 11).SetValue<bool>(new Func<char, int, DataField.PaddingOrientations, bool, string>(this._boolConverter.Convert), value);
      }
    }

    public bool LinkingHandlingSupport
    {
      get
      {
        return this.GetField(6, 12).GetValue<bool>(new Func<string, bool>(this._boolConverter.Convert));
      }
      set
      {
        this.GetField(6, 12).SetValue<bool>(new Func<char, int, DataField.PaddingOrientations, bool, string>(this._boolConverter.Convert), value);
      }
    }

    public Mid0002()
      : this(6)
    {
    }

    public Mid0002(int revision = 6)
      : base(2, revision)
    {
      this._intConverter = (IValueConverter<int>) new Int32Converter();
      this._boolConverter = (IValueConverter<bool>) new BoolConverter();
    }

    public Mid0002(int cellId, int channelId, string controllerName, int revision = 1)
      : this(revision)
    {
      this.CellId = cellId;
      this.ChannelId = channelId;
      this.ControllerName = controllerName;
    }

    public Mid0002(
      int cellId,
      int channelId,
      string controllerName,
      string supplierCode,
      int revision = 2)
      : this(cellId, channelId, controllerName, revision)
    {
      this.SupplierCode = supplierCode;
    }

    public Mid0002(
      int cellId,
      int channelId,
      string controllerName,
      string supplierCode,
      string openProtocolVersion,
      string controllerSoftwareVersion,
      string toolSoftwareVersion,
      int revision = 3)
      : this(cellId, channelId, controllerName, supplierCode, revision)
    {
      this.OpenProtocolVersion = openProtocolVersion;
      this.ControllerSoftwareVersion = controllerSoftwareVersion;
      this.ToolSoftwareVersion = toolSoftwareVersion;
    }

    public Mid0002(
      int cellId,
      int channelId,
      string controllerName,
      string supplierCode,
      string openProtocolVersion,
      string controllerSoftwareVersion,
      string toolSoftwareVersion,
      string rbuType,
      string controllerSerialNumber,
      int revision = 4)
      : this(cellId, channelId, controllerName, supplierCode, openProtocolVersion, controllerSoftwareVersion, toolSoftwareVersion, revision)
    {
      this.RBUType = rbuType;
      this.ControllerSerialNumber = controllerSerialNumber;
    }

    public Mid0002(
      int cellId,
      int channelId,
      string controllerName,
      string supplierCode,
      string openProtocolVersion,
      string controllerSoftwareVersion,
      string toolSoftwareVersion,
      string rbuType,
      string controllerSerialNumber,
      SystemType systemType,
      SystemSubType systemSubType,
      int revision = 5)
      : this(cellId, channelId, controllerName, supplierCode, openProtocolVersion, controllerSoftwareVersion, toolSoftwareVersion, rbuType, controllerSerialNumber, revision)
    {
      this.SystemType = systemType;
      this.SystemSubType = systemSubType;
    }

    public Mid0002(
      int cellId,
      int channelId,
      string controllerName,
      string supplierCode,
      string openProtocolVersion,
      string controllerSoftwareVersion,
      string toolSoftwareVersion,
      string rbuType,
      string controllerSerialNumber,
      SystemType systemType,
      SystemSubType systemSubType,
      bool sequenceNumberSupport,
      bool linkingHandlingSupport,
      int revision = 6)
      : this(cellId, channelId, controllerName, supplierCode, openProtocolVersion, controllerSoftwareVersion, toolSoftwareVersion, rbuType, controllerSerialNumber, systemType, systemSubType, revision)
    {
      this.SequenceNumberSupport = sequenceNumberSupport;
      this.LinkingHandlingSupport = linkingHandlingSupport;
    }

    public bool Validate(out IEnumerable<string> errors)
    {
      List<string> stringList = new List<string>();
      if (this.CellId < 0 || this.CellId > 9999)
        stringList.Add(new ArgumentOutOfRangeException("CellId", "Range: 0000-9999").Message);
      if (this.ChannelId < 0 || this.ChannelId > 20)
        stringList.Add(new ArgumentOutOfRangeException("ChannelId", "Range: 00-20").Message);
      if (this.ControllerName.Length > 25)
        stringList.Add(new ArgumentOutOfRangeException("ControllerName", "Max of 20 characters").Message);
      if (this.HeaderData.Revision > 1)
      {
        if (this.SupplierCode.Length > 3)
          stringList.Add(new ArgumentOutOfRangeException("SupplierCode", "Max of 3 characters").Message);
        if (this.HeaderData.Revision > 2)
        {
          if (this.OpenProtocolVersion.Length > 19)
            stringList.Add(new ArgumentOutOfRangeException("OpenProtocolVersion", "Max of 19 characters").Message);
          if (this.ControllerSoftwareVersion.Length > 19)
            stringList.Add(new ArgumentOutOfRangeException("ControllerSoftwareVersion", "Max of 19 characters").Message);
          if (this.ToolSoftwareVersion.Length > 19)
            stringList.Add(new ArgumentOutOfRangeException("ToolSoftwareVersion", "Max of 19 characters").Message);
          if (this.HeaderData.Revision == 4)
          {
            if (this.RBUType.Length > 24)
              stringList.Add(new ArgumentOutOfRangeException("RBUType", "Max of 24 characters").Message);
            if (this.ControllerSerialNumber.Length > 10)
              stringList.Add(new ArgumentOutOfRangeException("ControllerSerialNumber", "Max of 10 characters").Message);
          }
        }
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
            new DataField(0, 20, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(1, 26, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
            new DataField(2, 30, 25, ' ')
          }
        },
        {
          2,
          new List<DataField>() { new DataField(3, 57, 3, ' ') }
        },
        {
          3,
          new List<DataField>()
          {
            new DataField(4, 62, 19, ' '),
            new DataField(5, 83, 19, ' '),
            new DataField(6, 104, 19, ' ')
          }
        },
        {
          4,
          new List<DataField>()
          {
            new DataField(7, 125, 24, ' '),
            new DataField(8, 151, 10, ' ')
          }
        },
        {
          5,
          new List<DataField>()
          {
            new DataField(9, 163, 3, '0'),
            new DataField(10, 168, 3, '0')
          }
        },
        {
          6,
          new List<DataField>()
          {
            new DataField(11, 173, 1),
            new DataField(12, 176, 1)
          }
        }
      };
    }

    public enum DataFields
    {
      CELL_ID,
      CHANNEL_ID,
      CONTROLLER_NAME,
      SUPPLIER_CODE,
      OPEN_PROTOCOL_VERSION,
      CONTROLLER_SOFTWARE_VERSION,
      TOOL_SOFTWARE_VERSION,
      RBU_TYPE,
      CONTROLLER_SERIAL_NUMBER,
      SYSTEM_TYPE,
      SYSTEM_SUBTYPE,
      SEQUENCE_NUMBER_SUPPORT,
      LINKING_HANDLING_SUPPORT,
    }
  }
}
