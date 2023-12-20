using Forward4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forward4.Data
{
    static public class Seed
    {
        static async public void Seeding(DataContext dataContext)
        {
            User user = new User()
            {
                Name = "Sasha"
            };
            await dataContext.SaveChangesAsync();
        }
    }
}
