using Forward4.Data;
using Forward4.ViewModel;

namespace Forward4.View;

public partial class Video : ContentPage
{
	public Video()
	{
		InitializeComponent();
		BindingContext = new VideoViewModel(new DataContext());
	}
}