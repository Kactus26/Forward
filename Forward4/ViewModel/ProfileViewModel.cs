using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Forward4.Data;
using Forward4.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forward4.ViewModel
{
    public partial class ProfileViewModel : ObservableObject
    {
        public int ActiveUserId;
        [ObservableProperty]
        public int kursCount;
        [ObservableProperty]
        public int successfulTasksCount;
        [ObservableProperty]
        public int unsuccessfulTasksCount;
        [ObservableProperty]
        public string userName;

        [RelayCommand]
        public void Update()
        {
            Init();
        }

        public void Init()
        {
            User user = _context.GetUser();
            UserName = user.Name;
            SuccessfulTasksCount = user.SuccessfulCompletedTasks;
            KursCount = user.UserKurses.Count;
            UnsuccessfulTasksCount = user.WrongCompletedTasks;
        }

        private DataContext _context;
        public ProfileViewModel(DataContext db)
        {
            _context = db;
            Init();
        }
    }
}
