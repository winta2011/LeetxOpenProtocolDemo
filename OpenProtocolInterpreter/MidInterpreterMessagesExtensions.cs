
// Type: OpenProtocolInterpreter.MidInterpreterMessagesExtensions
using OpenProtocolInterpreter.Alarm;
using OpenProtocolInterpreter.ApplicationController;
using OpenProtocolInterpreter.ApplicationSelector;
using OpenProtocolInterpreter.ApplicationToolLocationSystem;
using OpenProtocolInterpreter.AutomaticManualMode;
using OpenProtocolInterpreter.Communication;
using OpenProtocolInterpreter.IOInterface;
using OpenProtocolInterpreter.Job;
using OpenProtocolInterpreter.Job.Advanced;
using OpenProtocolInterpreter.Messages;
using OpenProtocolInterpreter.MotorTuning;
using OpenProtocolInterpreter.MultipleIdentifiers;
using OpenProtocolInterpreter.MultiSpindle;
using OpenProtocolInterpreter.OpenProtocolCommandsDisabled;
using OpenProtocolInterpreter.ParameterSet;
using OpenProtocolInterpreter.PLCUserData;
using OpenProtocolInterpreter.PowerMACS;
using OpenProtocolInterpreter.Result;
using OpenProtocolInterpreter.Statistic;
using OpenProtocolInterpreter.Tightening;
using OpenProtocolInterpreter.Time;
using OpenProtocolInterpreter.Tool;
using OpenProtocolInterpreter.UserInterface;
using OpenProtocolInterpreter.Vin;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OpenProtocolInterpreter
{
  public static class MidInterpreterMessagesExtensions
  {
    public static MidInterpreter UseAllMessages(
      this MidInterpreter midInterpreter,
      InterpreterMode mode = InterpreterMode.Both)
    {
      return midInterpreter.UseAlarmMessages(mode).UseApplicationControllerMessage(mode).UseApplicationSelectorMessages(mode).UseApplicationToolLocationSystemMessages(mode).UseAutomaticManualModeMessages(mode).UseCommunicationMessages(mode).UseIOInterfaceMessages(mode).UseJobMessages(mode).UseAdvancedJobMessages(mode).UseMotorTuningMessages(mode).UseMultipleIdentifiersMessages(mode).UseMultiSpindleMessages(mode).UseOpenProtocolCommandsDisabledMessages(mode).UseParameterSetMessages(mode).UsePLCUserDataMessages(mode).UsePowerMACSMessages(mode).UseResultMessages(mode).UseStatisticMessages(mode).UseTighteningMessages(mode).UseTimeMessages(mode).UseToolMessages(mode).UseUserInterfaceMessages(mode).UseVinMessages(mode);
    }

    public static MidInterpreter UseAllMessages(
      this MidInterpreter midInterpreter,
      IEnumerable<Type> mids)
    {
      if (mids.Any<Type>((Func<Type, bool>) (x => !x.IsSubclassOf(typeof (Mid)))))
        throw new ArgumentException("All mids must inherit Mid class", nameof (mids));
      return midInterpreter.UseAlarmMessages(mids.Where<Type>((Func<Type, bool>) (x => MidInterpreterMessagesExtensions.DoesImplementInterface(x, typeof (IAlarm))))).UseApplicationControllerMessage(mids.Where<Type>((Func<Type, bool>) (x => MidInterpreterMessagesExtensions.DoesImplementInterface(x, typeof (IApplicationController))))).UseApplicationSelectorMessages(mids.Where<Type>((Func<Type, bool>) (x => MidInterpreterMessagesExtensions.DoesImplementInterface(x, typeof (IApplicationSelector))))).UseApplicationToolLocationSystemMessages(mids.Where<Type>((Func<Type, bool>) (x => MidInterpreterMessagesExtensions.DoesImplementInterface(x, typeof (IApplicationToolLocationSystem))))).UseAutomaticManualModeMessages(mids.Where<Type>((Func<Type, bool>) (x => MidInterpreterMessagesExtensions.DoesImplementInterface(x, typeof (IAutomaticManualMode))))).UseCommunicationMessages(mids.Where<Type>((Func<Type, bool>) (x => MidInterpreterMessagesExtensions.DoesImplementInterface(x, typeof (ICommunication))))).UseIOInterfaceMessages(mids.Where<Type>((Func<Type, bool>) (x => MidInterpreterMessagesExtensions.DoesImplementInterface(x, typeof (IIOInterface))))).UseJobMessages(mids.Where<Type>((Func<Type, bool>) (x => MidInterpreterMessagesExtensions.DoesImplementInterface(x, typeof (IJob))))).UseAdvancedJobMessages(mids.Where<Type>((Func<Type, bool>) (x => MidInterpreterMessagesExtensions.DoesImplementInterface(x, typeof (IAdvancedJob))))).UseMotorTuningMessages(mids.Where<Type>((Func<Type, bool>) (x => MidInterpreterMessagesExtensions.DoesImplementInterface(x, typeof (IMotorTuning))))).UseMultipleIdentifiersMessages(mids.Where<Type>((Func<Type, bool>) (x => MidInterpreterMessagesExtensions.DoesImplementInterface(x, typeof (IMultipleIdentifier))))).UseMultiSpindleMessages(mids.Where<Type>((Func<Type, bool>) (x => MidInterpreterMessagesExtensions.DoesImplementInterface(x, typeof (IMultiSpindle))))).UseOpenProtocolCommandsDisabledMessages(mids.Where<Type>((Func<Type, bool>) (x => MidInterpreterMessagesExtensions.DoesImplementInterface(x, typeof (IOpenProtocolCommandsDisabled))))).UseParameterSetMessages(mids.Where<Type>((Func<Type, bool>) (x => MidInterpreterMessagesExtensions.DoesImplementInterface(x, typeof (IParameterSet))))).UsePLCUserDataMessages(mids.Where<Type>((Func<Type, bool>) (x => MidInterpreterMessagesExtensions.DoesImplementInterface(x, typeof (IPLCUserData))))).UsePowerMACSMessages(mids.Where<Type>((Func<Type, bool>) (x => MidInterpreterMessagesExtensions.DoesImplementInterface(x, typeof (IPowerMACS))))).UseResultMessages(mids.Where<Type>((Func<Type, bool>) (x => MidInterpreterMessagesExtensions.DoesImplementInterface(x, typeof (IResult))))).UseStatisticMessages(mids.Where<Type>((Func<Type, bool>) (x => MidInterpreterMessagesExtensions.DoesImplementInterface(x, typeof (IStatistic))))).UseTighteningMessages(mids.Where<Type>((Func<Type, bool>) (x => MidInterpreterMessagesExtensions.DoesImplementInterface(x, typeof (ITightening))))).UseTimeMessages(mids.Where<Type>((Func<Type, bool>) (x => MidInterpreterMessagesExtensions.DoesImplementInterface(x, typeof (ITime))))).UseToolMessages(mids.Where<Type>((Func<Type, bool>) (x => MidInterpreterMessagesExtensions.DoesImplementInterface(x, typeof (ITool))))).UseUserInterfaceMessages(mids.Where<Type>((Func<Type, bool>) (x => MidInterpreterMessagesExtensions.DoesImplementInterface(x, typeof (IUserInterface))))).UseVinMessages(mids.Where<Type>((Func<Type, bool>) (x => MidInterpreterMessagesExtensions.DoesImplementInterface(x, typeof (IVin)))));
    }

    public static MidInterpreter UseCustomMessage(
      this MidInterpreter midInterpreter,
      IDictionary<int, Type> mids)
    {
      if (mids.Values.Any<Type>((Func<Type, bool>) (x => !x.IsSubclassOf(typeof (Mid)))))
        throw new ArgumentException("All mids must inherit Mid class", nameof (mids));
      CustomMessages template = new CustomMessages(mids);
      midInterpreter.UseTemplate((IMessagesTemplate) template);
      return midInterpreter;
    }

    public static MidInterpreter UseAlarmMessages(
      this MidInterpreter midInterpreter,
      InterpreterMode mode = InterpreterMode.Both)
    {
      midInterpreter.UseTemplate<AlarmMessages>(mode);
      return midInterpreter;
    }

    public static MidInterpreter UseAlarmMessages(
      this MidInterpreter midInterpreter,
      IEnumerable<Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IAlarm>(mids);
      midInterpreter.UseTemplate<AlarmMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseAlarmMessages(
      this MidInterpreter midInterpreter,
      IDictionary<int, Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IAlarm>(mids);
      midInterpreter.UseTemplate<AlarmMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseApplicationControllerMessage(
      this MidInterpreter midInterpreter,
      InterpreterMode mode = InterpreterMode.Both)
    {
      midInterpreter.UseTemplate<ApplicationControllerMessages>(mode);
      return midInterpreter;
    }

    public static MidInterpreter UseApplicationControllerMessage(
      this MidInterpreter midInterpreter,
      IEnumerable<Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IApplicationController>(mids);
      midInterpreter.UseTemplate<ApplicationControllerMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseApplicationControllerMessage(
      this MidInterpreter midInterpreter,
      IDictionary<int, Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IApplicationController>(mids);
      midInterpreter.UseTemplate<ApplicationControllerMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseApplicationSelectorMessages(
      this MidInterpreter midInterpreter,
      InterpreterMode mode = InterpreterMode.Both)
    {
      midInterpreter.UseTemplate<ApplicationSelectorMessages>(mode);
      return midInterpreter;
    }

    public static MidInterpreter UseApplicationSelectorMessages(
      this MidInterpreter midInterpreter,
      IEnumerable<Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IApplicationSelector>(mids);
      midInterpreter.UseTemplate<ApplicationSelectorMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseApplicationSelectorMessages(
      this MidInterpreter midInterpreter,
      IDictionary<int, Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IApplicationSelector>(mids);
      midInterpreter.UseTemplate<ApplicationSelectorMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseApplicationToolLocationSystemMessages(
      this MidInterpreter midInterpreter,
      InterpreterMode mode = InterpreterMode.Both)
    {
      midInterpreter.UseTemplate<ApplicationToolLocationSystemMessages>(mode);
      return midInterpreter;
    }

    public static MidInterpreter UseApplicationToolLocationSystemMessages(
      this MidInterpreter midInterpreter,
      IEnumerable<Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IApplicationToolLocationSystem>(mids);
      midInterpreter.UseTemplate<ApplicationToolLocationSystemMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseApplicationToolLocationSystemMessages(
      this MidInterpreter midInterpreter,
      IDictionary<int, Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IApplicationToolLocationSystem>(mids);
      midInterpreter.UseTemplate<ApplicationToolLocationSystemMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseAutomaticManualModeMessages(
      this MidInterpreter midInterpreter,
      InterpreterMode mode = InterpreterMode.Both)
    {
      midInterpreter.UseTemplate<AutomaticManualModeMessages>(mode);
      return midInterpreter;
    }

    public static MidInterpreter UseAutomaticManualModeMessages(
      this MidInterpreter midInterpreter,
      IEnumerable<Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IAutomaticManualMode>(mids);
      midInterpreter.UseTemplate<AutomaticManualModeMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseAutomaticManualModeMessages(
      this MidInterpreter midInterpreter,
      IDictionary<int, Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IAutomaticManualMode>(mids);
      midInterpreter.UseTemplate<AutomaticManualModeMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseCommunicationMessages(
      this MidInterpreter midInterpreter,
      InterpreterMode mode = InterpreterMode.Both)
    {
      midInterpreter.UseTemplate<CommunicationMessages>(mode);
      return midInterpreter;
    }

    public static MidInterpreter UseCommunicationMessages(
      this MidInterpreter midInterpreter,
      IEnumerable<Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<ICommunication>(mids);
      midInterpreter.UseTemplate<CommunicationMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseCommunicationMessages(
      this MidInterpreter midInterpreter,
      IDictionary<int, Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<ICommunication>(mids);
      midInterpreter.UseTemplate<CommunicationMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseIOInterfaceMessages(
      this MidInterpreter midInterpreter,
      InterpreterMode mode = InterpreterMode.Both)
    {
      midInterpreter.UseTemplate<IOInterfaceMessages>(mode);
      return midInterpreter;
    }

    public static MidInterpreter UseIOInterfaceMessages(
      this MidInterpreter midInterpreter,
      IEnumerable<Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IIOInterface>(mids);
      midInterpreter.UseTemplate<IOInterfaceMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseIOInterfaceMessages(
      this MidInterpreter midInterpreter,
      IDictionary<int, Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IIOInterface>(mids);
      midInterpreter.UseTemplate<IOInterfaceMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseJobMessages(
      this MidInterpreter midInterpreter,
      InterpreterMode mode = InterpreterMode.Both)
    {
      midInterpreter.UseTemplate<JobMessages>(mode);
      return midInterpreter;
    }

    public static MidInterpreter UseJobMessages(
      this MidInterpreter midInterpreter,
      IEnumerable<Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IJob>(mids);
      midInterpreter.UseTemplate<JobMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseJobMessages(
      this MidInterpreter midInterpreter,
      IDictionary<int, Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IJob>(mids);
      midInterpreter.UseTemplate<JobMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseAdvancedJobMessages(
      this MidInterpreter midInterpreter,
      InterpreterMode mode = InterpreterMode.Both)
    {
      midInterpreter.UseTemplate<AdvancedJobMessages>(mode);
      return midInterpreter;
    }

    public static MidInterpreter UseAdvancedJobMessages(
      this MidInterpreter midInterpreter,
      IEnumerable<Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IAdvancedJob>(mids);
      midInterpreter.UseTemplate<AdvancedJobMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseAdvancedJobMessages(
      this MidInterpreter midInterpreter,
      IDictionary<int, Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IAdvancedJob>(mids);
      midInterpreter.UseTemplate<AdvancedJobMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseMotorTuningMessages(
      this MidInterpreter midInterpreter,
      InterpreterMode mode = InterpreterMode.Both)
    {
      midInterpreter.UseTemplate<MotorTuningMessages>(mode);
      return midInterpreter;
    }

    public static MidInterpreter UseMotorTuningMessages(
      this MidInterpreter midInterpreter,
      IEnumerable<Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IMotorTuning>(mids);
      midInterpreter.UseTemplate<MotorTuningMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseMotorTuningMessages(
      this MidInterpreter midInterpreter,
      IDictionary<int, Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IMotorTuning>(mids);
      midInterpreter.UseTemplate<MotorTuningMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseMultipleIdentifiersMessages(
      this MidInterpreter midInterpreter,
      InterpreterMode mode = InterpreterMode.Both)
    {
      midInterpreter.UseTemplate<MultipleIdentifierMessages>(mode);
      return midInterpreter;
    }

    public static MidInterpreter UseMultipleIdentifiersMessages(
      this MidInterpreter midInterpreter,
      IEnumerable<Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IMultipleIdentifier>(mids);
      midInterpreter.UseTemplate<MultipleIdentifierMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseMultipleIdentifiersMessages(
      this MidInterpreter midInterpreter,
      IDictionary<int, Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IMultipleIdentifier>(mids);
      midInterpreter.UseTemplate<MultipleIdentifierMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseMultiSpindleMessages(
      this MidInterpreter midInterpreter,
      InterpreterMode mode = InterpreterMode.Both)
    {
      midInterpreter.UseTemplate<MultiSpindleMessages>(mode);
      return midInterpreter;
    }

    public static MidInterpreter UseMultiSpindleMessages(
      this MidInterpreter midInterpreter,
      IEnumerable<Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IMultiSpindle>(mids);
      midInterpreter.UseTemplate<MultiSpindleMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseMultiSpindleMessages(
      this MidInterpreter midInterpreter,
      IDictionary<int, Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IMultiSpindle>(mids);
      midInterpreter.UseTemplate<MultiSpindleMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseOpenProtocolCommandsDisabledMessages(
      this MidInterpreter midInterpreter,
      InterpreterMode mode = InterpreterMode.Both)
    {
      midInterpreter.UseTemplate<OpenProtocolCommandsDisabledMessages>(mode);
      return midInterpreter;
    }

    public static MidInterpreter UseOpenProtocolCommandsDisabledMessages(
      this MidInterpreter midInterpreter,
      IEnumerable<Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IOpenProtocolCommandsDisabled>(mids);
      midInterpreter.UseTemplate<OpenProtocolCommandsDisabledMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseOpenProtocolCommandsDisabledMessages(
      this MidInterpreter midInterpreter,
      IDictionary<int, Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IOpenProtocolCommandsDisabled>(mids);
      midInterpreter.UseTemplate<OpenProtocolCommandsDisabledMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseParameterSetMessages(
      this MidInterpreter midInterpreter,
      InterpreterMode mode = InterpreterMode.Both)
    {
      midInterpreter.UseTemplate<ParameterSetMessages>(mode);
      return midInterpreter;
    }

    public static MidInterpreter UseParameterSetMessages(
      this MidInterpreter midInterpreter,
      IEnumerable<Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IParameterSet>(mids);
      midInterpreter.UseTemplate<ParameterSetMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseParameterSetMessages(
      this MidInterpreter midInterpreter,
      IDictionary<int, Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IParameterSet>(mids);
      midInterpreter.UseTemplate<ParameterSetMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UsePLCUserDataMessages(
      this MidInterpreter midInterpreter,
      InterpreterMode mode = InterpreterMode.Both)
    {
      midInterpreter.UseTemplate<PLCUserDataMessages>(mode);
      return midInterpreter;
    }

    public static MidInterpreter UsePLCUserDataMessages(
      this MidInterpreter midInterpreter,
      IEnumerable<Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IPLCUserData>(mids);
      midInterpreter.UseTemplate<PLCUserDataMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UsePLCUserDataMessages(
      this MidInterpreter midInterpreter,
      IDictionary<int, Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IPLCUserData>(mids);
      midInterpreter.UseTemplate<PLCUserDataMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UsePowerMACSMessages(
      this MidInterpreter midInterpreter,
      InterpreterMode mode = InterpreterMode.Both)
    {
      midInterpreter.UseTemplate<PowerMACSMessages>(mode);
      return midInterpreter;
    }

    public static MidInterpreter UsePowerMACSMessages(
      this MidInterpreter midInterpreter,
      IEnumerable<Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IPowerMACS>(mids);
      midInterpreter.UseTemplate<PowerMACSMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UsePowerMACSMessages(
      this MidInterpreter midInterpreter,
      IDictionary<int, Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IPowerMACS>(mids);
      midInterpreter.UseTemplate<PowerMACSMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseResultMessages(
      this MidInterpreter midInterpreter,
      InterpreterMode mode = InterpreterMode.Both)
    {
      midInterpreter.UseTemplate<ResultMessages>(mode);
      return midInterpreter;
    }

    public static MidInterpreter UseResultMessages(
      this MidInterpreter midInterpreter,
      IEnumerable<Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IResult>(mids);
      midInterpreter.UseTemplate<ResultMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseResultMessages(
      this MidInterpreter midInterpreter,
      IDictionary<int, Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IResult>(mids);
      midInterpreter.UseTemplate<ResultMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseStatisticMessages(
      this MidInterpreter midInterpreter,
      InterpreterMode mode = InterpreterMode.Both)
    {
      midInterpreter.UseTemplate<StatisticMessages>(mode);
      return midInterpreter;
    }

    public static MidInterpreter UseStatisticMessages(
      this MidInterpreter midInterpreter,
      IEnumerable<Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IStatistic>(mids);
      midInterpreter.UseTemplate<StatisticMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseStatisticMessages(
      this MidInterpreter midInterpreter,
      IDictionary<int, Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IStatistic>(mids);
      midInterpreter.UseTemplate<StatisticMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseTighteningMessages(
      this MidInterpreter midInterpreter,
      InterpreterMode mode = InterpreterMode.Both)
    {
      midInterpreter.UseTemplate<TighteningMessages>(mode);
      return midInterpreter;
    }

    public static MidInterpreter UseTighteningMessages(
      this MidInterpreter midInterpreter,
      IEnumerable<Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<ITightening>(mids);
      midInterpreter.UseTemplate<TighteningMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseTighteningMessages(
      this MidInterpreter midInterpreter,
      IDictionary<int, Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<ITightening>(mids);
      midInterpreter.UseTemplate<TighteningMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseTimeMessages(
      this MidInterpreter midInterpreter,
      InterpreterMode mode = InterpreterMode.Both)
    {
      midInterpreter.UseTemplate<TimeMessages>(mode);
      return midInterpreter;
    }

    public static MidInterpreter UseTimeMessages(
      this MidInterpreter midInterpreter,
      IEnumerable<Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<ITime>(mids);
      midInterpreter.UseTemplate<TimeMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseTimeMessages(
      this MidInterpreter midInterpreter,
      IDictionary<int, Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<ITime>(mids);
      midInterpreter.UseTemplate<TimeMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseToolMessages(
      this MidInterpreter midInterpreter,
      InterpreterMode mode = InterpreterMode.Both)
    {
      midInterpreter.UseTemplate<ToolMessages>(mode);
      return midInterpreter;
    }

    public static MidInterpreter UseToolMessages(
      this MidInterpreter midInterpreter,
      IEnumerable<Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<ITool>(mids);
      midInterpreter.UseTemplate<ToolMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseToolMessages(
      this MidInterpreter midInterpreter,
      IDictionary<int, Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<ITool>(mids);
      midInterpreter.UseTemplate<ToolMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseUserInterfaceMessages(
      this MidInterpreter midInterpreter,
      InterpreterMode mode = InterpreterMode.Both)
    {
      midInterpreter.UseTemplate<UserInterfaceMessages>(mode);
      return midInterpreter;
    }

    public static MidInterpreter UseUserInterfaceMessages(
      this MidInterpreter midInterpreter,
      IEnumerable<Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IUserInterface>(mids);
      midInterpreter.UseTemplate<UserInterfaceMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseUserInterfaceMessages(
      this MidInterpreter midInterpreter,
      IDictionary<int, Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IUserInterface>(mids);
      midInterpreter.UseTemplate<UserInterfaceMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseVinMessages(
      this MidInterpreter midInterpreter,
      InterpreterMode mode = InterpreterMode.Both)
    {
      midInterpreter.UseTemplate<VinMessages>(mode);
      return midInterpreter;
    }

    public static MidInterpreter UseVinMessages(
      this MidInterpreter midInterpreter,
      IEnumerable<Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IVin>(mids);
      midInterpreter.UseTemplate<VinMessages>(mids);
      return midInterpreter;
    }

    public static MidInterpreter UseVinMessages(
      this MidInterpreter midInterpreter,
      IDictionary<int, Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<IVin>(mids);
      midInterpreter.UseTemplate<VinMessages>(mids);
      return midInterpreter;
    }

    private static bool IsValid(IEnumerable<Type> mids, Type desiredInterface)
    {
      return mids.All<Type>((Func<Type, bool>) (x => MidInterpreterMessagesExtensions.DoesImplementInterface(x, desiredInterface) && x.IsSubclassOf(typeof (Mid))));
    }

    private static bool DoesImplementInterface(Type mid, Type desiredInterface)
    {
      return desiredInterface.IsAssignableFrom(mid);
    }

    private static void ThrowIfInvalid<T>(IEnumerable<Type> mids)
    {
      Type desiredInterface = typeof (T);
      if (!MidInterpreterMessagesExtensions.IsValid(mids, desiredInterface))
        throw new ArgumentException("Types should inherit Mid class and must implement " + desiredInterface.Name + " interface", nameof (mids));
    }

    private static void ThrowIfInvalid<T>(IDictionary<int, Type> mids)
    {
      MidInterpreterMessagesExtensions.ThrowIfInvalid<T>(mids.Select<KeyValuePair<int, Type>, Type>((Func<KeyValuePair<int, Type>, Type>) (x => x.Value)));
    }
  }
}
