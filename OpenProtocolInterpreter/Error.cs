﻿
// Type: OpenProtocolInterpreter.Error

namespace OpenProtocolInterpreter
{
  public enum Error
  {
    NO_ERROR = 0,
    INVALID_DATA = 1,
    PARAMETER_SET_ID_NOT_PRESENT = 2,
    PARAMETER_SET_CANNOT_BE_SET = 3,
    PARAMETER_SET_NOT_RUNNING = 4,
    VIN_UPLOAD_SUBSCRIPTION_ALREADY_EXISTS = 6,
    VIN_UPLOAD_SUBSCRIPTION_DOESNT_EXISTS = 7,
    VIN_INPUT_SOURCE_NOT_GRANTED = 8,
    LAST_TIGHTENING_RESULT_SUBSCRIPTION_ALREADY_EXISTS = 9,
    LAST_TIGHTENING_RESULT_SUBSCRIPTION_DOESNT_EXISTS = 10, // 0x0000000A
    ALARM_SUBSCRIPTION_ALREADY_EXISTS = 11, // 0x0000000B
    ALARM_SUBSCRIPTION_DOESNT_EXISTS = 12, // 0x0000000C
    PARAMETER_SET_SELECTION_SUBSCRIPTION_ALREADY_EXISTS = 13, // 0x0000000D
    PARAMETER_SET_SELECTION_SUBSCRIPTION_DOESNT_EXISTS = 14, // 0x0000000E
    TIGHTENING_ID_REQUESTED_NOT_FOUND = 15, // 0x0000000F
    CONNECTION_REJECTED_PROTOCOL_BUSY = 16, // 0x00000010
    JOB_ID_NOT_PRESENT = 17, // 0x00000011
    JOB_INFO_SUBSCRIPTION_ALREADY_EXISTS = 18, // 0x00000012
    JOB_INFO_SUBSCRIPTION_DOESNT_EXISTS = 19, // 0x00000013
    JOB_CANNOT_BE_SET = 20, // 0x00000014
    JOB_NOT_RUNNING = 21, // 0x00000015
    NOT_POSSIBLE_TO_EXECUTE_DYNAMIC_JOB_REQUEST = 22, // 0x00000016
    JOB_BATCH_DECREMENT_FAILED = 23, // 0x00000017
    NOT_POSSIBLE_TO_CREATE_PSET = 24, // 0x00000018
    PROGRAMMING_CONTROL_NOT_GRANTED = 25, // 0x00000019
    CONTROLLER_IS_NOT_A_SYNC_MASTER_OR_STATION_CONTROLLER = 30, // 0x0000001E
    MULTI_SPINDLE_STATUS_SUBSCRIPTION_ALREADY_EXISTS = 31, // 0x0000001F
    MULTI_SPINDLE_STATUS_SUBSCRIPTION_DOESNT_EXISTS = 32, // 0x00000020
    MULTI_SPINDLE_RESULT_SUBSCRIPTION_ALREADY_EXISTS = 33, // 0x00000021
    MULTI_SPINDLE_RESULT_SUBSCRIPTION_DOESNT_EXISTS = 34, // 0x00000022
    JOB_LINE_CONTROL_INFO_SUBSCRIPTION_ALREADY_EXISTS = 40, // 0x00000028
    JOB_LINE_CONTROL_INFO_SUBSCRIPTION_DOESNT_EXISTS = 41, // 0x00000029
    IDENTIFIER_INPUT_SOURCE_NOT_GRANTED = 42, // 0x0000002A
    MULTIPLE_IDENTIFIERS_WORK_ORDER_SUBSCRIPTION_ALREADY_EXISTS = 43, // 0x0000002B
    MULTIPLE_IDENTIFIERS_WORK_ORDER_SUBSCRIPTION_DOESNT_EXISTS = 44, // 0x0000002C
    STATUS_EXTERNAL_MONITORED_INPUTS_SUBSCRIPTION_ALREADY_EXISTS = 50, // 0x00000032
    STATUS_EXTERNAL_MONITORED_INPUTS_SUBSCRIPTION_DOESNT_EXISTS = 51, // 0x00000033
    IO_DEVICE_NOT_CONNECTED = 52, // 0x00000034
    FAULTY_IO_DEVICE_ID = 53, // 0x00000035
    TOOL_TAG_ID_UNKNOWN = 54, // 0x00000036
    TOOL_TAG_ID_SUBSCRIPTION_ALREADY_EXISTS = 55, // 0x00000037
    TOOL_TAG_ID_SUBSCRIPTION_DOESNT_EXISTS = 56, // 0x00000038
    TOOL_MOTOR_TUNING_FAILED = 57, // 0x00000039
    NO_ALARM_PRESENT = 58, // 0x0000003A
    TOOL_CURRENTLY_IN_USE = 59, // 0x0000003B
    NO_HISTOGRAM_AVAILABLE = 60, // 0x0000003C
    CALIBRATION_FAILED = 70, // 0x00000046
    SUBSCRIPTION_ALREADY_EXISTS = 71, // 0x00000047
    SUBSCRIPTION_DOESNT_EXISTS = 72, // 0x00000048
    COMMAND_FAILED = 79, // 0x0000004F
    AUTOMATIC_MANUAL_MODE_SUBSCRIBE_ALREADY_EXISTS = 82, // 0x00000052
    AUTOMATIC_MANUAL_MODE_SUBSCRIBE_DOESNT_EXISTS = 83, // 0x00000053
    RELAY_FUNCTION_SUBSCRIPTION_ALREADY_EXISTS = 84, // 0x00000054
    RELAY_FUNCTION_SUBSCRIPTION_DOESNT_EXISTS = 85, // 0x00000055
    SELECTOR_SOCKET_INFO_SUBSCRIPTION_ALREADY_EXISTS = 86, // 0x00000056
    SELECTOR_SOCKET_INFO_SUBSCRIPTION_DOESNT_EXISTS = 87, // 0x00000057
    DIGIN_INFO_SUBSCRIPTION_ALREADY_EXISTS = 88, // 0x00000058
    DIGIN_INFO_SUBSCRIPTION_DOESNT_EXISTS = 89, // 0x00000059
    LOCK_AT_BATCH_DONE_SUBSCRIPTION_ALREADY_EXISTS = 90, // 0x0000005A
    LOCK_AT_BATCH_DONE_SUBSCRIPTION_DOESNT_EXISTS = 91, // 0x0000005B
    OPEN_PROTOCOL_COMMANDS_DISABLED = 92, // 0x0000005C
    OPEN_PROTOCOL_COMMANDS_DISABLED_SUBSCRIPTION_ALREADY_EXISTS = 93, // 0x0000005D
    OPEN_PROTOCOL_COMMANDS_DISABLED_SUBSCRIPTION_DOESNT_EXISTS = 94, // 0x0000005E
    REJECT_REQUEST_POWER_MACS_IS_IN_MANUAL_MODE = 95, // 0x0000005F
    CLIENT_ALREADY_CONNECTED = 96, // 0x00000060
    MID_REVISION_UNSUPPORTED = 97, // 0x00000061
    CONTROLLER_INTERNAL_REQUEST_TIMEOUT = 98, // 0x00000062
    UNKNOWN_MID = 99, // 0x00000063
  }
}
