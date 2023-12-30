using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Forward4.Data;
using Forward4.Model;
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
