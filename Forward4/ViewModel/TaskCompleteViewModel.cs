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
    public partial class TaskCompleteViewModel : ObservableObject
    {
        [ObservableProperty]
        private string text;
        [ObservableProperty]
        private string buttonText;
        [ObservableProperty]
        private bool buttonVisible = false;
        [ObservableProperty]
        private string selectedAnswear;
        [ObservableProperty]
        private List<string> answears = new List<string>();
        private int TaskNumber { get; set; } = 1;
        private string CorrectAnswear { get; set; }
        private User User { get; set; }

        [RelayCommand]
        public async void Return()
        {
            await NavigationService.GetNavigation2().PopAsync();
        }

        [RelayCommand]
        public void NewAnswear()
        {
            if (SelectedAnswear == CorrectAnswear)
            {
                User.SuccessfulCompletedTasks++;
                _context.UpdateUser(User);
                ButtonText = "Победа!!!!!";
            }
            else
                ButtonText = "Поражение!!!!!";
            ButtonVisible = true;
        }

        private void Init()
        {
            User = _context.GetUser();
            ButtonVisible = false;
            TaskComplete task = _context.GetTaskComplete(TaskNumber);
            Text = task.Sentence;
            CorrectAnswear = task.CorrectAnswear;
            Answears.Add(task.Answear1); Answears.Add(task.Answear2); Answears.Add(task.Answear3); Answears.Add(task.Answear4);
        }

        private DataContext _context;
        public TaskCompleteViewModel(DataContext db)
        {
            _context = db;
            Init();
        }
    }
}
