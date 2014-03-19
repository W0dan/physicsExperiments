namespace PhysicsExperiments.Resources
{
    public class ImageName
    {
        private readonly string _value;

        public ImageName(string value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value;
        }
    }
}