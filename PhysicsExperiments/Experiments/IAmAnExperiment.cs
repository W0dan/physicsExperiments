using System.Windows.Media;
using PhysicsExperiments.Core;

namespace PhysicsExperiments.Experiments
{
    public interface IAmAnExperiment : IWantToBeNotifiedOfGameTimeElapsedEvents
    {
        ImageSource Draw();
    }
}