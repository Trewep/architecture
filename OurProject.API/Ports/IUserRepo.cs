/*using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using OurProject.API.Models;
using System.Collections.Generic;

namespace OurProject.API.Ports
{
    public interface IUserRepo
    {
        IEnumerable<User> GetAllUser();
        User GetUserById(int id);
        Task<ReadOnlyCollection<User>> GetAllUser(string titleStartsWith);
        Task<User> GetUserById(Guid id);
        Task<User> PersistUser(User user);
        Task DeleteUser(Guid parsedId);
    }

}*/