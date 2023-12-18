using Forward4.Data;
using Forward4.ViewModel;

namespace Forward4.View
{
    public partial class Entrance : ContentPage
    {
        public Entrance()
        {
            InitializeComponent();
            BindingContext = new EntranceViewModel();
            NavigationService.AddNavigation(Navigation);
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            await Singletone.GetNavigation().PushAsync(new Registration(), true);
        }
    }

}
