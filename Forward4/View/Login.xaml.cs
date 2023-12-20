using Forward4.Data;
using Forward4.ViewModel;

namespace Forward4.View;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
        BindingContext = new LoginViewModel(new DataContext());
    }
}