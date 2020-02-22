using AspNetCoreCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreCrud.Services
{
    public interface IUserRepository
    {
        Task<IQueryable<User>> GetAllUsers();
        Task<User> GetUser(int UserId);
        Task<User> EditUser(int UserId,User user);
        Task<User> AddUser(User user);
        User DeleteUser(User user);
        bool UserExist(int id);

    }
}
