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
        public bool visability;
        [ObservableProperty]
        public List<Lessons> kursLessons;
        [ObservableProperty]
        public string imageUrl;
        [ObservableProperty]
        public Lessons selectedLessons;
        public int KursId {  get; set; }

        [RelayCommand]
        public async void Delete()
        {
            User user = _context.GetUser();
            _context.DeleteKurs(user, KursId);
            await NavigationService.GetNavigation().PushAsync(new Main(), true);
        }

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
                KursId = user.ActiveKurseId;
                Visability = false;
            } else
                Visability = true;
        }

        private DataContext _context;
        public KursLessonsViewModel(DataContext db)
        {
            _context = db;
            Init();
        }
    }
}
