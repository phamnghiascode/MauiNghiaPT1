
using System.Windows.Input;

namespace ClothFashion.Controls
{
    public class SwipeAction : AbsoluteLayout, IDisposable
    {
        const int AnimationDuration = 100;

        readonly PanGestureRecognizer _gestureRecognizer;

        readonly View _gestureListener;

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

        public static readonly BindableProperty SwipeActionCommandProperty = BindableProperty.Create(
            nameof(Track), typeof(View), typeof(SwipeAction), default(ICommand));

        public ICommand SwipeActionCommand
        {
            get => (ICommand)GetValue(SwipeActionCommandProperty);
            set => SetValue(SwipeActionCommandProperty, value);
        }

        public SwipeAction()
        {
            _gestureRecognizer = new PanGestureRecognizer();
            _gestureRecognizer.PanUpdated += OnPanUpdated;

            _gestureListener = new ContentView
            {
                BackgroundColor = Colors.Black,
                Opacity = 0.01
            };
            _gestureListener.GestureRecognizers.Add(_gestureRecognizer);
            SizeChanged += OnSizeChanged;
        }

        private async void OnPanUpdated(object? sender, PanUpdatedEventArgs e)
        {
            if (Width == 0 || Height == 0)
                return;

            if (Thumb is null || Track is null)
                return;

            switch (e.StatusType) 
            {
                case GestureStatus.Started:
                    await Track.FadeTo(0.5, AnimationDuration);
                    break;
                case GestureStatus.Running:
                    var x = Math.Max(0, e.TotalX);
                    if(x > Width - Thumb.Width) 
                        x = Width - Thumb.Width;
                    Thumb.TranslationX = x;
                    break;
                case GestureStatus.Completed:
                    var translationX = Thumb.TranslationY;
                    await Track.FadeTo(1, AnimationDuration);
                    await Thumb.TranslateTo(0, 0, AnimationDuration, Easing.CubicIn);

                    if(translationX > Width - Thumb.Width)
                    {
                        SwipeActionCommand.Execute(null);
                    }
                    break;
            }   
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

            this.SetLayoutFlags(_gestureListener, Microsoft.Maui.Layouts.AbsoluteLayoutFlags.SizeProportional);
            this.SetLayoutBounds(_gestureListener, new Rect(0, 0, 1, 1));
            if (!Children.Contains(_gestureListener))
                Children.Add(_gestureListener);
        }

        public void Dispose()
        {
            SizeChanged += OnSizeChanged;
            if(_gestureListener is not null)
            {
                _gestureRecognizer.PanUpdated -= OnPanUpdated;
            }
        }
    }
}
