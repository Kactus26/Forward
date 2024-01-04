using Forward4.Data;
using Forward4.ViewModel;

namespace Forward4.View;

public partial class Main : ContentPage
{
	public Main()
	{
		InitializeComponent();
		BindingContext = new MainViewModel();
    }
}