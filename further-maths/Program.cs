using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace further_maths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ComplexNum num1 = ComplexNum.Parse("1+1i");
            ComplexNum power = ComplexNum.Pow(num1, 0.5);
            Vector v1 = new Vector(3);
            v1[0] = 1;
            v1[1] = 2;
            v1[2] = 4;

            Console.WriteLine(v1);
            Console.WriteLine(num1.modulus());
            Console.WriteLine(power);
        }
    }
}

