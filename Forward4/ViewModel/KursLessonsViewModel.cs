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
    public partial class KursLessonsViewModel : ObservableObject
    {
        [ObservableProperty]
        public string text = "Пока у вас нет активных курсов";
        [ObservableProperty]
        public List<Lessons> kursLessons;
        [ObservableProperty]
        public string imageUrl;
        [ObservableProperty]
        public Lessons selectedLessons;

        [RelayCommand]
        public async void SelectionMade()
        {
            User user = _context.GetUser();
            user.NextLessonId = SelectedLessons.Id;
            _context.UpdateUser(user);
            await NavigationService.GetNavigation().PushAsync(new Video(), true);
        }

        public void Init()
        {
            User user = _context.GetUser();
            if (user.ActiveKurseId != 0)
            {
                Kurses kurs = _context.GetKurs(user.ActiveKurseId);
                KursLessons = kurs.Lessons;
                Text = kurs.Description;
                ImageUrl = kurs.ImageUrl;
            }
        }

        private DataContext _context;
        public KursLessonsViewModel(DataContext db)
        {
            _context = db;
            Init();
        }
    }
}
