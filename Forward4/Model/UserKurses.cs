using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forward4.Model
{
    public class UserKurses
    {
        [ForeignKey(typeof(User))]
        public int UserId { get; set; }

        [ForeignKey(typeof(Kurses))]
        public int KurseId { get; set; }
    }
}
