using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
            ComplexNum numBase = new ComplexNum(3.1, 3.1);
            ComplexNum power = new ComplexNum(3.1, 3.1);
            ComplexNum num = ComplexNum.Pow(numBase, 2);
            Console.WriteLine(num);
        }
    }
}

