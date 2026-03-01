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
            ComplexNum num1 = ComplexNum.Parse("3+-2i");
            Console.WriteLine(ComplexNum.Pow(num1, -1));
        }
    }
}

