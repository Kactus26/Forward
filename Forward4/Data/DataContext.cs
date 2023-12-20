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
            _context.CreateTableAsync<User>();
        }
        public async Task RegisterUser(string name, string password)
        {
            User user = new User()
            {
                Name = name, Password = password 
            };
            await _context.InsertAsync(user);
        }
        public async Task<ICollection<User>> GetUsers()
        {
            return await _context.Table<User>().ToListAsync();
        }
        public async Task<User> GetUserByName(string name) 
        {
            return await _context.Table<User>().FirstOrDefaultAsync(x => x.Name == name);
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
