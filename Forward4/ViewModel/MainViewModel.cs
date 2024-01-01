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
    public partial class MainViewModel : ObservableObject
    {
        [RelayCommand]
        public async void ToVideo()
        {
            await NavigationService.GetNavigation().PushAsync(new Video(), true);
        }

        [RelayCommand]
        public async void ToAllKursesPage()
        {
            await NavigationService.GetNavigation().PushAsync(new AllKurses(), true);
        }

        [RelayCommand]
        public async void ToYourKursesPage()
        {
            await NavigationService.GetNavigation().PushAsync(new YourKurses(), true);
        }

        [RelayCommand]
        public async void ToKursesLessonPage()
        {
            await NavigationService.GetNavigation().PushAsync(new KursLessons(), true);
        }

        private DataContext _context;
        public MainViewModel(DataContext db)
        {
            _context = db;
        }
    }
}
