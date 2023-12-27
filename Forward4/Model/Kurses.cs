using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forward4.Model
{
    public class Kurses
    {
        [PrimaryKey, AutoIncrement]
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int LessonsCount { get; set; }
        public string ImageUrl {  get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Lessons> Lessons { get; set; } = new List<Lessons>();
    }
}
