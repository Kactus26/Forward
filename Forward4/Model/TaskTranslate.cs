using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forward4.Model
{
    public class TaskTranslate
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Sentance { get; set; }
        public string CorrectSentance { get; set; }

        [OneToMany]
        public List<TranslationWords> Words { get; set; }

    }
}
