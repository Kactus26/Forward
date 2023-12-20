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
        private DataContext _context;
        
        [ObservableProperty]
        private string text;

        public EntranceViewModel(DataContext db)
        {
            _context = db;
        }

        [RelayCommand]
        public async Task YuraDoebalsya()
        {
            await _context.Add("Sasha");
            var a = await _context.Read();
            Text = a.Name;
        }


        [RelayCommand]
        public async Task ToRegistrationPage()
        {
            await NavigationService.GetNavigation().PushAsync(new Registration(), true);
        }
        [RelayCommand]
        public async Task ToLoginPage()
        {
            await NavigationService.GetNavigation().PushAsync(new Login(), true);
        }
    }
}
