using Forward4.Data;
using Forward4.ViewModel;

namespace Forward4.View;

public partial class TaskTranslate : ContentPage
{
	public TaskTranslate()
	{
		InitializeComponent();
		BindingContext = new TaskTranslateViewModel(new DataContext());
	}
}