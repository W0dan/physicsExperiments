using System.Collections.Generic;

namespace PhysicsExperiments.Integralen
{
    public abstract class ODE
    {
        private readonly int _numberOfEquationsToSolve;
        private readonly double[] _dependentVariables;

        protected ODE(int numberOfEquationsToSolve)
        {
            _numberOfEquationsToSolve = numberOfEquationsToSolve;
            _dependentVariables = new double[numberOfEquationsToSolve];
        }

        public double IndependentVariable { get; set; }

        public double GetDependentVariable(int index)
        {
            return _dependentVariables[index];
        }

        public int NumberOfEquationsToSolve { get { return _numberOfEquationsToSolve; } }

        public void SetDependentVariable(int index, double value)
        {
            _dependentVariables[index] = value;
        }

        public double[] GetAllDependentVariables()
        {
            return _dependentVariables;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s">independent variable</param>
        /// <param name="q">dependent variables</param>
        /// <param name="deltaQ"></param>
        /// <param name="ds"></param>
        /// <param name="qScale"></param>
        /// <returns></returns>
        public abstract double[] GetRightHandSide(double s, double[] q, double[] deltaQ, double ds, double qScale);
    }
}