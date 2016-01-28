using CrossFeaturesXamarin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace CrossFeaturesXamarin.Pages.ViewCells
{
    public class UserViewCell : ViewCell
    {
        public UserViewCell()
        {
            var roundedImage = new RoundedImage
            {
                BorderColor = Color.Black,
                Aspect = Aspect.AspectFill,
                BorderWidth = 2.0,
            };
            roundedImage.SetBinding(Image.SourceProperty, "ProfilePicture");

            var lblName = new Label
            {
                TextColor = Color.FromHex("#A5A5A5"),
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                XAlign = TextAlignment.Start,
                YAlign = TextAlignment.Center
            };
            lblName.SetBinding(Label.TextProperty, "Name");

            var lblUsername = new Label
            {
                TextColor = Color.FromHex("#A5A5A5"),
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                XAlign = TextAlignment.Start,
                YAlign = TextAlignment.Center
            };
            lblUsername.SetBinding(Label.TextProperty, "Username");

            var textLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Spacing = 2,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            textLayout.Children.Add(lblName);
            textLayout.Children.Add(lblUsername);

            #region Configure layout
            var layout = new RelativeLayout
            {
                Padding = new Thickness(0, 2, 0, 2),
                BackgroundColor = Color.White
            };
            layout.Children.Add(roundedImage,
                Constraint.RelativeToParent(p => p.Width * 0.03),
                Constraint.RelativeToParent(p => p.Width * 0.01),
                Constraint.RelativeToParent(p => p.Width * 0.15),
                Constraint.RelativeToParent(p => p.Width * 0.15));
            layout.Children.Add(textLayout,
                Constraint.RelativeToView(roundedImage, (p, v) => v.X + v.Width + 15),
                Constraint.RelativeToView(roundedImage, (p, v) => v.Y),
                Constraint.RelativeToView(roundedImage, (p, v) => p.Width - v.X - v.Width - 20),
                Constraint.RelativeToView(roundedImage, (p, v) => v.Height));
            #endregion

            View = layout;

            var editMenu = new MenuItem() { Text = "Edit" };
            editMenu.Clicked += (sender, e) =>
            {
                Application.Current.MainPage.DisplayAlert("Edit", "You want to edit this entry", "Ok");
            };

            var deleteMenu = new MenuItem() { Text = "Delete", IsDestructive = true };
            deleteMenu.Clicked += (sender, e) =>
            {
                Application.Current.MainPage.DisplayAlert("Deleted", "You delete this entry", "Ok");
            };

            ContextActions.Add(editMenu);
            ContextActions.Add(deleteMenu);
        }
    }
}
