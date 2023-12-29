using Forward4.Data;
using Forward4.ViewModel;

namespace Forward4.View;

public partial class KursLessons : ContentPage
{
	public KursLessons()
	{
		InitializeComponent();
		BindingContext = new KursLessonsViewModel(new DataContext());
	}
}