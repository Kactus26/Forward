using Forward4.Model;
using Microsoft.EntityFrameworkCore;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forward4.Data
{
    public class DataContext
    {
        private const string dbName = "best.db3";
        private readonly SQLiteAsyncConnection _context;
        public DataContext()
        {
            _context = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, dbName));
            Init();
        }

        public async Task Init()
        {
            await _context.CreateTableAsync<User>();
            await _context.CreateTableAsync<Active>();
            int seed = await _context.Table<User>().CountAsync();
            if (seed == 0)
            {
                User admin = new User { Id = 0, Name = "Kactus", Password = "111" };
                await _context.InsertAsync(admin);
            }
        }

        public async Task<int> NewId()
        {
            List<User> list = await _context.Table<User>().OrderByDescending(x => x.Id).ToListAsync();
            return ++list[0].Id;
        }

        public async Task NewActiveUser(int userId)
        {
            await _context.DeleteAllAsync<Active>();
            Active actUser = new Active { UserId = userId };
            await _context.InsertAsync(actUser);
        }

        public async Task DeleteAll()
        {
            await _context.DeleteAllAsync<User>();
            await _context.DeleteAllAsync<Active>();
        }

        public async Task<int> GetActiveUser()
        {
            Active activeUser = await _context.Table<Active>().FirstAsync();
            return activeUser.UserId;
        }

        public async Task RegisterUser(User user)
        {
            await _context.InsertAsync(user);
        }

        public async Task<ICollection<User>> GetUsers()
        {
            return await _context.Table<User>().ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Table<User>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetUserByName(string name) 
        {
            return await _context.Table<User>().FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<bool> CheckActiveUserExists()
        {
            bool condition = await _context.Table<Active>().CountAsync() != 0;
            if (await _context.Table<Active>().CountAsync() != 0)
                return true;
            else
                return false;
        }

        public async Task<bool> CheckUsersExists(string name)
        {
            if (await _context.Table<User>().FirstOrDefaultAsync(x => x.Name == name) != null)
                return true;
            else
                return false;
        }
    }
}
