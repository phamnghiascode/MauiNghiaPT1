
namespace ClothFashion.Controls
{
    public class SwipeAction : AbsoluteLayout
    {

        public static readonly BindableProperty ThumbProperty = BindableProperty.Create(
            nameof(Thumb), typeof(View), typeof(SwipeAction), default(View));

        public View Thumb
        {
            get => (View)GetValue(ThumbProperty);
            set => SetValue(ThumbProperty, value);
        }

        public static readonly BindableProperty TrackProperty = BindableProperty.Create(
            nameof(Track), typeof(View), typeof(SwipeAction), default(View));

        public View Track
        {
            get => (View)GetValue(TrackProperty);
            set => SetValue(TrackProperty, value);
        }

        public SwipeAction()
        {
            SizeChanged += OnSizeChanged;
        }

        void OnSizeChanged(object? sender, EventArgs e)
        {
            if (Width == 0 || Height == 0) 
                return;

            if (Thumb is null || Track is null) 
                return;

            this.SetLayoutFlags(Track, Microsoft.Maui.Layouts.AbsoluteLayoutFlags.SizeProportional);
            this.SetLayoutBounds(Track, new Rect(0, 0, 1, 1));
            if(!Children.Contains(Track))
                Children.Add(Track);

            this.SetLayoutFlags(Thumb, Microsoft.Maui.Layouts.AbsoluteLayoutFlags.None);
            this.SetLayoutBounds(Thumb, new Rect(0, 0, Width / 3, Height));
            if(!Children.Contains(Thumb)) 
                Children.Add(Thumb);
        }
    }
}
