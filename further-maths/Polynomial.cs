using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace further_maths
{
    internal class Polynomial
    {
        protected int order;
        protected double[] coefficients;
        public Polynomial(int degree)
        {
            if (degree < 0) throw new ArgumentException("Cannot have a polynomial with an order of less than 0.");
            order = degree;
            coefficients = new double[degree+1];
        }
        public double this[int xPower]
        {
            get { return coefficients[xPower];  }
            set { coefficients[xPower] = value; }
        }
        public double Evaluate(double x)
        {
            double sum = 0;
            for (int i = 0; i <= order; i++)
            {
                sum += coefficients[i] * Math.Pow(x, i);
            }
            return sum;
        }        
        public override string ToString()
        {
            string result = "";
            for (int i = order; i >= 0; i--)
            {
                if (coefficients[i] != 0)
                {
                    if (i != order && coefficients[i] > 0) result += '+';
                    result += coefficients[i];
                    if (i == 1) result += 'x';
                    if (i > 1) result += $"x^{i}";
                }                
            }
            return result;
        }
        public Polynomial Derivative()
        {
            Polynomial derivative = new Polynomial(order - 1);
            for (int i = 0; i < order; i++)
            {
                derivative[i] = this[i + 1] * (i + 1);
            }
            return derivative;
        }
        public Polynomial NthDerivative(int n)
        {
            Polynomial output = this;
            for (int i = 0; i < n; i++) output = output.Derivative();
            return output;
        }
        public static implicit operator String(Polynomial fun) => fun.ToString();
    } 
    internal class Quadratic : Polynomial
    {
        public Quadratic() : base(2) { }
        public double Discriminant() => Math.Pow(coefficients[1], 2) - (4 * coefficients[2] * coefficients[0]);
        public ComplexNum[] FindRoots()
        {
            ComplexNum[] solutions = new ComplexNum[order];
            solutions[0] = (-coefficients[1] - ComplexNum.Sqrt(this.Discriminant())) / (2 * coefficients[2]);
            solutions[1] = (-coefficients[1] + ComplexNum.Sqrt(this.Discriminant())) / (2 * coefficients[2]);
            return solutions;
        }
    }
}
