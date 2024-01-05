using Forward4.Data;
using Forward4.ViewModel;

namespace Forward4.View;

public partial class TaskComplete : ContentPage
{
	public TaskComplete()
	{
		InitializeComponent();
		BindingContext = new TaskCompleteViewModel(new DataContext());
	}
}