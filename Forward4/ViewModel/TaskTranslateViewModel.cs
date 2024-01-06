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
        public string text;
        [ObservableProperty]
        public TranslationWords word;
        [ObservableProperty]
        public List<TranslationWords> words;
        private string Correct {  get; set; }
        private int Task { get; set; } = 1;

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
            if(ButtonText == "Вы великолепны!")
                await NavigationService.GetNavigation2().PopAsync();

            if (Text == Correct)
                ButtonText = "Вы великолепны!";
            else
            {
                Text = "";
                ButtonText = "Что-то не то...";
            }
        }

        private void Init()
        {
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
