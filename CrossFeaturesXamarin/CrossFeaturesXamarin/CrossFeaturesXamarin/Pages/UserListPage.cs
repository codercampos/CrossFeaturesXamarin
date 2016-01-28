using CrossFeaturesXamarin.Pages.ViewCells;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Threading.Tasks;
using CrossFeaturesXamarin.Models;
using CrossFeaturesXamarin.Services;

namespace CrossFeaturesXamarin.Pages
{
    public class UserListPage : ContentPage
    {
        private readonly ListView _lstView;
        private readonly ObservableCollection<User> _collection;
        public UserListPage()
        {
            Title = "Demo";
            BackgroundColor = Color.White;
            _collection = new ObservableCollection<User>();

            var layout = new StackLayout
            {
                Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            _lstView = new ListView
            {
                HasUnevenRows = true,
                ItemTemplate = new DataTemplate(typeof (UserViewCell)),
                ItemsSource = _collection,
                HeightRequest = 300,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            _lstView.ItemSelected += SelectedItem;

            layout.Children.Add(_lstView);
            Content = layout;

            //Retrieve data from server
            RetrieveData();

        }

        private async void RetrieveData()
        {
            var parse = DependencyService.Get<IParseService>();
            var users = await parse.GetUsers();
            if (users != null)
                foreach (var item in users)
                {
                    _collection.Add(item);
                    await Task.Delay(1000);
                }
        }

        private void SelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;
            var model = e.SelectedItem as User;
            if (model == null) return;
            var message = string.Format("You have selected {0} user", model.Name);
            DisplayAlert("Selected", message, "Ok");
            _lstView.SelectedItem = null;
        }
    }
}
