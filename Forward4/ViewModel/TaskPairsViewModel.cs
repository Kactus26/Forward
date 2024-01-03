using CommunityToolkit.Mvvm.ComponentModel;
using Forward4.Data;
using Forward4.View;

namespace Forward4.ViewModel
{
    public partial class TaskPairsViewModel : ObservableObject
    {
        [ObservableProperty]
        public List<TaskPairs> firstCollection;
        [ObservableProperty]
        public List<TaskPairs> secondCollection;

        public void Init()
        {
            var test = _context.GetTaskPairs();
        }


        private DataContext _context;
        public TaskPairsViewModel(DataContext db)
        {
            _context = db;
            Init();
        }
    }
}
