using Forward4.Data;
using Forward4.ViewModel;

namespace Forward4.View;

public partial class TaskAll : ContentPage
{
	public TaskAll()
	{
		InitializeComponent();
		BindingContext = new TaskAllViewModel(new DataContext());
	}
}