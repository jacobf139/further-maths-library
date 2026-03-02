using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            set { matrix[index,0] = value; }
        }
        /// <summary>
        /// Converts the current object to the matrix class.
        /// </summary>
        /// <returns></returns>
        public Matrix ToMatrix() => matrix;
        /// <summary>
        /// Returns the length of the current vector.
        /// </summary>
        /// <returns></returns>
        public int Length() => matrix.dim(0);
        /// <summary>
        /// Returns the dot product of two vector objects.
        /// </summary>
        /// <param name="vector1">First Vector</param>
        /// <param name="vector2">Second Vector</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown if the vectors have a different length.</exception>
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
        /// <summary>
        /// Calculates the magnitude of the vector.
        /// </summary>
        /// <returns></returns>
        public double Magnitude()
        {
            double sumOfSquares = 0;
            for (int i = 0; i < this.Length(); i++)
            {
                sumOfSquares += Math.Pow(this[i], 2);
            }
            return Math.Sqrt(sumOfSquares);
        }
        /// <summary>
        /// Calculates the angle between two given vectors, in degrees.
        /// </summary>
        /// <param name="vector1">First Vector</param>
        /// <param name="vector2">Second Vector</param>
        /// <returns></returns>
        public static double AngleBetweenVectors(Vector vector1, Vector vector2)
        {
            double dotProduct = Vector.Dot(vector1, vector2);
            double CosineOfAngle = dotProduct / (vector1.Magnitude() * vector2.Magnitude());
            return Math.Acos(CosineOfAngle) * 180/Math.PI;
        }
        /// <summary>
        /// Returns a string representing the current object, using an expression of the basic vectors.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException">Vectors of length > 3 are not currently supported.</exception>
        public override string ToString() 
        {
            if (this.Length() == 1) return $"{this[0]}i";
            if (this.Length() == 2) return $"{this[0]}i+{this[1]}j";
            if (this.Length() == 3) return $"{this[0]}i+{this[1]}j+{this[2]}k";
            else throw new NotImplementedException("Haven't implemented ToString() for vectors of a length > 3.");
        }
        public static implicit operator String(Vector v1) => v1.ToString();
    }
}
