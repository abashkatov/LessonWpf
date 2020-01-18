using LessonWpf.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LessonWpf.Command
{
    public class AddMessage : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private ObservableCollection<Message> Messages;

        public AddMessage(ObservableCollection<Message> messages)
        {
            Messages = messages;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Messages?.Add(new Message("Из команды"));
        }
    }
}
