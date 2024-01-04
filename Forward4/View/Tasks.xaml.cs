using Forward4.Data;
using Forward4.ViewModel;

namespace Forward4.View;

public partial class Tasks : ContentPage
{
	public Tasks()
	{
		InitializeComponent();
		BindingContext = new TasksViewModel();
        NavigationService.AddNavigation2(Navigation);
    }
}