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
        public static INavigation _navigation;
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

        public static INavigation GetNavigation()
        { 
            return _navigation;
        }

        public static void AddNavigation(INavigation navigation)
        {
            _navigation = navigation;
        }
    }
}
