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
    public partial class RegistrationViewModel : ObservableObject
    {
        [ObservableProperty]
        private string name = "";
        [ObservableProperty]
        private string password = "";
        [ObservableProperty]
        private string checkPassword = "";
        [ObservableProperty]
        private string errorMessage;

        [RelayCommand]
        public async void Register()
        {
            if (Name.Length < 3)
            {
                ErrorMessage = "Длина имени должна быть больше 2";
                return;
            }
            else if (_context.CheckUsersExists(Name))
            {
                ErrorMessage = "Пользователь с таким именем уже существует";
                return;
            }
            else if (Password.Length < 3)
            {
                ErrorMessage = "Длина пароля должна быть больше 2";
                return;
            }
            else if (Password != CheckPassword)
            {
                ErrorMessage = "Пароли не совпадают";
                return;
            }
            User user = new User { Name = Name, Password = Password };
            _context.RegisterUser(user);
            _context.NewActiveUser(user.Id);
            await NavigationService.GetNavigation().PushAsync(new Main(), true);
        }

        private DataContext _context;
        public RegistrationViewModel(DataContext db)
        {
            _context = db;
        }
    }
}
