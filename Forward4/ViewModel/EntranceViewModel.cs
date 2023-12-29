using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Forward4.Data;
using Forward4.View;
using Microsoft.Extensions.DependencyInjection;

namespace Forward4.ViewModel
{
    public partial class EntranceViewModel : ObservableObject
    {
        [RelayCommand]
        public async Task ToRegistrationPage()
        {
            await NavigationService.GetNavigation().PushAsync(new Registration(), true);
        }
        [RelayCommand]
        public async Task ToLoginPage()
        {
            if (_context.CheckActiveUserExists())
                await NavigationService.GetNavigation().PushAsync(new Main(), true);
            else
                await NavigationService.GetNavigation().PushAsync(new Login(), true);
        }

        private DataContext _context;
        public EntranceViewModel(DataContext db)
        {
            _context = db;
        }
    }
}
