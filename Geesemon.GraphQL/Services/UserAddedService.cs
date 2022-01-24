using Geesemon.Database.Models;
using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Geesemon.GraphQL.Services
{
    public class UserAddedService
    {
        private readonly ISubject<User> _userStream;

        public UserAddedService()
        {
            _userStream = new ReplaySubject<User>(1);
        }

        public void Add(User user) => _userStream.OnNext(user);

        public IObservable<User> Subscribe() => _userStream.AsObservable();
    }
}
