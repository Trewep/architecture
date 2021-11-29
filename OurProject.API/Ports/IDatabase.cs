//System
using System;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Generic;

//OurProject
using OurProject.API.Domains;

//Namespace
namespace OurProject.API.Ports
{
    public interface IDatabase
    {
        Task<ReadOnlyCollection<User>> GetAllUser(string users);
        Task<User> GetUserById(int id);
        Task<User> PersistUser(User user);
        Task DeleteUser(int parsedId);

        Task<ReadOnlyCollection<Event>> GetAllEvents(string events);
        Task<Event> GetEventById(int id);
        Task<Event> PersistEvent(Event event_);
        Task DeleteEvent(int id);





        /*User
        Task<ReadOnlyCollection<User>> GetAllUser(string titleStartsWith);
        Task<User> GetUserById(int id);
        Task<User> PersistUser(User users);
        Task DeleteUser(int parsedId);

        //Event
        Task<Event> GetEventById(int id);
        Task<ReadOnlyCollection<Event>> GetAllEvent(string titleStartsWith);
        Task<Event> PersistEvent(Event events);
        Task DeleteEvent(int parsedId);*/
    }
}