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
            _context.CreateTable<TaskPairs>();
            _context.CreateTable<TaskPairsCorrect>();
            _context.CreateTable<TaskPairsEnglish>();
            _context.CreateTable<TaskPairsRussian>();
            _context.CreateTable<TaskComplete>();
            _context.CreateTable<TaskTranslate>();
            _context.CreateTable<TranslationWords>();
            _context.CreateTable<Kurses>();
            int seed = _context.Table<User>().Count();
            if (seed == 0)
            {
                TaskTranslate taskTranslate = new TaskTranslate { Sentance = "Уберите от меня этого разработчика", CorrectSentance = "Get this developer away from me" };
                _context.Insert(taskTranslate);

                List<TranslationWords> words = new List<TranslationWords> { 
                    new TranslationWords { Word = "Get", TaskId = taskTranslate.Id },
                    new TranslationWords { Word = "from", TaskId = taskTranslate.Id },
                    new TranslationWords { Word = "me", TaskId = taskTranslate.Id },
                    new TranslationWords { Word = "away", TaskId = taskTranslate.Id },
                    new TranslationWords { Word = "this", TaskId = taskTranslate.Id },
                    new TranslationWords { Word = "developer", TaskId = taskTranslate.Id },
                    };
                _context.InsertAll(words);
                taskTranslate.Words = words;
                _context.UpdateWithChildren(taskTranslate);

                TaskComplete taskComplete = new TaskComplete { Sentence = "He was ___ man ever existed", Answear1 = "The strongest", Answear2 = "More stronger", Answear3 = "Most strongest", Answear4 = "The stronger", CorrectAnswear = "The strongest"};
                _context.Insert(taskComplete);

                TaskPairs taskPairs = new TaskPairs();
                _context.Insert(taskPairs);

                TaskPairsCorrect wordsCorrect = new TaskPairsCorrect { EWord1 = "Cat", RWord1 = "Кот", EWord2 = "Dog", RWord2 = "Собака", EWord3 = "Mouse", RWord3 = "Мышь", EWord4 = "Horse", RWord4 = "Лошадь", EWord5 = "Rabbit", RWord5 = "Заяц", TaskId = taskPairs.Id};
                _context.Insert(wordsCorrect);
                taskPairs.CorrectCombination = new List<TaskPairsCorrect> { wordsCorrect };

                TaskPairsEnglish a = new TaskPairsEnglish { Word = "Cat", TaskId = taskPairs.Id };
                TaskPairsEnglish b = new TaskPairsEnglish { Word = "Dog", TaskId = taskPairs.Id };
                TaskPairsEnglish c = new TaskPairsEnglish { Word = "Horse", TaskId = taskPairs.Id };
                TaskPairsEnglish d = new TaskPairsEnglish { Word = "Rabbit", TaskId = taskPairs.Id };
                TaskPairsEnglish e = new TaskPairsEnglish { Word = "Mouse", TaskId = taskPairs.Id };

                List<TaskPairsEnglish> taskPairsEnglish = new List<TaskPairsEnglish>
                {
                    a,b,c, d,e
                };
                _context.InsertAll(taskPairsEnglish);
                taskPairs.EWords = taskPairsEnglish;

                TaskPairsRussian f = new TaskPairsRussian { Word = "Собака", TaskId = taskPairs.Id };
                TaskPairsRussian g = new TaskPairsRussian { Word = "Кот", TaskId = taskPairs.Id };
                TaskPairsRussian h = new TaskPairsRussian { Word = "Заяц", TaskId = taskPairs.Id };
                TaskPairsRussian i = new TaskPairsRussian { Word = "Лошадь", TaskId = taskPairs.Id };
                TaskPairsRussian j = new TaskPairsRussian { Word = "Мышь", TaskId = taskPairs.Id };

                List<TaskPairsRussian> taskPairsRussian = new List<TaskPairsRussian>
                {
                    f,g,h,i,j
                };
                _context.InsertAll(taskPairsRussian);
                taskPairs.RWords = taskPairsRussian;
                _context.UpdateWithChildren(taskPairs);               

                User admin = new User { Name = "Kactus", Password = "111", ActiveKurseId = 1 };
                _context.Insert(admin);
                Kurses gojoKurse = new Kurses { Author = "Оксана Долина", UserId = admin.Id, Description = "Курс по английскому языку для новичков предоставляет компактное и простое введение в основы английской лексики.", LessonsCount = 3, Name = "Слова для новичков", ImageUrl = "kurs1.jpg" };
                Kurses mikuKurse = new Kurses { Author = "Мэйхэм", UserId = admin.Id, Description = "В рамках курса студенты получат инсайты и стратегии, необходимые для успешного изучения и уверенного владения английским.", LessonsCount = 2, Name = "Как учить язык", ImageUrl = "kurs2.jpg" };
                _context.Insert(gojoKurse);
                _context.Insert(mikuKurse);
                Vocabulary first = new Vocabulary { FirstWord = "Dog", SecondWord = "Собака", UserId = admin.Id };
                Vocabulary second = new Vocabulary { FirstWord = "Cat", SecondWord = "Кот", UserId = admin.Id };
                _context.Insert(first);
                _context.Insert(second);
                Lessons lesson1 = new Lessons { Name = "Основы словарного запаса: Начальные слова и фразы", VideoUrl = "kurs1-1.mp4", Description = "Стартовый словарь", Text = "Добро пожаловать в наш урок! Сегодня мы начнем с самых основ. Вы изучите простые и полезные слова, которые помогут вам в повседневном общении на английском языке.\n Давайте начнем с приветствий, цифр, основных предметов и фраз для общения. Этот стартовый словарь станет вашим надежным партнером в первых шагах в изучении английского!", KursId = gojoKurse.Id };
                Lessons lesson2 = new Lessons { Name = "Введение в Язык: Первые шаги в Английском", VideoUrl = "kurs1-2.mp4", Description = "Языковое введение", Text= "Приветствуем вас на первом этапе вашего языкового путешествия! В этом уроке мы обзорно поговорим о базовых навыках, которые вам пригодятся в изучении английского языка.\n Мы рассмотрим основные грамматические правила, простые фразы для общения и узнаем, как правильно строить предложения. Готовы начать первые шаги в английском?", KursId = gojoKurse.Id };
                Lessons lesson25 = new Lessons { Name = "Слова для Новичков: Основы Английской Лексики", VideoUrl = "kurs1-3.mp4", Description = "Основы лексики", Text= "Давайте погрузимся в мир основ английской лексики! В этом уроке вы узнаете простые, но важные слова и выражения, которые помогут вам в различных ситуациях.\n Мы познакомимся с повседневными темами, такими как семья, дом, работа, и научимся описывать базовые предметы. Эти основы лексики станут крепким фундаментом для вашего дальнейшего изучения английского языка!", KursId = gojoKurse.Id };
                _context.Insert(lesson1);
                _context.Insert(lesson2);
                _context.Insert(lesson25);
                Lessons lesson3 = new Lessons { Name = "Путь к языковой грамотности", VideoUrl = "kurs2-1.mp4", Description = "Тайны изучения языка", KursId = mikuKurse.Id, Text= "Добро пожаловать на урок \"Путь к языковой грамотности\"! Здесь мы исследуем тайны успешного изучения английского языка.\n Вы узнаете, как построить правильные образовательные привычки, разработать мотивационный план и преодолеть возможные трудности в процессе обучения.\n Давайте вместе создадим стратегию, которая сделает ваше изучение английского удовлетворительным и результативным!" };
                Lessons lesson4 = new Lessons { Name = "Эффективные стратегии обучения", VideoUrl = "kurs2-2.mp4", Description = "Cтратегии и методы", KursId = mikuKurse.Id, Text= "Добро пожаловать на урок \"Мастерство в изучении английского\"! В этом уроке мы рассмотрим передовые стратегии обучения, которые сделают ваш путь к владению английским языком успешным и увлекательным. Вы узнаете, как эффективно управлять своим временем, применять индивидуальные методы обучения и использовать ресурсы для максимального освоения языка.\n Давайте вместе создадим персональный план обучения для достижения ваших языковых целей!" };
                _context.Insert(lesson3);
                _context.Insert(lesson4);
                gojoKurse.Lessons = new List<Lessons> { lesson1, lesson2, lesson25 };
                _context.UpdateWithChildren(gojoKurse);
                admin.UserKurses = new List<Kurses> { gojoKurse };
                admin.UserVocabulary = new List<Vocabulary> { first, second };
                _context.UpdateWithChildren(admin);
            }
        }

        public TaskTranslate GetTaskTranslate(int TaskNumber)
        {
            return _context.GetWithChildren<TaskTranslate>(TaskNumber);
        }

        public TaskComplete GetTaskComplete(int TaskNumber)
        {
            return _context.Get<TaskComplete>(TaskNumber);
        }

        public TaskPairs GetTaskPairs(int TaskNumber)
        {
            return _context.GetWithChildren<TaskPairs>(TaskNumber);
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

        public void AddVocabulary(User user, string secondWod, string firstWord)
        {
            Vocabulary voc = new Vocabulary { FirstWord = firstWord, SecondWord = secondWod, UserId = user.Id };
            user.UserVocabulary.Add(voc);
            _context.Insert(voc);
            _context.Update(user);
        }

        public void DeleteVocabulary(User userId, int vocId)
        {
            User user = _context.GetWithChildren<User>(userId.Id);
            Vocabulary voc = user.UserVocabulary.FirstOrDefault(x => x.Id == vocId);
            user.UserVocabulary.Remove(voc);
            _context.Delete(voc);
            _context.UpdateWithChildren(user);
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
