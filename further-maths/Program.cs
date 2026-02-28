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

            Console.WriteLine(num1.argument());
            Console.WriteLine(num1.modulus());
            Console.WriteLine((power).ToString());
        }
    }
}

