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

namespace Forward4.ViewModel
{
    public partial class EntranceViewModel : ObservableObject
    {
        [ObservableProperty]
        private string text= "Hello!!!!!!!!111";

        [RelayCommand]
        public async void NewText()
        {
            await NavigationService.GetNavigation().PushAsync(new Registration(), true);
            /*INavigation navigation = Singletone.GetNavigation();
            navigation.PushAsync(new Registration(), true);*/
        }
    }
}
