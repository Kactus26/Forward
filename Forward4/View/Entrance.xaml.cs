using Forward4.Data;
using Forward4.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace Forward4.View
{
    public partial class Entrance : ContentPage
    {
        public Entrance()
        {
            InitializeComponent();

            BindingContext = new EntranceViewModel(new DataContext());
            NavigationService.AddNavigation(Navigation);
        }
    }
}
