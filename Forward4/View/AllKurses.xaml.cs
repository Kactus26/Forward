using Forward4.Data;
using Forward4.Model;
using Forward4.ViewModel;

namespace Forward4.View;

public partial class AllKurses : ContentPage
{
	public AllKurses()
	{
		InitializeComponent();
/*		collectionView.ItemsSource = GetKurses();	
*/      
		BindingContext = new AllKursesViewModel(new DataContext());
    }

    private List<Kurses> GetKurses()
	{
		return new List<Kurses> 
		{ 
			new Kurses { Name = "Test", Author = "Kactus", Description = "Help me pls"  }
		};
	}

}