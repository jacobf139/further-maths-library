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
            ComplexNum numBase = new ComplexNum(2.11, 3.1);
            ComplexNum num = new ComplexNum(6.1, 4.1);
            Console.WriteLine(ComplexNum.Log(num));
            Console.WriteLine(ComplexNum.Log(numBase));
            Console.WriteLine(ComplexNum.Log(num,numBase));
            Math.Log
        }
    }
}

