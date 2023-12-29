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
    public partial class AllKursesViewModel : ObservableObject
    {
        [ObservableProperty]
        public List<Kurses> allKurses;
        [ObservableProperty]
        public Kurses selectedKurs;


        [RelayCommand]
        public async Task SelectionMade()
        {
            await _context.GetActiveUser();
/*            await _context.AddKursToUser(selectedKurs);
*/            await NavigationService.GetNavigation().PushAsync(new KursLessons(), true);
        }

        public async Task Init()
        {
            AllKurses = await _context.GetAllKurses();
        }

        public DataContext _context;
        public AllKursesViewModel(DataContext db)
        {
            _context = db;
            Init();
        }
    }
}
