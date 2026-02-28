using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace further_maths
{
    internal class ComplexNum
    {
        public double Re;
        public double Im;
        public ComplexNum(double re, double im)
        {
            Re = re;
            Im = im;
        }
        public static ComplexNum Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) throw new FormatException("Cannot parse an empty string");
            foreach (char character in input) if ("0123456789-+i.".IndexOf(character) == -1) throw new FormatException("Attempted to parse string containing invalid characters.");

            // need to account for a-bi, bi, im
            string[] lines = input.Split('+');
            double reInput = 0;
            double imInput = 0;
            if (lines.Length == 2)
            {
                reInput = double.Parse(lines[0]);
                imInput = double.Parse(lines[1].Substring(0, lines[1].Length - 1));
            } else
            {
                if (lines[0].Contains('i')) imInput = double.Parse(lines[0].Substring(0, lines[1].Length - 1));
                else reInput = double.Parse(lines[0]);
            }
            return new ComplexNum(reInput, imInput);
        }
        public static ComplexNum operator +(ComplexNum a, ComplexNum b)
        {
            ComplexNum result = new(0,0);
            result.Re = a.Re + b.Re;
            result.Im = a.Im + b.Im;
            return result;
        }
        public static ComplexNum operator -(ComplexNum a, ComplexNum b)
        {
            ComplexNum result = new(0,0);
            result.Re = a.Re - b.Re;
            result.Im = a.Im - b.Im;
            return result;
        }
        public static ComplexNum operator *(ComplexNum a, ComplexNum b)
        {
            ComplexNum result = new(0,0);
            result.Re = a.Re * b.Re - a.Im * b.Im;
            result.Im = a.Re * b.Im + a.Im * b.Re;
            return result;
        }
        public static ComplexNum operator /(ComplexNum a, ComplexNum b)
        {  
            ComplexNum result = new(0,0);
            result.Re = (a.Re * b.Re + a.Im * b.Im) / (b.Re * b.Re + b.Im * b.Im);
            result.Im = (a.Im * b.Re - a.Re * b.Im) / (b.Re * b.Re + b.Im * b.Im);
            return result;
        }
        public static implicit operator ComplexNum(double num) => new ComplexNum(num, 0);
        public static readonly ComplexNum I = new ComplexNum(0, 1);
        public ComplexNum conjugate()
        {
            ComplexNum result = new(0,0);
            result.Re = Re;
            result.Im = -1 * Im;
            return result;
        }
        public new string ToString()
        {
            if (this.Im == 0) return $"{Re}";
            if (this.Re == 0) return $"{Im}i";
            if (this.Im < 0) return $"{Re}{Im}i";
            return $"{Re}+{Im}i";
        }
        public double modulus() => Math.Sqrt(Re * Re + Im * Im);
        public double argument()
        {
            double theta = Math.Atan(Im / Re);
            if (Re < 0 && Im >= 0) theta += Math.PI;
            if (Re < 0 && Im < 0) theta -= Math.PI;
            return theta;
        }
        public bool IsReal() => Im == 0;
        public static ComplexNum Sqrt(double num)
        {
            if (num >= 0) return new ComplexNum(Math.Sqrt(num), 0);
            return new ComplexNum(0, Math.Sqrt(Math.Abs(num)));
        }
        public static ComplexNum Sqrt(ComplexNum num) => ComplexNum.Pow(num, 0.5);
        public static ComplexNum Pow(ComplexNum num, double power)
        {
            double resultRe = Math.Pow(num.modulus(),power) * Math.Cos(num.argument() * power);
            double resultIm = Math.Pow(num.modulus(), power) * Math.Sin(num.argument() * power);
            return new ComplexNum(resultRe, resultIm);
        }
        public static ComplexNum Log(ComplexNum num, double logBase) => new ComplexNum(0, (num.argument() * Math.Log(num.modulus() * Math.E, logBase)));
        public static implicit operator String(ComplexNum num) => num.ToString();
    }
}
