using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace further_maths
{
    internal class Rational
    {
        private int numerator;
        private int denominator;
        public Rational(int numeratorInput, int denominatorInput)
        {
            if (denominatorInput == 0) throw new ArgumentException("Tried to set the denominator to 0");
            numerator = numeratorInput;
            denominator = denominatorInput;
            Simplify();
        }
        public Rational(int numeratorInput)
        {
            numerator = numeratorInput;
            denominator = 1;
            Simplify();
        }
        public Rational(double doubleInput)
        {
            Rational converted = DoubleToRational(doubleInput);
            numerator = converted.numerator;
            denominator = converted.denominator;
        }
        private void Simplify()
        {
            if (denominator < 0)
            {
                numerator *= -1;
                denominator *= -1;
            }
            int hcf = HighestCommonFactor(numerator, denominator);
            numerator = numerator / hcf;
            denominator = denominator / hcf;
        }
        private static int HighestCommonFactor(int num1, int num2)
        {
            num1 = Math.Abs(num1);
            num2 = Math.Abs(num2);
            bool found = false;
            int c;
            int d;
            int e;
            while (!found)
            {
                c = num1 / num2;
                d = c * num2;
                e = num1 - d;
                if (e == 0) found = true;
                else
                {
                    num1 = num2;
                    num2 = e;
                }
            }
            return num2;
        }
        public double ToDouble() => (double)numerator / (double)denominator;
        private static int DoubleNumberOfDecimalPlaces(double num) => num.ToString().Split('.')[1].Count();
        public static Rational DoubleToRational(double num)
        {
            int dpNum = DoubleNumberOfDecimalPlaces(num);
            Rational output = new Rational((int)(num * (int)Math.Pow(10, dpNum)), (int)Math.Pow(10, dpNum));
            output.Simplify();
            return output;
        }
        public override string ToString()
        {
            if (denominator == 1) return $"{numerator}";
            return $"{numerator}/{denominator}";
        }
        public Rational Reciprocal() => new Rational(denominator, numerator);
        public static Rational Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) throw new FormatException("Cannot parse an empty string");
            foreach (char character in input) if ("0123456789-/".IndexOf(character) == -1) throw new FormatException("Attempted to parse string containing invalid characters.");

            string[] parts = input.Split('/');
            int numeratorInput = int.Parse(parts[0]);
            int denominatorInput;
            if (parts.Length == 1) denominatorInput = 1;
            else denominatorInput = int.Parse(parts[1]);

            return new Rational(numeratorInput, denominatorInput);
        }
        public static Rational operator +(Rational num1, Rational num2)
        {
            int outputNumerator = num1.numerator * num2.denominator + num2.numerator * num1.denominator;
            int outputDenominator = num1.denominator * num2.denominator;
            Rational output = new Rational(outputNumerator, outputDenominator);
            output.Simplify();
            return output;
        }
        public static Rational operator *(Rational num1, Rational num2)
        {
            int outputNumerator = num1.numerator * num2.numerator;
            int outputDenominator = num1.denominator * num2.denominator;
            Rational output = new Rational(outputNumerator, outputDenominator);
            output.Simplify();
            return output;
        }
        public static Rational operator /(Rational num1, Rational num2)
        {
            Rational output = num1 * num2.Reciprocal();
            output.Simplify();
            return output;
        }
        public static Rational operator -(Rational num1, Rational num2)
        {
            int outputNumerator = num1.numerator * num2.denominator - num2.numerator * num1.denominator;
            int outputDenominator = num1.denominator * num2.denominator;
            Rational output = new Rational(outputNumerator, outputDenominator);
            output.Simplify();
            return output;
        }
        public static implicit operator Rational(int value)
        {
            return new Rational(value, 1);
        }
        public static implicit operator Rational(double value) => DoubleToRational(value);
    }
}
