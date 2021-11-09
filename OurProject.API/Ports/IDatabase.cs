using System;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using OurProject.API.Models;

namespace OurProject.API.Ports
{
    public interface IDatabase
    {
        IEnumerable<User> GetAllUser();
        User GetUserById(int id);
        Task<ReadOnlyCollection<User>> GetAllUser(string titleStartsWith);
        Task<User> GetUserById(Guid id);
        Task<User> PersistUser(User users);
        Task DeleteUser(Guid parsedId);

        IEnumerable<Event> GetAllEvent();
        Event GetEventById(int id);
        Task<ReadOnlyCollection<Event>> GetAllEvent(string titleStartsWith);
        Task<Event> GetEventById(Guid id);
        Task<Event> PersistEvent(Event events);
        Task DeleteEvent(Guid parsedId);
    }
}