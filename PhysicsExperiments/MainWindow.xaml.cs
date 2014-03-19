using System.Windows;
using PhysicsExperiments.Core;
using PhysicsExperiments.Experiments;

namespace PhysicsExperiments
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IWantToBeNotifiedOfGameTimeElapsedEvents
    {
        private IAmAnExperiment _experiment;
        private GameLoop _gameloop;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _gameloop = new GameLoop();
            RunExperiment(new KinematicsExperiment(40.3, -25)); // cannonball shot
        }

        public void RunExperiment(IAmAnExperiment experiment)
        {
            _gameloop.Reset();
            _experiment = experiment;
            _gameloop.Register(this);
            _gameloop.Register(_experiment);
            _gameloop.Start();
        }

        public void Notify(GameTime gameTime)
        {
            GameCanvas.Source = _experiment.Draw();
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            _gameloop.Stop();
        }

        private void GravityEarthButtonClick(object sender, RoutedEventArgs e)
        {
            RunExperiment(new GravityExperiment(9.81, 38)); //earth
        }

        private void GravityMoonButtonClick(object sender, RoutedEventArgs e)
        {
            RunExperiment(new GravityExperiment(1.624, 15)); //moon
        }

        private void GravityJupiterButtonClick(object sender, RoutedEventArgs e)
        {
            RunExperiment(new GravityExperiment(24.8, 60)); //jupiter
        }

        private void FrictionIceIceButtonClick(object sender, RoutedEventArgs e)
        {
            RunExperiment(new FrictionExperiment(.03, 1.0, 12.6)); // ice - ice
        }

        private void FrictionRubberWetConcreteButtonClick(object sender, RoutedEventArgs e)
        {
            RunExperiment(new FrictionExperiment(.5, 1.0, 51.5)); // rubber - wet concrete
        }

        private void FrictionRubberDryConcreteButtonClick(object sender, RoutedEventArgs e)
        {
            RunExperiment(new FrictionExperiment(.8, 1.0, 65)); // rubber - dry concrete
        }

        private void KinematicsCannonShotButtonClick(object sender, RoutedEventArgs e)
        {
            RunExperiment(new KinematicsExperiment(40.3, -25)); // cannonball shot
        }

        private void SpringButtonClick(object sender, RoutedEventArgs e)
        {
            RunExperiment(new SpringExperiment(1000.0, .5, 5, 40)); // spring with a weight of 1000 kg
        }
    }
}
