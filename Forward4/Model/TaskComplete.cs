using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forward4.Model
{
    public class TaskComplete
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Sentence { get; set; }
        public string Answear1 { get; set; }
        public string Answear2 { get; set; }
        public string Answear3 { get; set; }
        public string Answear4 { get; set; }
        public string CorrectAnswear { get; set; }
    }
}
