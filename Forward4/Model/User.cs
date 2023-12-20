using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forward4.Model
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
