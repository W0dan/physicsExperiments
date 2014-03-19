using System;
using System.Windows;
using System.Windows.Media;
using PhysicsExperiments.Core;
using PhysicsExperiments.Extensions;

namespace PhysicsExperiments.Experiments
{
    public class GravityExperiment : IAmAnExperiment
    {
        //constants (starting values)
        private const double InitialBoxXPosition = 0;
        private const double InitialBallYPosition = -120;

        //experiment parameters
        private readonly double _g;
        private readonly double _boxSpeed;

        //running values
        private readonly DateTime _startTime;
        private double _boxXPosition;
        private double _ballYPosition;
        private double _verticalSpeed;

        public GravityExperiment(double g, double boxSpeed)
        {
            _g = g;
            _boxSpeed = boxSpeed;
            _boxXPosition = InitialBoxXPosition;
            _ballYPosition = InitialBallYPosition;
            _startTime = DateTime.Now;
        }

        public void Notify(GameTime gameTime)
        {
            if (_ballYPosition >= 0)
                return;

            Calculate(gameTime.SecondsElapsedSince(_startTime));
        }

        private void Calculate(double deltaT)
        {
            //recalculate based on time (deltaT) in seconds
            _boxXPosition = InitialBoxXPosition + (_boxSpeed * deltaT);
            _ballYPosition = InitialBallYPosition + (0.5 * _g * Math.Pow(deltaT, 2));
            _verticalSpeed = _g * deltaT;
        }

        public ImageSource Draw()
        {
            var drawing = new DrawingGroup();

            //background
            drawing.DrawRectangle(new Rect(-20, -140, 280, 160), Brushes.AliceBlue, new Pen(Brushes.Blue, 1));

            //horizon
            drawing.DrawLine(new Point(-20, 0), new Point(260, 0),Brushes.Brown);

            //ball
            drawing.DrawCircle(new Point(200, _ballYPosition), 2, Brushes.Orange);

            //other ball
            drawing.DrawCircle(new Point(_boxXPosition + 20, _ballYPosition), 2, Brushes.Green);

            //box
            drawing.DrawRectangle(new Rect(_boxXPosition, -10, 40, 10), Brushes.Red, new Pen(Brushes.DarkRed, 1));

            //text
            drawing.DrawText(-10, -150, string.Format("vertical velocity = {0}", _verticalSpeed.ToString("0.00")));

            return new DrawingImage(drawing);
        }
    }
}