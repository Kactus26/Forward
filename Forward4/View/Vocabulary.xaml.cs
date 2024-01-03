using Forward4.Data;
using Forward4.ViewModel;

namespace Forward4.View;

public partial class Vocabulary : ContentPage
{
	public Vocabulary()
	{
		InitializeComponent();
		BindingContext = new VocabularyViewModel(new DataContext());
	}
}