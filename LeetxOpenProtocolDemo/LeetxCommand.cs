using System;
using System.Windows.Input;

namespace Leetx.OpenProtocolDemo
{
    internal class LeetxCommand : ICommand
    {

        Action<object> execute;
        Predicate<object> canExecute;
        public event EventHandler CanExecuteChanged;
        public LeetxCommand(Action<object> execute)
            : this(execute, null)
        { }
        public LeetxCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute is null ,command must add a Action");
            }
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute(parameter);
        }

        public void Execute(object parameter)
        {
             execute(parameter);
        }
    }
}
