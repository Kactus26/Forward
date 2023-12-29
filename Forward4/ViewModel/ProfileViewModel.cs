using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Forward4.Data;
using Forward4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forward4.ViewModel
{
    public partial class ProfileViewModel : ObservableObject
    {
        public int ActiveUserId;

        [ObservableProperty]
        public string userName;

        public void GetUserName()
        {
            int ActiveUserId = _context.GetActiveUser();
            User user = _context.GetUserById(ActiveUserId);
            UserName = user.Name;
        }

        private DataContext _context;
        public ProfileViewModel(DataContext db)
        {
            _context = db;
            GetUserName();
        }
    }
}
