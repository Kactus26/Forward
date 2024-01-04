using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Forward4.Data;
using Forward4.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forward4.ViewModel
{
    public partial class TasksViewModel : ObservableObject
    {
        [RelayCommand]
        public async Task ToAllTasks()
        {
            await NavigationService.GetNavigation2().PushAsync(new TaskAll(), true);
        }
        [RelayCommand]
        public async Task ToPairs()
        {
            await NavigationService.GetNavigation2().PushAsync(new TaskPairs(), true);
        }
        [RelayCommand]
        public async Task ToComplete()
        {
            await NavigationService.GetNavigation2().PushAsync(new TaskComplete(), true);
        }
        [RelayCommand]
        public async Task ToTranslate()
        {
            await NavigationService.GetNavigation2().PushAsync(new TaskTranslate(), true);
        }
    }
}
