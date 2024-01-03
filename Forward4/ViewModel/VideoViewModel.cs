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
    public partial class VideoViewModel : ObservableObject
    {
        [ObservableProperty]
        public string lessonName = "У вас нет выбранного урока";
        [ObservableProperty]
        public string text;
        [ObservableProperty]
        public string videoUrl;

        public void Init()
        {
            User user = _context.GetUser();
            Lessons lesson = _context.GetLesson(user.NextLessonId);
            if (lesson != null)
            {
                Text = lesson.Text;
                LessonName = lesson.Name;
                VideoUrl = lesson.VideoUrl;
            }
        }
        
        private DataContext _context;
        public VideoViewModel(DataContext db)
        {
            _context = db;
            Init();
        }
    }
}
