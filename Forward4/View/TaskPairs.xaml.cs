using Forward4.Data;
using Forward4.ViewModel;

namespace Forward4.View;

public partial class TaskPairs : ContentPage
{
	public TaskPairs()
	{
		InitializeComponent();
		BindingContext = new TaskPairsViewModel(new DataContext());
	}
}