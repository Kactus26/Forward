using Forward4.Data;
using Forward4.ViewModel;

namespace Forward4.View;

public partial class YourKurses : ContentPage
{
	public YourKurses()
	{
		InitializeComponent();
        BindingContext = new YourKursesViewModel(new DataContext());
    }
}