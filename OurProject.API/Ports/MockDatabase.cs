using System;
using System.Collections;
using OurProject.API.Models;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace OurProject.API.Ports
{
    //fake data to test if our API works
    public class MockDatabase : IDatabase
    {

        //users
        public IEnumerable<User> GetAllUser()
        {
            var users = new List<User>
            {
                new User { Id = 0, personName = "John Snow", personMail = "johnsnow@got.com", personBirth = "11/01/1989" },
                new User { Id = 1, personName = "John Wick", personMail = "johnwick@got.com", personBirth = "01/11/1979" },
                new User { Id = 2, personName = "John Mike", personMail = "johnmike@got.com", personBirth = "06/8/2000" }
            };

            return users;
        }

        public User GetUserById(int id)
        {
            return new User { Id = 0, personName = "John Snow", personMail = "johnsnow@got.com", personBirth = "11/01/1989" };
        }

        public async Task<ReadOnlyCollection<User>> GetAllUser(string titleStartsWith)
        {

            var users = await _context.User.Where(x => EF.Functions.Like(x.Title, $"{titleStartsWith}%")).ToArrayAsync();
            return Array.AsReadOnly(users);
        }

        public async Task<User> GetUserById(Guid parsedId)
        {
            return await _context.User.FindAsync(parsedId);
        }

        public async Task<User> PersistUser(User users)
        {
            if (user.Id == null)
            {
                await _context.User.AddAsync(user);
            }
            else
            {
                _context.User.Update(user);
            }
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUser(Guid parsedId)
        {
            var users = await _context.User.FindAsync(parsedId);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
        }



        // events
        public IEnumerable<Event> GetAllEvent()
        {
            var events = new List<Event>
            {
                new Event
                {
                Id = 0,
                eventName = "Walkin in the woods",
                eventDate = "01/01/2022",
                eventDescription = "We are going into the woods to find some cool stuff",
                eventMinAge = 18,
                eventMaxAge = 34,
                eventEnroll = null,
                eventEnrollDate = null,
                eventCounter = null,
                eventPersonList = null,
                },

                new Event
                {
                Id = 2,
                eventName = "Running on the sidewalks",
                eventDate = "06/12/2021",
                eventDescription = "We are going onto the side off the roads to feel the true dangers of our society",
                eventMinAge = 8,
                eventMaxAge = 99,
                eventEnroll = null,
                eventEnrollDate = null,
                eventCounter = null,
                eventPersonList = null,
                }
            };

            return events;
        }

        public Event GetEventById(int id)
        {
            return new Event { Id = 0, personName = "John Snow", personMail = "johnsnow@got.com", personBirth = "11/01/1989" };
        }

        public async Task<ReadOnlyCollection<Event>> GetAllEvent(string titleStartsWith)
        {

            var events = await _context.User.Where(x => EF.Functions.Like(x.Title, $"{titleStartsWith}%")).ToArrayAsync();
            return Array.AsReadOnly(events);
        }

        public async Task<Event> GetEventById(Guid parsedId)
        {
            return await _context.Event.FindAsync(parsedId);
        }

        public async Task<Event> PersistEvent(Event events)
        {
            if (events.Id == null)
            {
                await _context.Event.AddAsync(events);
            }
            else
            {
                _context.Event.Update(events);
            }
            await _context.SaveChangesAsync();
            return events;
        }

        public async Task DeleteEvent(Guid parsedId)
        {
            var events = await _context.events.FindAsync(parsedId);
            _context.Event.Remove(events);
            await _context.SaveChangesAsync();
        }
    }


    /*public class MockDatabase : IEventRepo
    {

    }*/



}