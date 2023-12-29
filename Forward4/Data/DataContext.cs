using Forward4.Model;
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
            await _context.CreateTableAsync<Lessons>();
            await _context.CreateTableAsync<UserKurses>();
            await _context.CreateTableAsync<Kurses>();
            int seed = await _context.Table<Kurses>().CountAsync();
            if(seed == 0)
            {
                Kurses GojoKurse = new Kurses { Author = "Gojo Satoru", Description = "Most powerfull sorcerer in the world", LessonsCount = 5, Name = "Obratnaya Technika", ImageUrl= "kursimagegojo" };
                Kurses MikuKurse = new Kurses { Author = "Hatsune Miku", Description = "Wxplanation of how to be a good dj", LessonsCount = 3, Name = "Soprano", ImageUrl = "kursimagemiku" };
                Kurses TestKurse = new Kurses { Author = "Test", Description = "test", LessonsCount = 3, Name = "test", ImageUrl = "presentsimple" };
                await _context.InsertAsync(GojoKurse);
                await _context.InsertAsync(MikuKurse);
                await _context.InsertAsync(TestKurse);
                Lessons lesson1 = new Lessons { LessonName = "Concentreation", BelongsToKurse = GojoKurse, KurseId = GojoKurse.Id};
                Lessons lesson2 = new Lessons { LessonName = "Emotions", BelongsToKurse = GojoKurse, KurseId = GojoKurse.Id };
                await _context.InsertAsync(lesson1);
                await _context.InsertAsync(lesson2);
                Lessons lesson3 = new Lessons { LessonName = "Voice", BelongsToKurse = MikuKurse, KurseId = GojoKurse.Id };
                Lessons lesson4 = new Lessons { LessonName = "Confidence", BelongsToKurse = MikuKurse, KurseId = GojoKurse.Id };
                await _context.InsertAsync(lesson3);
                await _context.InsertAsync(lesson4);
                User admin = new User { Id = 0, Name = "Kactus", Password = "111"};
                admin.UserKurses.Add(MikuKurse);
                await _context.InsertAsync(admin);
            }
            var test = await _context.Table<Kurses>().FirstOrDefaultAsync();
        }

        public async Task AddKursToUser(Kurses kurs)
        {
            /*Active userId = await _context.Table<Active>().FirstOrDefaultAsync();
            User user = await _context.Table<User>().FirstOrDefaultAsync(x => x.Id == userId.Id);
            user.UserKurses.Add(kurs);
            await _context.UpdateAsync(user);*/
        }

        public async Task<List<Kurses>> GetAllKurses()
        {
            return await _context.Table<Kurses>().ToListAsync();
        }

        public async Task<int> NewId()
        {
            List<User> list = await _context.Table<User>().OrderByDescending(x => x.Id).ToListAsync();
            return ++list[0].Id;
        }

        public async Task NewActiveUser(int userId)
        {
            await _context.DeleteAllAsync<Active>();
            User user = await _context.Table<User>().FirstOrDefaultAsync(x => x.Id == userId);
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
