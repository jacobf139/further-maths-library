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
            ComplexNum num1 = new ComplexNum(1,2);
            Vector v1 = new Vector(3);
            Rational fraction = new Rational(1, 2);
            v1[0] = 1;
            v1[1] = 2;
            v1[2] = 3;

            Console.WriteLine(v1);
            Console.WriteLine(num1);
            Console.WriteLine(fraction);
        }
    }
}

