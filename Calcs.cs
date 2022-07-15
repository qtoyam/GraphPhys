using System;
using System.Drawing;

namespace GraphPhys
{
	internal static class Calcs
	{
		internal static double Find_r(PointF end, PointF start)
		{
			return Math.Sqrt(
				Math.Pow((end.X - start.X), 2) + Math.Pow((end.Y - start.Y), 2) //sqrt[ (x2-x1)^2 + (y2-y1)^2 ]
				);
		}

		internal static double Find_rpow(PointF end, PointF start)
		{
			return
				Math.Pow((end.X - start.X), 2) + Math.Pow((end.Y - start.Y), 2); //sqrt[ (x2-x1)^2 + (y2-y1)^2 ]

		}

		internal static PointF Find_Parallelogram_Corner(PointF A, PointF B, PointF D)//B__C
		{                                                                    // /_/
			return new PointF((B.X - A.X + D.X),                            //  A D
				(B.Y - A.Y + D.Y));
		}

		internal static PointF Find_E1e(PointF up, double q1)
		{
			double upX = Convert.ToDouble(up.X);
			double upY = Convert.ToDouble(up.Y);
			const double k = 1;
			double r1pow = Find_rpow(up, new PointF(0, 0));
			double r1_power1_5 = Math.Pow(r1pow, 1.5);
			double numerator = k * Math.Abs(q1);
			double E1ex = upX * (1 + (numerator / r1_power1_5));
			double E1ey = upY * (1 + (numerator / r1_power1_5));

			//rounding doubles
			E1ex = Math.Round(E1ex, 6);
			E1ey = Math.Round(E1ey, 6);

			//converting to float to put into PointF()
			float E1ex_res = Convert.ToSingle(E1ex);
			float E1ey_res = Convert.ToSingle(E1ey);
			return new PointF(E1ex_res, E1ey_res);
		}

		internal static PointF Find_E2e(PointF up, double q2, double d)
		{
			double upX = Convert.ToDouble(up.X);
			double upY = Convert.ToDouble(up.Y);
			float q2x = Convert.ToSingle(d);
			const double k = 1;
			double r2pow = Find_rpow(up, new PointF(q2x, 0));
			double r2_power1_5 = Math.Pow(r2pow, 1.5);
			double numerator_forX = 0;
			if (upX < d)
			{
				numerator_forX = k * Math.Abs(q2) * (d - upX);
			}
			else
			{
				numerator_forX = k * Math.Abs(q2) * (d + upY);
			}
			double numerator_forY = k * Math.Abs(q2);
			double E2ex = upX + (numerator_forX / r2_power1_5);
			double E2ey = upY * (1 - (numerator_forY / r2_power1_5));

			//rounding doubles
			E2ex = Math.Round(E2ex, 6);
			E2ey = Math.Round(E2ey, 6);

			//converting to float to put into PointF()
			float E2ex_res = Convert.ToSingle(E2ex);
			float E2ey_res = Convert.ToSingle(E2ey);
			return new PointF(E2ex_res, E2ey_res);
		}

		internal static double Find_p_c(double q, double k, double r)
		{
			return (k * Math.Abs(q)) / (r);
		}

		internal static double Find_p(double q1,double q2, double k,PointF q1p, PointF q2p, PointF end)
		{
			return Find_p_c(q1, k, Find_r(end, q1p)) + Find_p_c(q2, k, Find_r(end, q2p));
		}
	}
}
