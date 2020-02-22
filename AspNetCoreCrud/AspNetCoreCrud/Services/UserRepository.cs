using AspNetCoreCrud.Context;
using AspNetCoreCrud.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreCrud.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;
        public UserRepository(UserDbContext dbContext)
        {
            this._context = dbContext;
        }

        public async Task<User> AddUser(User user)
        {
            this._context.Users.Add(user);
            await this._context.SaveChangesAsync();
            return user;
        }

        public User DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> EditUser(int userId,User user)
        {
            if(userId != user.UserId)
            {
                return null;
            }
            this._context.Entry(user).State = EntityState.Modified;
            try
            {
                await this._context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExist(userId))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return user;
        }

        public async Task<IQueryable<User>> GetAllUsers()
        {
            var listUsers = await this._context.Users.ToListAsync();
            return listUsers.AsQueryable();
        }

        public async Task<User> GetUser(int userId)
        {
            var user =  from users in this._context.Users 
                       where users.UserId == userId
                       select users;
            if(user == null)
            {
                return null;
            }
            return await user.FirstOrDefaultAsync();
        }

        public bool UserExist(int userId)
        {
            var user = from users in this._context.Users
                       where users.UserId == userId
                       select users;
            return user.Any();
        }
    }
}
