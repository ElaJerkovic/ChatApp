using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
/*
For example, a 'Button' control's 'Command' property can be bound to a RelayCommand instance in the ViewModel. 
When the user clicks the button, the RelayCommand's Execute method is called,
which in turn executes the encapsulated method.

The canExecute delegate in the RelayCommand constructor provides a way to determine whether
the command can currently be executed. This can be useful when the command's execution depends
on some state or condition in the ViewModel or elsewhere.
 */

namespace ChatClient.MVVM.Core
{
    class RelayCommand : ICommand /*using ICommand interface to provide standard 
                                    way to UI elements to be bound to code*/ 
    {
        private Action<object> execute;//method to be executed
        private Func<object, bool> canExecute;//to determine whether he command to be executed

        public event EventHandler CanExecuteChanged/*to notify the UI element that the
                                                    command's canExecute value has changed*/
        {
            add { CommandManager.RequerySuggested += value; }/*to notify the UI that a command's
                                                              CanExecute value may have changed*/
            remove { CommandManager.RequerySuggested -= value; }
        }
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            //if cnaExecute == null than command can be executed
            //if not than calling the delegate with specified parameter to determine whether the command can be executed
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)//called when the command is executed
        {
            this.execute(parameter);
        }
    }
}
