using Forward4.Data;
using Forward4.ViewModel;

namespace Forward4.View
{

    public partial class Registration : ContentPage
    {
        public Registration()
        {
            InitializeComponent();
            BindingContext = new RegistrationViewModel(new DataContext());

        }
    }
}