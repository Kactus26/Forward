using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Forward4.Data;
using Forward4.Model;
using Forward4.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forward4.ViewModel
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        private string name = "";
        [ObservableProperty]
        private string password = "";
        [ObservableProperty]
        private string errorMessage = "";

        [RelayCommand]
        public async void Login()
        {
            if(await _context.CheckUsersExists(Name))
            {
                User user = await _context.GetUserByName(Name);
                if (Password == user.Password)
                {
                    await _context.NewActiveUser(user.Id);                    
                    await NavigationService.GetNavigation().PushAsync(new Main(), true);
                }
                else ErrorMessage = "Пароль не верен";

            } else ErrorMessage = "Пользователя с таким именем не существует";
        }

        private DataContext _context;
        public LoginViewModel(DataContext db)
        {
            _context = db;
        }
    }
}
