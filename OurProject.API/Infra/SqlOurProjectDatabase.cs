//System
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Microsoft
using Microsoft.EntityFrameworkCore;

//OurProject
using OurProject.API.Domains;
using OurProject.API.Ports;


namespace OurProject.API.Infra
{
    public class SqlOurProjectDatabase : IDatabase
    {
        private OurProjectContext _context;

        public SqlOurProjectDatabase(OurProjectContext context)
        {
            _context = context;
        }

        public async Task DeleteUser(int parsedId)
        {
            var user = await _context.User.FindAsync(parsedId);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<ReadOnlyCollection<User>> GetAllUser(string nameStartsWith)
        {
            var users = await _context.User.Where(x => EF.Functions.Like(x.personName, $"{nameStartsWith}%")).ToArrayAsync();
            return Array.AsReadOnly(users);
        }

        public async Task<User> GetUserById(int parsedId)
        {
            return await _context.User.FindAsync(parsedId);
        }

        public async Task<User> PersistUser(User User)
        {
            if (User.Id == 0)
            {
                await _context.User.AddAsync(User);
            }
            else
            {
                _context.User.Update(User);
            }
            await _context.SaveChangesAsync();
            return User;
        }
        //Event 
        public async Task DeleteEvent(int id)
        {
            var event_ = await _context.Events.FindAsync(id);
            _context.Events.Remove(event_);
            await _context.SaveChangesAsync();
        }

        public async Task<ReadOnlyCollection<Event>> GetAllEvents(string nameStartsWith)
        {
            var events = await _context.Events.Where(x => EF.Functions.Like(x.eventName, $"{nameStartsWith}%")).ToArrayAsync();
            return Array.AsReadOnly(events);
        }

        public async Task<Event> GetEventById(int parsedId)
        {
            return await _context.Events.FindAsync(parsedId);
        }

        public async Task<Event> PersistEvent(Event event_)
        {
            if (event_.Id == 0)
            {
                await _context.Events.AddAsync(event_);
            }
            else
            {
                _context.Events.Update(event_);
            }
            await _context.SaveChangesAsync();
            return event_;
        }
    }
}