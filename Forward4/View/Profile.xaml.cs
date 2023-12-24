using Forward4.Data;
using Forward4.ViewModel;

namespace Forward4.View;

public partial class Profile : ContentPage
{
	public Profile()
	{
		InitializeComponent();
		BindingContext = new ProfileViewModel(new DataContext());
	}
}