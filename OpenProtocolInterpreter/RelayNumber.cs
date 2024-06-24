﻿
// Type: OpenProtocolInterpreter.RelayNumber

namespace OpenProtocolInterpreter
{
  public enum RelayNumber
  {
    OFF = 0,
    OK = 1,
    NOK = 2,
    LOW = 3,
    HIGH = 4,
    LOW_TORQUE = 5,
    HIGH_TORQUE = 6,
    LOW_ANGLE = 7,
    HIGH_ANGLE = 8,
    CYCLE_COMPLETE = 9,
    ALARM = 10, // 0x0000000A
    BATCH_NXOK = 11, // 0x0000000B
    JOB_OK = 12, // 0x0000000C
    JOB_NOK = 13, // 0x0000000D
    JOB_RUNNING = 14, // 0x0000000E
    POWER_FOCUS_READY = 18, // 0x00000012
    TOOL_READY = 19, // 0x00000013
    TOOL_START_SWITCH = 20, // 0x00000014
    DIR_SWITCH_CLOCKWISE = 21, // 0x00000015
    DIR_SWITCH_COUNTER_CLOCKWISE = 22, // 0x00000016
    TIGHTENING_DIRECTION_COUNTER_CLOCKWISE = 23, // 0x00000017
    TOOL_TIGHTENING = 24, // 0x00000018
    TOOL_LOOSENING = 25, // 0x00000019
    TOOL_RUNNING = 26, // 0x0000001A
    TOOL_RUNNING_CLOCKWISE = 27, // 0x0000001B
    TOOL_RUNNING_COUNTER_CLOCKWISE = 28, // 0x0000001C
    STATISTIC_ALARM = 29, // 0x0000001D
    TOOL_LOCKED = 30, // 0x0000001E
    RECEIVED_IDENTIFIER = 31, // 0x0000001F
    RUNNING_PSET_BIT_0 = 32, // 0x00000020
    RUNNING_PSET_BIT_1 = 33, // 0x00000021
    RUNNING_PSET_BIT_2 = 34, // 0x00000022
    RUNNING_PSET_BIT_3 = 35, // 0x00000023
    RUNNING_JOB_BIT_0 = 36, // 0x00000024
    RUNNING_JOB_BIT_1 = 37, // 0x00000025
    RUNNING_JOB_BIT_2 = 38, // 0x00000026
    RUNNING_JOB_BIT_3 = 39, // 0x00000027
    LINE_OK = 44, // 0x0000002C
    LINE_CONTROL_ALERT_1 = 45, // 0x0000002D
    LINE_CONTROL_ALERT_2 = 46, // 0x0000002E
    SERVICE_INDICATOR = 47, // 0x0000002F
    FIELDBUS_RELAY_1 = 48, // 0x00000030
    FIELDBUS_RELAY_2 = 49, // 0x00000031
    FIELDBUS_RELAY_3 = 50, // 0x00000032
    FIELDBUS_RELAY_4 = 51, // 0x00000033
    TOOL_RED_LIGHT = 52, // 0x00000034
    TOOL_GREEN_LIGHT = 53, // 0x00000035
    TOOL_YELLOW_LIGHT = 54, // 0x00000036
    RUNNING_PSET_BIT_4 = 59, // 0x0000003B
    RUNNING_PSET_BIT_5 = 60, // 0x0000003C
    RUNNING_PSET_BIT_6 = 61, // 0x0000003D
    RUNNING_PSET_BIT_7 = 62, // 0x0000003E
    RUNNING_JOB_BIT_4 = 63, // 0x0000003F
    RUNNING_JOB_BIT_5 = 64, // 0x00000040
    RUNNING_JOB_BIT_6 = 65, // 0x00000041
    RUNNING_JOB_BIT_7 = 66, // 0x00000042
    SYNC_OK = 67, // 0x00000043
    SYNC_NOK = 68, // 0x00000044
    SYNC_SPINDLE_1_OK = 69, // 0x00000045
    SYNC_SPINDLE_1_NOK = 70, // 0x00000046
    SYNC_SPINDLE_2_OK = 71, // 0x00000047
    SYNC_SPINDLE_2_NOK = 72, // 0x00000048
    SYNC_SPINDLE_3_OK = 73, // 0x00000049
    SYNC_SPINDLE_3_NOK = 74, // 0x0000004A
    SYNC_SPINDLE_4_OK = 75, // 0x0000004B
    SYNC_SPINDLE_4_NOK = 76, // 0x0000004C
    SYNC_SPINDLE_5_OK = 77, // 0x0000004D
    SYNC_SPINDLE_5_NOK = 78, // 0x0000004E
    SYNC_SPINDLE_6_OK = 79, // 0x0000004F
    SYNC_SPINDLE_6_NOK = 80, // 0x00000050
    SYNC_SPINDLE_7_OK = 81, // 0x00000051
    SYNC_SPINDLE_7_NOK = 82, // 0x00000052
    SYNC_SPINDLE_8_OK = 83, // 0x00000053
    SYNC_SPINDLE_8_NOK = 84, // 0x00000054
    SYNC_SPINDLE_9_OK = 85, // 0x00000055
    SYNC_SPINDLE_9_NOK = 86, // 0x00000056
    SYNC_SPINDLE_10_OK = 87, // 0x00000057
    SYNC_SPINDLE_10_NOK = 88, // 0x00000058
    LINE_CONTROL_START = 91, // 0x0000005B
    JOB_ABORTED = 92, // 0x0000005C
    EXTERNAL_CONTROLLED_1 = 93, // 0x0000005D
    EXTERNAL_CONTROLLED_2 = 94, // 0x0000005E
    EXTERNAL_CONTROLLED_3 = 95, // 0x0000005F
    EXTERNAL_CONTROLLED_4 = 96, // 0x00000060
    EXTERNAL_CONTROLLED_5 = 97, // 0x00000061
    EXTERNAL_CONTROLLED_6 = 98, // 0x00000062
    EXTERNAL_CONTROLLED_7 = 99, // 0x00000063
    EXTERNAL_CONTROLLED_8 = 100, // 0x00000064
    EXTERNAL_CONTROLLED_9 = 101, // 0x00000065
    EXTERNAL_CONTROLLED_10 = 102, // 0x00000066
    TOOLSNET_CONNECTION_LOST = 103, // 0x00000067
    OPEN_PROTOCOL_CONNECTION_LOST = 104, // 0x00000068
    FIELDBUS_OFFLINE = 105, // 0x00000069
    HOME_POSITION = 106, // 0x0000006A
    BATCH_NOK = 107, // 0x0000006B
    SELECTED_CHANNEL_IN_JOB = 108, // 0x0000006C
    SAFE_TO_DISCONNECT_TOOL = 109, // 0x0000006D
    RUNNING_JOB_BIT_8 = 110, // 0x0000006E
    RUNNING_PSET_BIT_8 = 111, // 0x0000006F
    CALIBRATION_ALARM = 112, // 0x00000070
    CYCLE_START = 113, // 0x00000071
    LOW_CURRENT = 114, // 0x00000072
    HIGH_CURRENT = 115, // 0x00000073
    LOW_PVT_MONITORING = 116, // 0x00000074
    HIGH_PVT_MONITORING = 117, // 0x00000075
    LOW_PVT_SELF_TAP = 118, // 0x00000076
    HIGH_PVT_SELF_TAP = 119, // 0x00000077
    LOW_TIGHTENING_ANGLE = 120, // 0x00000078
    HIGH_TIGHTENING_ANGLE = 121, // 0x00000079
    IDENTIFIER_IDENTIFIED = 122, // 0x0000007A
    IDENTIFIER_TYPE_1_RECEIVED = 123, // 0x0000007B
    IDENTIFIER_TYPE_2_RECEIVED = 124, // 0x0000007C
    IDENTIFIER_TYPE_3_RECEIVED = 125, // 0x0000007D
    IDENTIFIER_TYPE_4_RECEIVED = 126, // 0x0000007E
    RING_BUTTON_ACK = 129, // 0x00000081
    DIGIN_CONTROLLED_1 = 130, // 0x00000082
    DIGIN_CONTROLLED_2 = 131, // 0x00000083
    DIGIN_CONTROLLED_3 = 132, // 0x00000084
    DIGIN_CONTROLLED_4 = 133, // 0x00000085
    FIELDBUS_CARRIED_SIGNALS_DISABLED = 134, // 0x00000086
    ILLUMINATOR = 135, // 0x00000087
    NEW_PARAMETER_SET_SELECTED = 136, // 0x00000088
    NEW_JOB_SELECTED = 137, // 0x00000089
    JOB_OFF_RELAY = 138, // 0x0000008A
    LOGIC_RELAY_1 = 139, // 0x0000008B
    LOGIC_RELAY_2 = 140, // 0x0000008C
    LOGIC_RELAY_3 = 141, // 0x0000008D
    LOGIC_RELAY_4 = 142, // 0x0000008E
    MAX_COHERENT_NOK_REACHED = 143, // 0x0000008F
    BATCH_DONE = 144, // 0x00000090
    START_TRIGGER_ACTIVE = 145, // 0x00000091
    COMPLETED_BATCH_BIT_0 = 251, // 0x000000FB
    COMPLETED_BATCH_BIT_1 = 252, // 0x000000FC
    COMPLETED_BATCH_BIT_2 = 253, // 0x000000FD
    COMPLETED_BATCH_BIT_3 = 254, // 0x000000FE
    COMPLETED_BATCH_BIT_4 = 255, // 0x000000FF
    COMPLETED_BATCH_BIT_5 = 256, // 0x00000100
    COMPLETED_BATCH_BIT_6 = 257, // 0x00000101
    REMAINING_BATCH_BIT_0 = 259, // 0x00000103
    REMAINING_BATCH_BIT_1 = 260, // 0x00000104
    REMAINING_BATCH_BIT_2 = 261, // 0x00000105
    REMAINING_BATCH_BIT_3 = 262, // 0x00000106
    REMAINING_BATCH_BIT_4 = 263, // 0x00000107
    REMAINING_BATCH_BIT_5 = 264, // 0x00000108
    REMAINING_BATCH_BIT_6 = 265, // 0x00000109
    OPEN_PROTOCOL_COMMANDS_DISABLED = 275, // 0x00000113
    CYCLE_ABORT = 276, // 0x00000114
    EFFECTIVE_LOOSENING = 277, // 0x00000115
    LOGIC_RELAY_5 = 278, // 0x00000116
    LOGIC_RELAY_6 = 279, // 0x00000117
    LOGIC_RELAY_7 = 280, // 0x00000118
    LOGIC_RELAY_8 = 281, // 0x00000119
    LOGIC_RELAY_9 = 282, // 0x0000011A
    LOGIC_RELAY_10 = 283, // 0x0000011B
    LOCK_AT_BATCH_DONE = 284, // 0x0000011C
    BATTERY_LOW = 287, // 0x0000011F
    BATTERY_EMPTY = 288, // 0x00000120
    TOOL_CONNECTED = 289, // 0x00000121
    NO_TOOL_CONNECTED = 290, // 0x00000122
    FUNCTION_BUTTON = 293, // 0x00000125
    REHIT = 294, // 0x00000126
    TIGHTENING_DISABLED = 295, // 0x00000127
    LOOSENING_DISABLED = 296, // 0x00000128
    POSITIONING_DISABLED = 297, // 0x00000129
    MOTOR_TUNING_DISABLED = 298, // 0x0000012A
    OPEN_END_TUNING_DISABLED = 299, // 0x0000012B
    TRACKING_DISABLED = 300, // 0x0000012C
    AUTOMATIC_MODE = 302, // 0x0000012E
    PLUS_EMERGENCY_MODE = 303, // 0x0000012F
    WEAR_INDICATOR = 304, // 0x00000130
    DIRECTION_ALERT = 305, // 0x00000131
    PLUS_BOLT_REWORKED = 306, // 0x00000132
    LINE_STOP = 307, // 0x00000133
    RUNNING_PSET_BIT_9 = 308, // 0x00000134
    ACTIVE_XML_RESULT_ACK = 309, // 0x00000135
    TOOL_IN_WORK_SPACE = 310, // 0x00000136
    TOOL_IN_PRODUCT_SPACE = 311, // 0x00000137
    XML_PROTOCOL_ACTIVE = 312, // 0x00000138
    TOOL_ENABLED_BY_XML = 313, // 0x00000139
    NECKING_FAILURE = 314, // 0x0000013A
    PLUS_PROTOCOL_NOT_ACTIVE = 315, // 0x0000013B
    PLUS_NO_TIGHTENING = 316, // 0x0000013C
    TAG_ID_ERROR = 317, // 0x0000013D
    JOB_ABORTION_IN_PROGRESS = 318, // 0x0000013E
    STOP_TIGHTENING = 319, // 0x0000013F
    SLOW_DOWN_TIGHTENING = 320, // 0x00000140
    MIDDLE_COURSE_TRIGGER_ACTIVE = 351, // 0x0000015F
    FRONT_TRIGGER_ACTIVE = 352, // 0x00000160
    REVERSE_TRIGGER_ACTIVE = 353, // 0x00000161
  }
}