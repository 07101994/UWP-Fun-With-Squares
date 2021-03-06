﻿using System;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using XamlBrewer.Uwp.Controls;

namespace XamlBrewer.Uwp.SquarePathSample
{
    public sealed partial class BreathingSquarePage : Page
    {
        private Square _backSquare;

        public BreathingSquarePage()
        {
            this.InitializeComponent();

            RenderCanvas();

            this.Loaded += BreathingSquarePage_Loaded;
        }

        private void BreathingSquarePage_Loaded(object sender, RoutedEventArgs e)
        {
            // Start animation
            var shape = _backSquare.ShapeVisual;
            var compositor = Window.Current.Compositor;
            var animation = compositor.CreateScalarKeyFrameAnimation();
            var linear = compositor.CreateLinearEasingFunction();
            animation.InsertKeyFrame(1f, 360f, linear);
            animation.Duration = TimeSpan.FromSeconds(8);
            animation.Direction = AnimationDirection.Normal;
            animation.IterationBehavior = AnimationIterationBehavior.Forever;
            shape.StartAnimation(nameof(shape.RotationAngleInDegrees), animation);
        }

        private void RenderCanvas()
        {
            var side = 485;

            // Back
            _backSquare = new Square
            {
                Side = 600,
                Fill = Colors.LightSteelBlue,
                Height = Canvas.Height,
                Width = Canvas.Width,
                CenterPointX = 500,
                CenterPointY = 500,
                RotationCenterX = 500,
                RotationCenterY = 500
            };
            Canvas.Children.Add(_backSquare);

            // Front
            var square = new Square
            {
                Side = side,
                Fill = Colors.LightSlateGray,
                Height = Canvas.Height,
                Width = Canvas.Width,
                CenterPointX = side / 2,
                CenterPointY = side / 2
            };
            Canvas.Children.Add(square);

            square = new Square
            {
                Side = side,
                Fill = Colors.LightSlateGray,
                Height = Canvas.Height,
                Width = Canvas.Width,
                CenterPointX = 1000 - side / 2,
                CenterPointY = side / 2
            };
            Canvas.Children.Add(square);

            square = new Square
            {
                Side = side,
                Fill = Colors.LightSlateGray,
                Height = Canvas.Height,
                Width = Canvas.Width,
                CenterPointX = side / 2,
                CenterPointY = 1000 - side / 2
            };
            Canvas.Children.Add(square);

            square = new Square
            {
                Side = side,
                Fill = Colors.LightSlateGray,
                Height = Canvas.Height,
                Width = Canvas.Width,
                CenterPointX = 1000 - side / 2,
                CenterPointY = 1000 - side / 2
            };
            Canvas.Children.Add(square);
        }
    }
}
