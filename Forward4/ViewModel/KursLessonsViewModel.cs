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
        public string text;
        [ObservableProperty]
        public List<Lessons> kursLessons;


        public void Init()
        {
            User user = _context.GetUser();
            KursLessons = _context.GetKursLessons(user.ActiveKurseId);
        }

        private DataContext _context;
        public KursLessonsViewModel(DataContext db)
        {
            _context = db;
            Init();
        }
    }
}
