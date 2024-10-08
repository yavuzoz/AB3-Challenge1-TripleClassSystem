using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopFrontend.Utilities
{
    public class RelayCommand : ICommand
    {
        private readonly Action _execute; // Action to execute
        private readonly Func<bool> _canExecute; // Function to determine if the command can execute

        // Event triggered when CanExecute changes
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; } // Add handler to CommandManager
            remove { CommandManager.RequerySuggested -= value; } // Remove handler from CommandManager
        }

        // Constructor accepting the execute action and an optional canExecute function
        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute)); // Ensure execute is not null
            _canExecute = canExecute; // Assign the canExecute function
        }

        // Determines if the command can execute
        public bool CanExecute(object parameter) => _canExecute == null || _canExecute();

        // Executes the command
        public void Execute(object parameter) => _execute();
    }

}
