using System;
using System.Windows.Input;

namespace calculadoraDias.Helpers
{
    public class command : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action _execute;

        public command(Action execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute.Invoke();
        }
    }
}
