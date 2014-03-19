using System;
using System.Windows;
using System.Windows.Media;
using PhysicsExperiments.Core;
using PhysicsExperiments.Extensions;

namespace PhysicsExperiments.Experiments
{
    public class FrictionExperiment : IAmAnExperiment
    {
        private readonly double _frictionCoefficient;
        private readonly double _mass;
        private readonly double _initialVelocity;
        private double _discXPosition;
        private readonly DateTime _startTime;
        private const double G = 9.81;

        public FrictionExperiment(double frictionCoefficient, double mass, double initialVelocity)
        {
            _frictionCoefficient = frictionCoefficient;
            _mass = mass;
            _initialVelocity = initialVelocity;
            _startTime = DateTime.Now;
        }

        public void Notify(GameTime gameTime)
        {
            var deltaT = gameTime.SecondsElapsedSince(_startTime);

            var velocity = CalculateVelocity(deltaT);

            if (_discXPosition > 295 || velocity <= 0)
                return;

            Calculate(deltaT);
        }

        private double CalculateVelocity(double deltaT)
        {
            return _initialVelocity - _frictionCoefficient * G * deltaT;
        }

        private void Calculate(double deltaT)
        {
            _discXPosition = _initialVelocity * deltaT - .5 * _frictionCoefficient * G * Math.Pow(deltaT, 2);
        }

        public ImageSource Draw()
        {
            var drawing = new DrawingGroup();

            //background
            drawing.DrawRectangle(new Rect(-5, -100, 300, 200), Brushes.White, new Pen(Brushes.AntiqueWhite, 1));

            //5 point marker
            drawing.DrawLine(new Point(200, -100), new Point(200, 100), Brushes.BurlyWood);
            drawing.DrawText(201, -7, "5");

            //10 point marker
            drawing.DrawLine(new Point(220, -100), new Point(220, 100), Brushes.BurlyWood);
            drawing.DrawText(221, -7, "10");

            //20 point marker
            drawing.DrawLine(new Point(240, -100), new Point(240, 100), Brushes.BurlyWood);
            drawing.DrawText(241, -7, "20");

            //50 point marker
            drawing.DrawLine(new Point(260, -100), new Point(260, 100), Brushes.BurlyWood);
            drawing.DrawText(261, -7, "50");
            drawing.DrawLine(new Point(280, -100), new Point(280, 100), Brushes.BurlyWood);
            drawing.DrawText(281, -7, "0");

            //disc
            drawing.DrawCircle(new Point(_discXPosition, 0), 3, Brushes.Red);

            return new DrawingImage(drawing);
        }
    }
}