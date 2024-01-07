using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Forward4.Data;
using Forward4.Model;
using Forward4.View;

namespace Forward4.ViewModel
{
    public partial class TaskPairsViewModel : ObservableObject
    {
        [ObservableProperty]
        public int mistakes = 0;
        [ObservableProperty]
        public string text = "Проверить";
        [ObservableProperty]
        public TaskPairsEnglish english;
        [ObservableProperty]
        public TaskPairsRussian russian;
        [ObservableProperty]
        public List<TaskPairsEnglish> firstCollection;
        [ObservableProperty]
        public List<TaskPairsRussian> secondCollection;
        public TaskPairsCorrect Correct { get; set; }
        private int TaskNumber { get; set; } = 1;
        private User User { get; set; }

        [RelayCommand]
        public async void Check()
        {
            if (FirstCollection.Count == 0)
            {
                User.SuccessfulCompletedTasks++;
                _context.UpdateUser(User);
                await NavigationService.GetNavigation2().PopAsync();
            }
            if (Mistakes == 3)
            {
                User.WrongCompletedTasks++;
                _context.UpdateUser(User);
                await NavigationService.GetNavigation2().PopAsync();
            }
            if (English == null || Russian == null)
                return;
            if (English.Word == Correct.EWord1 && Russian.Word == Correct.RWord1)
                CorrectAnswer();
            else if (English.Word == Correct.EWord2 && Russian.Word == Correct.RWord2)
                CorrectAnswer();
            else if (English.Word == Correct.EWord3 && Russian.Word == Correct.RWord3)
                CorrectAnswer();
            else if (English.Word == Correct.EWord4 && Russian.Word == Correct.RWord4)
                CorrectAnswer();
            else if (English.Word == Correct.EWord5 && Russian.Word == Correct.RWord5)
                CorrectAnswer();
            else
            {
                Mistakes++;
                if (Mistakes == 3)
                    Text = "Вы проиграли(((";
            }
        }

        private void CorrectAnswer()
        {
            if (FirstCollection.Count == 1)
                Text = "Победа;)";

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
            List<TaskPairsRussian>  temp2 = new List<TaskPairsRussian>();
            for (int i = 0; i < SecondCollection.Count; i++)
            {
                if (i == delInd)
                    continue;
                TaskPairsRussian tmp2 = SecondCollection[i];
                temp2.Add(tmp2);
            }
            SecondCollection = temp2;
        }


        public void Init()
        {
            User = _context.GetUser();
            var task = _context.GetTaskPairs(TaskNumber);
            FirstCollection = task.EWords;
            SecondCollection = task.RWords;
            Correct = task.CorrectCombination[0];
            Text = "Проверить";
            Mistakes = 0;
        }


        private DataContext _context;
        public TaskPairsViewModel(DataContext db)
        {
            _context = db;
            Init();
        }
    }
}
