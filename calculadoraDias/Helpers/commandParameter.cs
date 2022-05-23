using System;
using System.Windows.Input;

namespace calculadoraDias.Helpers
{
    public class commandParameter : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<object> _execute;

        public commandParameter(Action<object> execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute.Invoke(parameter);
        }
    }
}
