using System;
using System.Collections;
using OurProject.API.Models;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace OurProject.API.Ports
{
    public interface IRepo
    {
        IEnumerable<User> GetAllUser();
        User GetUserById(int id);
        Task<ReadOnlyCollection<User>> GetAllUser(string titleStartsWith);
        Task<User> GetUserById(Guid id);
        Task<User> PersistUser(User user);
        Task DeleteUser(Guid parsedId);

        IEnumerable<Event> GetAllEvent();
        Event GetEventById(int id);
        Task<ReadOnlyCollection<Event>> GetAllEvent(string titleStartsWith);
        Task<Event> GetEventById(Guid id);
        Task<Event> PersistEvent(Event events);
        Task DeleteEvent(Guid parsedId);
    }
}