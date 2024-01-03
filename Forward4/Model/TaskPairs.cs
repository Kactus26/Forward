using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forward4.Model
{
    public class TaskPairs
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [OneToMany]
        public List<TaskPairsWords> Words { get; set; }
        [OneToMany]
        public List<TaskPairsCorrect> CorrectCombination { get; set; }
    }
}
