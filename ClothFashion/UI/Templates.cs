using Microsoft.Maui.Controls.Shapes;

namespace ClothFashion.UI
{
    public static class Templates
    {
        public static DataTemplate OddGalleryItemTemplate = new (() =>
        {
            Border border = new Border()
            {
                StrokeShape = new RoundRectangle
                {
                    CornerRadius = new CornerRadius(10)
                },
                StrokeThickness = 0,
                HeightRequest= 300,
                WidthRequest = 150,
                Margin = -50
            };
            Image image = new Image
            {
                Aspect = Aspect.AspectFill,
            };
            image.SetBinding(Image.SourceProperty, "Image");
            border.Content = image;
            return border;

        });
        public static DataTemplate EvenGalleryItemTemplate = new (() =>
        {
            Border border = new Border()
            {
                StrokeShape = new RoundRectangle
                {
                    CornerRadius = new CornerRadius(10)
                },
                StrokeThickness = 0,
                HeightRequest = 300,
                WidthRequest = 150,
                Margin = -50
            };
            Image image = new Image
            {
                Aspect = Aspect.AspectFill,
            };
            image.SetBinding(Image.SourceProperty, "Image");
            border.Content = image;
            return border;
        });
    }
}
