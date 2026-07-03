using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace further_maths
{
    public class DualNum
    {
        private double realPart;
        private double dualPart;
        public DualNum(double real, double dual)
        {
            realPart = real;
            dualPart = dual;
        }

        public static double Real(DualNum num) => num.realPart;
        public static double Dual(DualNum num) => num.dualPart;

        // Constants

        public static readonly DualNum Epsilon = new DualNum(0, 1);

        // String conversions
        public override string ToString()
        {
            if (this.dualPart == 0) return $"{realPart}";
            if (this.realPart == 0 && this.dualPart == 1) return "ε";
            if (this.realPart == 0 && this.dualPart == -1) return "-ε";
            if (this.realPart == 0) return $"{dualPart}ε";
            if (this.dualPart == 1) return $"{realPart}+ε";
            if (this.dualPart == -1) return $"{realPart}-ε";
            if (this.dualPart < 0) return $"{realPart}{dualPart}ε";
            return $"{realPart}+{dualPart}ε";
        }
        public static implicit operator String(DualNum num) => num.ToString();

        // operators

        public static DualNum operator +(DualNum num1, DualNum num2)
        {
            double outputReal = Real(num1) + Real(num2);
            double outputDual = Dual(num1) + Dual(num2);
            return new DualNum(outputReal, outputDual);
        }
        public static DualNum operator -(DualNum num1, DualNum num2)
        {
            double outputReal = Real(num1) - Real(num2);
            double outputDual = Dual(num1) - Dual(num2);
            return new DualNum(outputReal, outputDual);
        }
        public static DualNum operator *(DualNum num1, DualNum num2)
        {
            double outputReal = Real(num1) * Real(num2);
            double outputDual = Real(num1) * Dual(num2) + Dual(num1) * Real(num1);
            return new DualNum(outputReal, outputDual);
        }
        public static DualNum operator /(DualNum num1, DualNum num2)
        {
            double outputReal = Real(num1) / Real(num2);
            double outputDual = (Dual(num2) * Real(num1) - Real(num1) * Dual(num2)) / Math.Pow(Real(num2), 2);
            return new DualNum(outputReal, outputDual);
        }
        public static implicit operator DualNum(double num) => new DualNum(num, 0);

        // properties

        public Matrix ToMatrix()
        {
            Matrix output = new Matrix(2, 2);
            output[0, 0] = realPart;
            output[0, 1] = dualPart;
            output[1, 1] = realPart;
            return output;
        }

        // Exponential & Logarithmic Functions        

        public static DualNum Pow(DualNum num, int power)
        {
            DualNum initialNum = num;
            DualNum output = 1;
            int absPower = Math.Abs(power);
            for (int i = 0; i < absPower; i++) output *= initialNum;
            if (power < 0) output = 1 / output;
            return output;
        }

        public static DualNum Log(DualNum num, DualNum logBase) => Log(num) / Log(logBase);

        public static DualNum Log(DualNum num)
        {
            double outputReal = Math.Log(Real(num));
            double outputDual = Dual(num) / Real(num);
            return new DualNum(outputReal, outputDual);
        }
    }
}
