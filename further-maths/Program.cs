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
            Polynomial fun1 = new Polynomial(2);

            fun1[0] = 1;
            fun1[1] = 2;
            fun1[2] = 3;

            Console.WriteLine(fun1.NthDerivative(3));
            // foreach (ComplexNum solution in fun1.FindRoots()) Console.WriteLine(solution);
        }
    }
}

