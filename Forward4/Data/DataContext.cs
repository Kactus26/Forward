using Forward4.Model;
using SQLite;
using SQLiteNetExtensions.Extensions;
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
        private readonly SQLiteConnection _context;
        public DataContext()
        {
            _context = new SQLiteConnection(Path.Combine(FileSystem.AppDataDirectory, dbName));
            Init();
        }

        public async Task Init()
        {
            _context.CreateTable<User>();
            _context.CreateTable<Active>();
            _context.CreateTable<Lessons>();
            _context.CreateTable<Kurses>();
            int seed = _context.Table<User>().Count();
            if (seed == 0)
            {
                User admin = new User { Id = 0, Name = "Kactus", Password = "111" };
                _context.Insert(admin);
            }
            seed = _context.Table<Kurses>().Count();
            if (seed == 0)
            {
                Kurses GojoKurse = new Kurses { Author = "Gojo Satoru", Description = "Most powerfull sorcerer in the world", LessonsCount = 5, Name = "Obratnaya Technika", ImageUrl = "kursimagegojo.jpg" };
                Kurses MikuKurse = new Kurses { Author = "Hatsune Miku", Description = "Wxplanation of how to be a good dj", LessonsCount = 3, Name = "Soprano", ImageUrl = "kursimagemiku.jpg" };
                _context.Insert(GojoKurse);
                _context.Insert(MikuKurse);
                Lessons lesson1 = new Lessons { LessonName = "Concentreation", KurseId = GojoKurse.Id };
                Lessons lesson2 = new Lessons { LessonName = "Emotions", KurseId = GojoKurse.Id };
                _context.Insert(lesson1);
                _context.Insert(lesson2);
                Lessons lesson3 = new Lessons { LessonName = "Voice", KurseId = GojoKurse.Id };
                Lessons lesson4 = new Lessons { LessonName = "Confidence", KurseId = GojoKurse.Id };
                _context.Insert(lesson3);
                _context.Insert(lesson4);
                GojoKurse.Lessonss = new List<Lessons> { lesson1, lesson2 };
                _context.UpdateWithChildren(GojoKurse);
                var a = _context.GetWithChildren<Kurses>(GojoKurse.Id);
            }
        }

        public List<Kurses> GetAllKurses()
        {
            return _context.Table<Kurses>().ToList();
        }

        public int NewId()
        {
            List<User> list = _context.Table<User>().OrderByDescending(x => x.Id).ToList();
            return ++list[0].Id;
        }

        public void NewActiveUser(int userId)
        {
            _context.DeleteAll<Active>();
            Active actUser = new Active { UserId = userId };
            _context.Insert(actUser);
        }

        public void DeleteAll()
        {
            _context.DeleteAll<User>();
            _context.DeleteAll<Active>();
        }

        public int GetActiveUser()
        {
            Active activeUser = _context.Table<Active>().First();
            return activeUser.UserId;
        }

        public void RegisterUser(User user)
        {
            _context.Insert(user);
        }

        public ICollection<User> GetUsers()
        {
            return _context.Table<User>().ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Table<User>().FirstOrDefault(x => x.Id == id);
        }

        public User GetUserByName(string name)
        {
            return _context.Table<User>().FirstOrDefault(x => x.Name == name);
        }

        public bool CheckActiveUserExists()
        {
            bool condition = _context.Table<Active>().Count() != 0;
            if (_context.Table<Active>().Count() != 0)
                return true;
            else
                return false;
        }

        public bool CheckUsersExists(string name)
        {
            if (_context.Table<User>().FirstOrDefault(x => x.Name == name) != null)
                return true;
            else
                return false;
        }
    }
}
