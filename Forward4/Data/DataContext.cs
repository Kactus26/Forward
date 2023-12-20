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
        public async Task Add(string name)
        {
            User user = new User()
            {
                Name = name
            };
            await _context.InsertAsync(user);
        }
        public async Task<User> Read()
        {
            return await _context.Table<User>().FirstOrDefaultAsync();
        }
    }
}
