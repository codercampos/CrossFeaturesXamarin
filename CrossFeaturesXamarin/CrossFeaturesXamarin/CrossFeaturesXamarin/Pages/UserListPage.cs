using CrossFeaturesXamarin.Pages.ViewCells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using CrossFeaturesXamarin.Services;

namespace CrossFeaturesXamarin.Pages
{
    public class UserListPage : ContentPage
    {
        ListView lstView;
        public UserListPage()
        {
            StackLayout layout = new StackLayout();
            layout.Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
            layout.HorizontalOptions = LayoutOptions.FillAndExpand;
            layout.VerticalOptions = LayoutOptions.FillAndExpand;
            lstView = new ListView();
            lstView.HasUnevenRows = true;
            lstView.ItemTemplate = new DataTemplate(typeof(UserViewCell));
            lstView.HeightRequest = 300;
            lstView.VerticalOptions = LayoutOptions.FillAndExpand;
            layout.Children.Add(lstView);
            Content = layout;
            //Retrieve data from server
            Task.Factory.StartNew(() =>
            {
                RetrieveData();
            });
            
        }

        private async void RetrieveData()
        {
            var parse = DependencyService.Get<IParseService>();
            var users = await parse.GetUsers();
            if (users != null)
                Device.BeginInvokeOnMainThread(() => lstView.ItemsSource = users);
        }
    }
}
