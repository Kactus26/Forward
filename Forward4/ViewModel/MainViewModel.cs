using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Forward4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forward4.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        public string text;

        [RelayCommand]
        public async void Test()
        {
            var lol = await _context.GetActiveUser();
            var test = await _context.GetUserById(lol.UserId);
            Text = test.Name;
        }

        private DataContext _context;
        public MainViewModel(DataContext db)
        {
            _context = db;
        }
    }
}
