using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forward4.Model
{
    public class ActiveUser
    {
        public User activeUser { get; set; }
        public ActiveUser(User user) 
        {
            activeUser = user;
        }
    }
}
