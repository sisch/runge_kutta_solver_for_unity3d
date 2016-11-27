using System.Collections;
using UnityEngine;

public class IntegratorLSODE {
	private double rkExample(double x, double u){

		double birthrate = 1.05;
		double capacity = 50.0;
		//double res = -2.0f * u + x + 4.0f;
		double res = birthrate * u * (1 - u / capacity);
		return res;
	}
	private double[] lotkaVolterra(double x, double[] y){
		double birthrateR = 1.00f;
		double deathRateW = 1.5f;
		double deathRateR = 0.1f;
		double birthRateW = 0.75;
		double dR = birthrateR * y [0] - deathRateR * y [0] * y [1];
		double dW = birthRateW * y [0] * y [1] * deathRateR - deathRateW * y [1];
		double[] ret = {dR,dW};
		return ret;
	}
	private double[] rangekuttaNext(double x, double[] y, double interval){
	//		Debug.Log (string.Format ("x: {0}, y: {1}, interval: {2}", x, y, interval));
		double[] k1 = this.lotkaVolterra (x, y);
	//		Debug.Log (string.Format ("x: {0}, k1: {1}, interval: {2}", x, k1, interval));
		double[] k2 = this.lotkaVolterra (x + interval / 2, new double[]{y[0] + k1[0] * interval / 2,y[1] + k1[1] * interval / 2 });
	//		Debug.Log (string.Format ("x: {0}, k2: {1}, interval: {2}", x, k2, interval));
		double[] k3 = this.lotkaVolterra (x + interval / 2, new double[]{y[0] + k2[0] * interval / 2,y[1] + k2[1] * interval / 2 });
	//		Debug.Log (string.Format ("x: {0}, k3: {1}, interval: {2}", x, k3, interval));
		double[] k4 = this.lotkaVolterra(x+interval, new double[]{y[0] + k3[0] * interval,y[1] + k3[1] * interval});
	//		Debug.Log (string.Format ("x: {0}, k4: {1}, interval: {2}", x, k4, interval));
		double[] yout = new double[]{y[0] + 1.0f/6.0f*(k1[0] + 2*k2[0]+2*k3[0] + k4[0])*interval,y[1] + 1.0f/6.0f*(k1[1] + 2*k2[1]+2*k3[1] + k4[1])*interval};
	//		Debug.Log (string.Format ("x: {0}, y: {1}, interval: {2}", x, yout, interval));
		return yout;
	}
	public IntegratorLSODE(){

	}
	public double[] integrate(double[] yIn, double start, double end, int steps){
		double[] yOut = new double[yIn.Length];
		yIn.CopyTo (yOut, 0);
		double interval = (end - start) / steps;
			for(double x = start; x < end; x += interval){
				yOut = this.rangekuttaNext(start,yIn,interval);
			}
		return yOut;
	}
}
