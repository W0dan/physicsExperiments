namespace PhysicsExperiments.Integralen
{
    public class ODESolver
    {
        public static void RungeKutta4(ODE ode, double ds)
        {
            var s = ode.IndependentVariable;
            var q = ode.GetAllDependentVariables();

            var dq1 = ode.GetRightHandSide(s, q, q, ds, 0.0);
            var dq2 = ode.GetRightHandSide(s + .5 * ds, q, dq1, ds, .5);
            var dq3 = ode.GetRightHandSide(s + .5 * ds, q, dq2, ds, .5);
            var dq4 = ode.GetRightHandSide(s + ds, q, dq3, ds, 1.0);

            ode.IndependentVariable = s + ds;

            for (var i = 0; i < ode.NumberOfEquationsToSolve; i++)
            {
                q[i] = q[i] + (dq1[i] + 2.0 * dq2[i] + 2.0 * dq3[i] + dq4[i]) / 6.0;
                ode.SetDependentVariable(i, q[i]);
            }
        }
    }
}