using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace further_maths
{
    internal class Matrix
    {
        private double[,] matrix;

        public Matrix(int rows, int columns)
        {
            if (rows < 1 || columns < 1) throw new ArgumentException("Matrices cannot have zero or negative order.");

            this.matrix = new double[rows, columns];
            
            for (int row = 0; row < rows; row++)            {
                for (int col = 0; col < columns; col++)
                {
                    this.matrix[row, col] = 0; // initiliases as the zero matrix
                }
            }
        }

        public double this[int row, int col]
        {
            get { return matrix[row, col]; }
            set { matrix[row, col] = value; }
        }

        // constants

        /// <summary>
        /// Returns an identity matrix of the given size.
        /// </summary>
        /// <param name="size">The size of the identity</param>
        /// <returns></returns>
        public static Matrix Identity(int size)
        {
            if (size < 1) throw new ArgumentException("Matrices cannot have zero or negative order.");
            Matrix identity = new Matrix(size, size);
            for (int i = 0; i < size; i++)
            {
                identity[i, i] = 1;
            }
            return identity;
        }


        // conversions

        /// <summary>
        /// Converts the current object to the vector class, provided it has nx1 order.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="DimensionMismatch"></exception>
        public Vector ToVector()
        {
            if (matrix.GetLength(1) != 1) throw new ArgumentException("Matrices can only be converted to a vector if they have order nx1.");

            Vector vector = new Vector(matrix.GetLength(0));
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                vector[i] = matrix[i, 1];
            }
            return vector;
        }


        // operators

        /// <summary>
        /// Add two matrixes together
        /// </summary>
        /// <param name="m1">First Matrix</param>
        /// <param name="m2">Second Matrix</param>
        /// <returns></returns>
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (m1.dim(0) != m2.dim(0) || m1.dim(1) != m2.dim(1)) throw new ArgumentException("To add matrices they must have the same order.");

            Matrix result = new Matrix(m1.dim(0), m2.dim(1));
            for (int row = 0; row < m1.dim(0); row++)
            {
                for (int col = 0; col < m1.dim(1); col++)
                {
                    result[row, col] = m1[row, col] + m2[row, col];
                }
            }
            return result;
        }

        /// <summary>
        /// Subtract one matrix from another. Must have equal dimensions.
        /// </summary>
        /// <param name="m1">The Matrix</param>
        /// <param name="m2">The Matrix to subtract</param>
        /// <returns></returns>
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            if (m1.dim(0) != m2.dim(0) || m1.dim(1) != m2.dim(1)) throw new ArgumentException("To subtract matrices they must have the same order.");

            Matrix result = new Matrix(m1.dim(0), m2.dim(1));
            for (int row = 0; row < m1.dim(0); row++)
            {
                for (int col = 0; col < m1.dim(1); col++)
                {
                    result[row, col] = m1[row, col] - m2[row, col];
                }
            }
            return result;
        }

        /// <summary>
        /// Multiply two matrices together.
        /// </summary>
        /// <param name="m1">The Matrix</param>
        /// <param name="m2">The Matrix it is multiplied by</param>
        /// <returns></returns>
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1.dim(1) != m2.dim(0)) throw new ArgumentException("To multiply matrices of order i*j and k*l, to multiply j must equal k");

            Matrix result = new Matrix(m1.dim(0), m2.dim(1));
            for (int row = 0; row < result.dim(0); row++)
            {
                for (int col = 0; col < result.dim(1); col++)
                {
                    double value = 0;
                    for (int i = 0; i < m1.dim(0); i++)
                    {
                        value += m1[row, i] * m2[i, col];
                    }
                    result[row, col] = value;
                }
            }
            return result;
        }

        /// <summary>
        /// Multiply a matrix by a scalar value.
        /// </summary>
        /// <param name="scal">The scalar value</param>
        /// <param name="m1">The matrix</param>
        /// <returns></returns>
        public static Matrix operator *(double scal, Matrix m1)
        {
            Matrix result = new Matrix(m1.dim(0), m1.dim(1));
            for (int row = 0; row < m1.dim(0); row++)
            {
                for (int col = 0; col < m1.dim(1); col++)
                {
                    result.matrix[row, col] = m1.matrix[row, col] * scal;
                }
            }

            return result;
        }

        public static implicit operator Matrix(Vector value) => value.ToMatrix();


        // matrix properties 

        /// <summary>
        /// Find the dimensions of the matrix.
        /// </summary>
        /// <param name="dimension">The dimension to return</param>
        /// <returns></returns>
        public int dim(int dimension) => matrix.GetLength(dimension);

        /// <summary>
        /// Find the determent of the matrix
        /// </summary>
        /// <returns></returns>
        public double det()
        {
            if (!this.isSquare()) throw new ArgumentException("Non-square matrices do not have a determinant.");

            // for 1x1 matrix
            if (matrix.GetLength(0) == 1) return matrix[0, 0];

            // for 2x2 matrix
            if (matrix.GetLength(0) == 2) return matrix[0, 0] * matrix[1, 1] - matrix[1, 0] * matrix[0, 1];

            // for dim > 2 matrices
            throw new NotImplementedException("Matrix determinants of matrices larger than 2x2 size are not implemented.");
        }

        /// <summary>
        /// Find the inverse of the matrix
        /// </summary>
        /// <returns></returns>
        public Matrix inverse()
        {
            if (this.det() == 0) throw new ArgumentException("Singular matrices do not have an inverse.");
            if (!this.isSquare()) throw new ArgumentException("Non-square matrices do not have a determinant.");
            if (this.dim(0) > 2) throw new NotImplementedException("Matrix inverse and determinants are not implemented for matrices larger than 2x2.");
            
            Matrix result = new Matrix(matrix.GetLength(0), matrix.GetLength(1));
            if (matrix.GetLength(0) == 2)
            {
                result[0, 0] = matrix[1, 1];
                result[1, 1] = matrix[0, 0];
                result[0, 1] = -1 * matrix[0, 1];
                result[1, 0] = -1 * matrix[1, 0];
                result = (1 / this.det()) * result;
            }
            return result;
        }

        /// <summary>
        /// Returns a boolean depending on whether the matrix is square.
        /// </summary>
        /// <returns></returns>
        public bool isSquare() => this.dim(0) == this.dim(1);
    }
}
