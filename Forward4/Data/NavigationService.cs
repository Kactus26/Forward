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
        public static INavigation _navigation2;

        public static INavigation GetNavigation()
        {
            return _navigation;
        }
        public static INavigation GetNavigation2()
        {
            return _navigation2;
        }
        public static void AddNavigation(INavigation navigation)
        {
            _navigation = navigation;
        }
        public static void AddNavigation2(INavigation navigation)
        {
            _navigation2 = navigation;
        }
    }
}
