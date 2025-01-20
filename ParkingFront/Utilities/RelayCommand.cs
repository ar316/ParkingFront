using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParkingFront.Utilities
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Func<T, bool> _canExecute;

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }

            if (parameter == null && typeof(T).IsValueType)
            {
                return _canExecute(default(T));
            }

            return parameter == null || parameter is T && _canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            Debug.WriteLine("si entra");
            if (parameter == null && typeof(T).IsValueType)
            {
                Debug.WriteLine("Parameter is null, using default value for value type.");
                _execute(default(T));
                return;
            }

            if (parameter == null || parameter is T)
            {
                Debug.WriteLine($"Executing with parameter: {parameter}, Type: {parameter?.GetType()}");
                _execute((T)parameter);
            }
            else
            {
                Debug.WriteLine($"Invalid parameter type: {parameter?.GetType()}, expected: {typeof(T)}");
            }
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}

