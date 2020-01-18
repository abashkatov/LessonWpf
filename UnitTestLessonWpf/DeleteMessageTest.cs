using System;
using System.Collections.ObjectModel;
using LessonWpf.Command;
using LessonWpf.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestLessonWpf
{
    [TestClass]
    public class DeleteMessageTest
    {
        [TestMethod]
        public void TestExecute()
        {
            ObservableCollection<Message> messages = new ObservableCollection<Message>();
            DeleteMessage service = new DeleteMessage(messages);
            Message message = new Message("Test");
            service.Execute(message);
            Assert.AreEqual(0, messages.Count);
        }
    }
}
