using System;
using System.Windows;
using System.Windows.Media;
using PhysicsExperiments.Core;
using PhysicsExperiments.Extensions;
using PhysicsExperiments.Resources;

namespace PhysicsExperiments.Experiments
{
    public class KinematicsExperiment : IAmAnExperiment
    {
        private readonly double _initialHorizontalVelocity;
        private readonly double _initialVerticalVelocity;
        private readonly DateTime _startTime;
        private readonly Point _initialCannonballPosition;
        private Point _cannonballPosition;
        private const double G = 9.81;

        public KinematicsExperiment(double initialHorizontalVelocity, double initialVerticalVelocity)
        {
            _initialHorizontalVelocity = initialHorizontalVelocity;
            _initialVerticalVelocity = initialVerticalVelocity;
            _startTime = DateTime.Now;
            _initialCannonballPosition = new Point(31.8, -23);
            _cannonballPosition = _initialCannonballPosition;
        }

        public void Notify(GameTime gameTime)
        {
            var deltaT = gameTime.SecondsElapsedSince(_startTime);

            if (_cannonballPosition.Y >= 0)
                return;

            _cannonballPosition.X = _initialCannonballPosition.X + _initialHorizontalVelocity * deltaT;
            _cannonballPosition.Y = _initialCannonballPosition.Y + _initialVerticalVelocity * deltaT + 0.5 * G * Math.Pow(deltaT, 2);
        }

        public ImageSource Draw()
        {
            var drawing = new DrawingGroup();

            //background
            drawing.DrawRectangle(new Rect(-5, -210, 300, 220), Brushes.White, new Pen(Brushes.AntiqueWhite, 1));

            drawing.DrawLine(new Point(-5, 0), new Point(295, 0), Brushes.AntiqueWhite);

            //5 point marker
            drawing.DrawLine(new Point(200, -210), new Point(200, 10), Brushes.BurlyWood);
            drawing.DrawText(201, -107, "5");

            //10 point marker
            drawing.DrawLine(new Point(220, -210), new Point(220, 10), Brushes.BurlyWood);
            drawing.DrawText(221, -107, "10");

            //20 point marker
            drawing.DrawLine(new Point(240, -210), new Point(240, 10), Brushes.BurlyWood);
            drawing.DrawText(241, -107, "20");

            //50 point marker
            drawing.DrawLine(new Point(260, -210), new Point(260, 10), Brushes.BurlyWood);
            drawing.DrawText(261, -107, "50");
            drawing.DrawLine(new Point(280, -210), new Point(280, 10), Brushes.BurlyWood);
            drawing.DrawText(281, -107, "0");

            //disc
            drawing.DrawCircle(_cannonballPosition, 1.5, Brushes.Black);

            var imageDrawing = new ImageDrawing(ResourceProvider.GetImage(Images.Cannon), new Rect(0, -25, 34.0, 24.4));
            drawing.Children.Add(imageDrawing);

            return new DrawingImage(drawing);
        }
    }
}