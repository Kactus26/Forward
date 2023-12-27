﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Forward4.Data;
using Forward4.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forward4.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {

        [RelayCommand]
        public async void ToAllKursesPage()
        {
            await NavigationService.GetNavigation().PushAsync(new AllKurses(), true);
        }

        private DataContext _context;
        public MainViewModel(DataContext db)
        {
            _context = db;
        }
    }
}
