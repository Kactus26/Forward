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
    public partial class TaskAllViewModel : ObservableObject
    {
        [ObservableProperty]
        public int iter;
        [ObservableProperty]
        public bool firstTask = false;
        [ObservableProperty]
        public bool secondTask = false;
        [ObservableProperty]
        public bool thirdTask = false;
        private User User { get; set; }

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

        [RelayCommand]
        public async void Return()
        {
            Iter++;
            SelectedAnswear = null;
            FirstTask = false;
            ButtonVisible = false;
            Init();
        }

        [RelayCommand]
        public async void NewAnswear()
        {
            if (SelectedAnswear == null)
                return;
            if (SelectedAnswear == CorrectAnswear)
            {
                ButtonText = "Победа!!!!!";
                User.SuccessfulCompletedTasks++;
                _context.UpdateUser(User);
            }
            else
            {
                ButtonText = "Поражение!!!!!";
                await NavigationService.GetNavigation2().PopAsync();
            }
            ButtonVisible = true;
        }



        [ObservableProperty]
        public string sentance;
        [ObservableProperty]
        public string buttonText2 = "Проверить";
        [ObservableProperty]
        public string text2 = "";
        [ObservableProperty]
        public TranslationWords word;
        [ObservableProperty]
        public List<TranslationWords> words;
        private string Correct { get; set; }
        private int TaskNumber2 { get; set; } = 1;

        [RelayCommand]
        public void SelectionChanged()
        {
            Text2 += Word.Word;
            Text2 += ' ';
        }

        [RelayCommand]
        public async Task Check()
        {
            Text2 = Text2.Trim();
            if (ButtonText2 == "Вы великолепны!")
            {
                Iter++;
                Text2 = "";
                SecondTask = false;
                Init();
                return;
            }

            if (Text2 == Correct)
            {
                User.SuccessfulCompletedTasks++;
                _context.UpdateUser(User);
                ButtonText2 = "Вы великолепны!";
            }
            else
            {
                Text2 = "";
                ButtonText2 = "Что-то не то...";
                Word = null;
            }
        }




        [ObservableProperty]
        public int mistakes = 0;
        [ObservableProperty]
        public string text3 = "Проверить";
        [ObservableProperty]
        public TaskPairsEnglish english;
        [ObservableProperty]
        public TaskPairsRussian russian;
        [ObservableProperty]
        public List<TaskPairsEnglish> firstCollection;
        [ObservableProperty]
        public List<TaskPairsRussian> secondCollection;
        public TaskPairsCorrect Correct2 { get; set; }
        public int TaskNumber3 { get; set; } = 1;

        [RelayCommand]
        public async Task Check2(){
            if (Mistakes == 3)
            {
                await NavigationService.GetNavigation2().PopAsync();
            }
            if (English == null || Russian == null)
                return;
            if (English.Word == Correct2.EWord1 && Russian.Word == Correct2.RWord1)
                CorrectAnswer();
            else if (English.Word == Correct2.EWord2 && Russian.Word == Correct2.RWord2)
                CorrectAnswer();
            else if (English.Word == Correct2.EWord3 && Russian.Word == Correct2.RWord3)
                CorrectAnswer();
            else if (English.Word == Correct2.EWord4 && Russian.Word == Correct2.RWord4)
                CorrectAnswer();
            else if (English.Word == Correct2.EWord5 && Russian.Word == Correct2.RWord5)
                CorrectAnswer();
            else
            {
                if (Mistakes == 2)
                    Text3 = "Вы проиграли(((";
                Mistakes++;
            }
        }

        private void CorrectAnswer()
        {
            if (FirstCollection.Count == 1)
            {
                User.SuccessfulCompletedTasks++;
                _context.UpdateUser(User);
                Text3 = "Победа;)";
                Iter++;
                ThirdTask = false;
                Init();
                return;
            }

            int delInd = FirstCollection.FindIndex(x => x.Word == English.Word); //После Remove отображение ломалось
            List<TaskPairsEnglish> temp1 = new List<TaskPairsEnglish>();
            for (int i = 0; i < FirstCollection.Count; i++)
            {
                if (i == delInd)
                    continue;
                TaskPairsEnglish tmp1 = FirstCollection[i];
                temp1.Add(tmp1);
            }
            FirstCollection = temp1;

            delInd = SecondCollection.FindIndex(x => x.Word == Russian.Word);
            List<TaskPairsRussian> temp2 = new List<TaskPairsRussian>();
            for (int i = 0; i < SecondCollection.Count; i++)
            {
                if (i == delInd)
                    continue;
                TaskPairsRussian tmp2 = SecondCollection[i];
                temp2.Add(tmp2);
            }
            SecondCollection = temp2;
        }





        private void Init()
        {
            User = _context.GetUser();
            Random rnd = new Random();
            int choseTask = rnd.Next(1,4);
            if(choseTask == 1)
            {
                FirstTask = true;
                ButtonVisible = false;
                TaskComplete task = _context.GetTaskComplete(TaskNumber);
                Text = task.Sentence;
                CorrectAnswear = task.CorrectAnswear;
                Answears = new List<string>();
                Answears.Add(task.Answear1); Answears.Add(task.Answear2); Answears.Add(task.Answear3); Answears.Add(task.Answear4);
            } else if(choseTask == 2)
            {
                SecondTask = true;
                TaskTranslate task = _context.GetTaskTranslate(TaskNumber2);
                Sentance = task.Sentance;
                Words = task.Words;
                Correct = task.CorrectSentance;
                ButtonText2 = "Проверить";
            }
            else
            {
                ThirdTask = true;
                var task = _context.GetTaskPairs(TaskNumber);
                FirstCollection = task.EWords;
                SecondCollection = task.RWords;
                Correct2 = task.CorrectCombination[0];
                Text3 = "Проверить";
                Mistakes = 0;
            }
        }

        DataContext _context;
        public TaskAllViewModel(DataContext db)
        {
            _context = db;
            Init();
        }
    }
}
