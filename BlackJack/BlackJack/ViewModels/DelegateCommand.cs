using System;
using System.Windows.Input;

namespace BlackJack.ViewModels
{
    public class DelegateCommand : ICommand
    {
        private readonly Action _Action;
        public DelegateCommand(Action hit)
        {
            _Action = hit;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _Action();
        }

        public event EventHandler CanExecuteChanged{ add { } remove { } }
    }
}