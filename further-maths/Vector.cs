using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace further_maths
{
    internal class Vector
    {
        private Matrix matrix;
        public Vector(int size) => matrix = new Matrix(size, 1);
        public Vector(Matrix mat) => matrix = mat;
        public double this[int index]
        {
            get { return matrix[index, 0]; }
            set { matrix[index,1] = value; }
        }
        public Matrix ToMatrix() => matrix;
        public int Length() => matrix.dim(0);
        public static double Dot(Vector vector1, Vector vector2)
        {
            if (vector1.Length() != vector2.Length()) throw new ArgumentException("Tried to find the dot product of vectors of different lengths.");
            double sum = 0;
            for (int i = 0; i < vector1.Length(); i++)
            {
                sum += vector1[i] * vector2[i];
            }
            return sum;
        }
        public double Magnitude()
        {
            double sumOfSquares = 0;
            for (int i = 0; i < this.Length(); i++)
            {
                sumOfSquares += Math.Pow(this[i], 2);
            }
            return Math.Sqrt(sumOfSquares);
        }
        public static double AngleBetweenVectors(Vector vector1, Vector vector2)
        {
            double dotProduct = Vector.Dot(vector1, vector2);
            double CosineOfAngle = dotProduct / (vector1.Magnitude() * vector2.Magnitude());
            return Math.Acos(CosineOfAngle) * 180/Math.PI;
        }
    }
}
