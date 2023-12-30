using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Forward4.Model
{
    public class Active
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(User))]
        public int UserId { get; set; }
    }
}
