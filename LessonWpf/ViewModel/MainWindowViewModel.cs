using LessonWpf.Command;
using LessonWpf.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LessonWpf.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Message> Messages { get; set; }
        private Message selectedMessage;
        public Message SelectedMessage {
            get {
                return selectedMessage;
            }
            set
            {
                selectedMessage = value;
                NotifyPropertyChanged("SelectedMessage");
            }
        }

        public AddMessage AddMessageCommand { get; }
        public DeleteMessage DeleteMessageCommand { get; }

        public MainWindowViewModel(ObservableCollection<Message> messages) {
            Messages = messages;
            AddMessageCommand = new AddMessage(Messages);
            DeleteMessageCommand = new DeleteMessage(Messages);
        }
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
