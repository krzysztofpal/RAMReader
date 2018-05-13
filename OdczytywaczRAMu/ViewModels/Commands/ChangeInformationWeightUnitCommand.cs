using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OdczytywaczRAMu.ViewModels.Commands
{
    public class ChangeInformationWeightUnitCommand : ICommand
    {
        Action<object> executeMethod;
        Func<object, bool> canExecuteMethod;

        public ChangeInformationWeightUnitCommand(Action<object> executeMethod, Func<object, bool> canExecuteMethod)
        {
            this.executeMethod = executeMethod;
            this.canExecuteMethod = canExecuteMethod;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (canExecuteMethod != null)
                return canExecuteMethod(parameter);
            else
                return false;
        }

        public void Execute(object parameter)
        {
            executeMethod(parameter);
        }
    }
}
