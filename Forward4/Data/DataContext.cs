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
            _context.CreateTable<Vocabulary>();
            _context.CreateTable<Lessons>();
            _context.CreateTable<Kurses>();
            int seed = _context.Table<User>().Count();
            if (seed == 0)
            {
                
                User admin = new User { Name = "Kactus", Password = "111", ActiveKurseId = 1 };
                _context.Insert(admin);
                Kurses gojoKurse = new Kurses { Author = "Gojo Satoru", UserId = admin.Id, Description = "Most powerfull sorcerer in the world", LessonsCount = 5, Name = "Obratnaya Technika", ImageUrl = "kursimagegojo.jpg" };
                Kurses mikuKurse = new Kurses { Author = "Hatsune Miku", UserId = admin.Id, Description = "Explanation of how to be a good dj", LessonsCount = 3, Name = "Soprano", ImageUrl = "kursimagemiku.jpg" };
                _context.Insert(gojoKurse);
                _context.Insert(mikuKurse);
                Vocabulary first = new Vocabulary { FirstWord = "Dog", SecondWord = "Собака", UserId = admin.Id };
                Vocabulary second = new Vocabulary { FirstWord = "Cat", SecondWord = "Кот", UserId = admin.Id };
                _context.Insert(first);
                _context.Insert(second);
                Lessons lesson1 = new Lessons { Name = "Concentreation", VideoUrl = "test.mp4", Description = "First lesson description", Text = "Примечание: На платформе .NET MAUI также есть более продвинутые способы реализации прокрутки и управления раскладкой, включая использование FlexLayout и других контейнеров. Вы можете выбрать подход, который наилучшим образом соответствует требованиям вашего приложения и дизайну.", KursId = gojoKurse.Id };
                Lessons lesson2 = new Lessons { Name = "Emotions", VideoUrl = "Raw/test.mp4", Description = "Second lesson description", KursId = gojoKurse.Id };
                _context.Insert(lesson1);
                _context.Insert(lesson2);
                Lessons lesson3 = new Lessons { Name = "Voice", VideoUrl = "test", Description = "First lesson description", KursId = mikuKurse.Id };
                Lessons lesson4 = new Lessons { Name = "Confidence", VideoUrl = "Raw/test", Description = "Second lesson description", KursId = mikuKurse.Id };
                _context.Insert(lesson3);
                _context.Insert(lesson4);
                gojoKurse.Lessons = new List<Lessons> { lesson1, lesson2 };
                _context.UpdateWithChildren(gojoKurse);
                admin.UserKurses = new List<Kurses> { gojoKurse };
                admin.UserVocabulary = new List<Vocabulary> { first, second };
                _context.UpdateWithChildren(admin);
            }
        }

        public List<Kurses> GetUserKurses(int userId)
        {
            User user = _context.FindWithChildren<User>(userId);
            if(user != null && user.UserKurses != null)
                return user.UserKurses;
            return null;
        }

        public List<Vocabulary> GetVocabularies(int userId) 
        {
            User user = _context.FindWithChildren<User>(userId);
            if (user != null && user.UserKurses != null)
                return user.UserVocabulary;
            return null;
        }

        public void AddKursToUser(Kurses selectedKurs, int userId)
        {
            User user = _context.FindWithChildren<User>(userId);
            Kurses test = user.UserKurses.FirstOrDefault(x => x.Id == selectedKurs.Id);
            if (test == null || user.UserKurses == null)
            {
                user.UserKurses.Add(selectedKurs);
                user.ActiveKurseId = selectedKurs.Id;
                _context.UpdateWithChildren(user);
                return;
            }
            user.ActiveKurseId = selectedKurs.Id;
            _context.Update(user);
        }

        public void DeleteKurs(User userId, int kursId)
        {
            User user = _context.GetWithChildren<User>(userId.Id);
            Kurses kurs = user.UserKurses.FirstOrDefault(x=>x.Id==kursId);
            user.ActiveKurseId = 0;
            user.UserKurses.Remove(kurs);
            _context.UpdateWithChildren(user);
        }

        public Lessons GetLesson(int lessonId)
        {
            return _context.Find<Lessons>(lessonId);
        }

        public Kurses GetKurs(int activeKursId)
        {
            Kurses kurs = _context.GetWithChildren<Kurses>(activeKursId);
            if (kurs != null)
                return kurs;
            return null;
        }

        public void UpdateUser(User user)
        {
            _context.Update(user);
        }
        
        public User GetUser()
        {
            int userId = GetActiveUser();
            return _context.GetWithChildren<User>(userId);
        }

        public List<Kurses> GetAllKurses()
        {
            return _context.Table<Kurses>().ToList();
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
