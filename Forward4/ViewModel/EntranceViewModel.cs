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
        DataContext dataContext { get; set; }
        [ObservableProperty]
        private string text;

        [RelayCommand]
        public async Task YuraDoebalsya()
        {
            text = dataContext.Users.FirstOrDefault()?.Name;
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

        public EntranceViewModel()
        {
            var dataContext = Singletone.GetContext();
            this.dataContext = dataContext;
        }
    }
}
