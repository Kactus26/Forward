using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forward4.Data
{
    class Singletone
    {
        private static Singletone _singletone;
        public static DataContext _context;
        private Singletone()
        {
    
        }

        public static Singletone GetSingletone()
        {
            if (_singletone == null)
            {
                _singletone = new Singletone();
            }
            return _singletone;
        }

        public static DataContext GetContext()
        { 
            return _context;
        }

        public static void AddContext(DataContext context)
        {
            _context = context;
        }
    }
}
