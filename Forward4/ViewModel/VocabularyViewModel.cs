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
    public partial class VocabularyViewModel : ObservableObject
    {
        [ObservableProperty]
        public List<Vocabulary> vocabulary;
        [ObservableProperty]
        public Vocabulary selectedVocabulary;
        [ObservableProperty]
        public string text = "Введите слово";
        public string FirstWord { get; set; }

        [RelayCommand]
        public void Add()
        {
            if(FirstWord == null)
            {
                FirstWord = Text;
                Text = "Введите перевод";
            }
            else
            {
                User user = _context.GetUser();
                _context.AddVocabulary(user, Text, FirstWord);
                FirstWord = null;
                Text = "Введите слово";
                Init();
            }
        }

        [RelayCommand]
        public void Delete()
        {
            if (SelectedVocabulary != null)
            {
                User user = _context.GetUser();
                _context.DeleteVocabulary(user, SelectedVocabulary.Id);
                SelectedVocabulary = null;
                Init();
            }
        }

        public void Init()
        {
            int userId = _context.GetActiveUser();
            Vocabulary = _context.GetVocabularies(userId);
        }

        private DataContext _context;
        public VocabularyViewModel(DataContext db)
        {
            _context = db;
            Init();
        }
    }
}
