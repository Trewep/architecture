using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OurProject.API.Models;


namespace OurProject.API.Ports
{
    public class SqlEventOrgDatabase : IDatabase
    {
        private EventOrgContext _context;

        public SqlEventOrgDatabase(EventOrgContext context)
        {
            _context = context;
        }


        //UserThings
        public IEnumerable<User> GetAllUser()
        {
            return _context.users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.users.FirstOrDefault(p => p.Id == id);
        }

        public async Task<ReadOnlyCollection<User>> GetAllUser(string titleStartsWith)
        {

            var users = await _context.users.Where(x => EF.Functions.Like(x.Title, $"{titleStartsWith}%")).ToArrayAsync();
            return Array.AsReadOnly(users);
        }

        public async Task<User> GetUserById(Guid parsedId)
        {
            return await _context.users.FindAsync(parsedId);
        }

        public async Task<User> PersistUser(User user)
        {
            if (user.Id == null)
            {
                await _context.users.AddAsync(user);
            }
            else
            {
                _context.users.Update(user);
            }
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUser(Guid parsedId)
        {
            var user = await _context.users.FindAsync(parsedId);
            _context.users.Remove(user);
            await _context.SaveChangesAsync();
        }


        //EventThings
        public IEnumerable<Event> GetAllEvent()
        {
            return _context.events.ToList();
        }

        public Event GetEventById(int id)
        {
            return _context.events.FirstOrDefault(p => p.Id == id);
        }

        public async Task<ReadOnlyCollection<Event>> GetAllEvent(string titleStartsWith)
        {

            var events = await _context.events.Where(x => EF.Functions.Like(x.Title, $"{titleStartsWith}%")).ToArrayAsync();
            return Array.AsReadOnly(events);
        }

        public async Task<Event> GetEventById(Guid parsedId)
        {
            return await _context.events.FindAsync(parsedId);
        }

        public async Task<Event> PersistEvent(Event user)
        {
            if (user.Id == null)
            {
                await _context.events.AddAsync(user);
            }
            else
            {
                _context.events.Update(user);
            }
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteEvent(Guid parsedId)
        {
            var user = await _context.events.FindAsync(parsedId);
            _context.events.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}