using System;
using System.Windows;
using System.Windows.Media;
using PhysicsExperiments.Core;
using PhysicsExperiments.Extensions;
using PhysicsExperiments.Integralen;

namespace PhysicsExperiments.Experiments
{
    public class SpringExperiment : IAmAnExperiment
    {
        private readonly SpringODE _spring;
        private double _ballYPosition;
        private readonly DateTime _startTime;

        public SpringExperiment(double endMass, double dampingCoefficient, double springConstant, double initialLocation)
        {
            _spring = new SpringODE(endMass, dampingCoefficient, springConstant, initialLocation);
            _startTime = DateTime.Now;
            _ballYPosition = initialLocation;
        }

        public void Notify(GameTime gameTime)
        {
            if (_ballYPosition > -0.0001 && _ballYPosition < 0.0001)
            {
                _ballYPosition = 0;
                return;
            }

            //todo : p81 : modify SpringODE to include gravity
            _spring.UpdatePositionAndVelocity(gameTime.SecondsElapsedSince(_startTime));
            _ballYPosition = _spring.GetX();
        }

        public ImageSource Draw()
        {
            var drawing = new DrawingGroup();

            //background
            drawing.DrawRectangle(new Rect(-100, 0, 200, 200), Brushes.White, new Pen(Brushes.BurlyWood, 1));

            //spring
            drawing.DrawLine(new Point(0, 0), new Point(0, 100 + _ballYPosition), Brushes.Black);

            //disc
            drawing.DrawCircle(new Point(0, 100 + _ballYPosition), 10, Brushes.Red, new Pen(Brushes.DarkRed, 3));

            return new DrawingImage(drawing);
        }
    }
}