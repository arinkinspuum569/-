using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace разбор_анимации
{
    public class BindCommand : ICommand // Это объявление класса BindCommand, который реализует интерфейс ICommand.
    {
        private Action _execute;

        public event EventHandler CanExecuteChanged; // Событие CanExecuteChanged вызывается при изменении состояния команды.

        public BindCommand(Action execute)
        {
            _execute = execute; // делегат сохранен в поле _execute
        }

        public bool CanExecute(object parameter) //Функция CanExecute возвращает true, если команда включена и доступна для использования, и false, если команда отключена
        {
            return true;
        }

        public void Execute(object parameter) //Метод Execute предназначен для хранения логики команды.
        {
            _execute?.Invoke(); // он вызывает делегат, сохраненнный в поле _execute, если он не равен null.
        }
    }
}
