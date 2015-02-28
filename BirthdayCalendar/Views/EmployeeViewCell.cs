using System;
using Xamarin.Forms;

namespace BirthdayCalendar
{
    public class EmployeeViewCell : ViewCell
    {
        public EmployeeViewCell()
        {
            var lblName = new Label 
                {
                    YAlign = TextAlignment.Start
                };
            lblName.SetBinding(Label.TextProperty, "Name");

            var lblPractice = new Label
                {
                    YAlign = TextAlignment.End
                };
            lblPractice.SetBinding(Label.TextProperty, "Practice");

            var imgContact = new Image
                {
                    HorizontalOptions = LayoutOptions.End
                };
            imgContact.SetBinding(Image.SourceProperty, "Image");

            var textStack = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    Padding = new Thickness(10,0,0,0),
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    Children = { lblName, lblPractice }
                };

            var mainStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                    Children = { textStack, imgContact }
            };

            View = mainStack;
        }
    }
}

