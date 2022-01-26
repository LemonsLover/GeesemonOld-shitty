using Geesemon.Database.Models;
using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Geesemon.GraphQL.Services
{
    public class ChatsService
    {
        private readonly ISubject<Chat> _addChatStream;

        public ChatsService()
        {
            _addChatStream = new ReplaySubject<Chat>(1);
        }

        public void AddChat(Chat chat) => _addChatStream.OnNext(chat);
        public IObservable<Chat> ChatAddedSubscribe() => _addChatStream.AsObservable();
    }
}
