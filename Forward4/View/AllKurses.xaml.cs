using Forward4.Data;
using Forward4.Model;
using Forward4.ViewModel;

namespace Forward4.View;

public partial class AllKurses : ContentPage
{
	public AllKurses()
	{
		InitializeComponent();
		BindingContext = new AllKursesViewModel(new DataContext());
    }
}