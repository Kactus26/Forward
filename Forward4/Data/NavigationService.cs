using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forward4.Data
{
    class NavigationService
    {
        public static INavigation _navigation;
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
