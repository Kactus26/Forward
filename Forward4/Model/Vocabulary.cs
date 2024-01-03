using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forward4.Model
{
    public class Vocabulary
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FirstWord {  get; set; }
        public string SecondWord { get; set; }
        [ForeignKey(typeof(User))]
        public int UserId { get; set; }
    }
}
