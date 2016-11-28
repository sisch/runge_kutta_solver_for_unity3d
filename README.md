# Solver for stiff ordinary differential equations

There was no free solver for ordinary differential equations available written in C-sharp and thus compatible with Unity. This repository consists of a very specific implementation of Runge-Kutta resembling the predator-prey relationship described by Lotka and Volterra. This code can potentially be adapted to simulate population dynamics for any given setting.

When I find the time, I might extend this with:

1. a unity scene showing how to use this code
2. a more dynamic generator for the differential equations

## Example
Run the following to calculate population numbers for rabbits and wolfs over time
```csharp
double rabbitStart = 10.0f;
double wolfStart = 5.0f;
double starttime = 0;
double endtime = 1f;
int steps = 10;

IntegratorLSODE integ;
double[] y = new double[2];

integ = new IntegratorLSODE ();
y [0] = rabbitStart;
y [1] = wolfStart;
while(True) {
  y = integ.integrate(starttime, endtime, steps)
  // values of y are population sizes
}

```
