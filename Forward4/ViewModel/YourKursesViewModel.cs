using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Forward4.Data;
using Forward4.Model;
using Forward4.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forward4.ViewModel
{
    public partial class YourKursesViewModel : ObservableObject
    {
        [ObservableProperty]
        public List<Kurses> userKurses;
        [ObservableProperty]
        public Kurses selectedKurs;

        [RelayCommand]
        public async void SelectionMade()
        {
            int userId = _context.GetActiveUser();
            _context.AddKursToUser(SelectedKurs, userId);
            await NavigationService.GetNavigation().PushAsync(new KursLessons(), true);
        }

        public void Init()
        {
            int userId = _context.GetActiveUser();
            UserKurses = _context.GetUserKurses(userId);
        }

        public DataContext _context;
        public YourKursesViewModel(DataContext db)
        {
            _context = db;
            Init();
        }
    }
}