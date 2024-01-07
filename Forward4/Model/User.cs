using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forward4.Model
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int SuccessfulCompletedTasks { get; set; } = 0;
        public int WrongCompletedTasks { get; set; } = 0;
        [OneToMany]
        public List<Kurses> UserKurses { get; set; }
        [OneToMany]
        public List<Vocabulary> UserVocabulary { get; set; }
        public int ActiveKurseId { get; set; }
        public int NextLessonId { get; set; }
    }
}
