namespace PhysicsExperiments.Integralen
{
    public class SpringODE : ODE
    {
        public SpringODE(double mass, double dampingCoefficient, double springConstant, double initialLocation)
            : base(2)
        {
            Mass = mass;
            DampingCoefficient = dampingCoefficient;
            SpringConstant = springConstant;
            InitialLocation = initialLocation;
            DeltaTime = 0.0;

            SetDependentVariable(0, 0.0);
            SetDependentVariable(1, initialLocation);
        }

        public double DeltaTime { get; set; }
        public double InitialLocation { get; set; }
        public double SpringConstant { get; set; }
        public double DampingCoefficient { get; set; }
        public double Mass { get; set; }

        public double GetVx()
        {
            return GetDependentVariable(0);
        }

        public double GetX()
        {
            return GetDependentVariable(1);
        }

        public double GetTime()
        {
            return IndependentVariable;
        }

        public void UpdatePositionAndVelocity(double dt)
        {
            ODESolver.RungeKutta4(this, dt);
        }

        public override double[] GetRightHandSide(double s, double[] q, double[] deltaQ, double ds, double qScale)
        {
            var newQ = new double[4];
            for (var i = 0; i < 2; i++)
                newQ[i] = q[i] + qScale*deltaQ[i];

            var dq = new double[4];
            dq[0] = -ds*(DampingCoefficient*newQ[0] + SpringConstant*newQ[1])/Mass;
            dq[1] = ds*newQ[0];

            return dq;
        }
    }
}