using Geesemon.Database.Models;
using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Geesemon.GraphQL.Modules.Messages
{
    public class MessagesService
    {
        private readonly ISubject<Message> _addMessageStream;

        public MessagesService()
        {
            _addMessageStream = new ReplaySubject<Message>(1);
        }

        public void AddMessage(Message message) => _addMessageStream.OnNext(message);
        public IObservable<Message> MessageAddedSubscribe() => _addMessageStream.AsObservable();
    }
}
