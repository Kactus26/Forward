using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forward4.Model
{
    public class TranslationWords
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Word { get; set; }
        [ForeignKey(typeof(TaskTranslate))]
        public int TaskId { get; set; }
    }
}
