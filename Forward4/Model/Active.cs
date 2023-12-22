using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forward4.Model
{
    public class Active
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
