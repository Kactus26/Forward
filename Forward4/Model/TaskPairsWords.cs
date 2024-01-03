using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forward4.Model
{
    public class TaskPairsWords
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string EWord1 { get; set; }
        public string EWord2 { get; set; }
        public string EWord3 { get; set; }
        public string EWord4 { get; set; }
        public string EWord5 { get; set; }
        public string RWord1 { get; set; }
        public string RWord2 { get; set; }
        public string RWord3 { get; set; }
        public string RWord4 { get; set; }
        public string RWord5 { get; set; }

        [ForeignKey(typeof(TaskPairs))]
        public int TaskId { get; set; }
    }
}
