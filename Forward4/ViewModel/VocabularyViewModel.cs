using CommunityToolkit.Mvvm.ComponentModel;
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
