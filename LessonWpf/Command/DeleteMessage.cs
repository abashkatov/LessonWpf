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
    public class DeleteMessage : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private ObservableCollection<Message> Messages;

        public DeleteMessage(ObservableCollection<Message> messages) {
            Messages = messages;
        }

        public bool CanExecute(object parameter)
        {
            return parameter is Message;
        }

        public void Execute(object parameter)
        {
            if (parameter is Message)
            {
                Messages?.Remove((parameter as Message));
            }
        }
    }
}
