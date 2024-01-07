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
    public partial class TaskTranslateViewModel : ObservableObject
    {
        [ObservableProperty]
        public string sentance;
        [ObservableProperty]
        public string buttonText = "Проверить";
        [ObservableProperty]
        public string text = "";
        [ObservableProperty]
        public int mistakes;
        [ObservableProperty]
        public TranslationWords word;
        [ObservableProperty]
        public List<TranslationWords> words;
        private string Correct {  get; set; }
        private int Task { get; set; } = 1;
        private User User { get; set; }
        

        [RelayCommand]
        public void SelectionChanged()
        {
            Text += Word.Word;
            Text += ' ';
        }

        [RelayCommand]
        public async void Check()
        {
            Text = Text.Trim();
            if (ButtonText == "Вы великолепны!")
            {
                User.SuccessfulCompletedTasks++;
                _context.UpdateUser(User);
                await NavigationService.GetNavigation2().PopAsync();
            }

            if (Text == Correct)
                ButtonText = "Вы великолепны!";
            else
            {
                if(Mistakes == 3) 
                {
                    User.WrongCompletedTasks++;
                    _context.UpdateUser(User);
                    await NavigationService.GetNavigation2().PopAsync();
                }
                Mistakes++;
                Text = "";
                if (Mistakes == 3)
                    ButtonText = "Вы проиграли(";
                else
                    ButtonText = "Ошибка!";
            }
        }

        private void Init()
        {
            User = _context.GetUser();
            TaskTranslate task = _context.GetTaskTranslate(Task);
            Sentance = task.Sentance;
            Words = task.Words;
            Correct = task.CorrectSentance;
            ButtonText = "Проверить";
        }

        private DataContext _context;
        public TaskTranslateViewModel(DataContext db)
        {
            _context = db;
            Init();
        }
    }
}
