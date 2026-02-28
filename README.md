# Further Maths Library

A C# libary containing classes for matrices, vectors, complex numbers and fractions.

## Matrices
Class: ```Matrix```

Uses an array of doubles to store a matrix, with support for standard operations ( + , - , * ) and square bracket indexing.
### Functions
```.det()``` - Finds the determinant of a square matrix. (note: not implemented for anything larger than 2x2)

```.inverse()``` - Finds the inverse of the matrix.

```.IsSquare()``` - Returns true or false depending on whether the matrix is square.

```.dim( int: dimension )``` - returns the Length of the matrix in the specified dimension.

```.ToVector()``` - Converts any nx1 matrix into a vector.


## Vectors
Class: ```Vector```

Uses a matrix of nx1 order to represent a matrix, with support for standard operations ( + , - ) and square bracket indexing.
### Functions

```.Length()``` - Returns the length of the given vector.

```.ToMatrix()``` - Converts the vector into a matrix object.

```.Magnitude()``` - Returns the magnitude of the vector.

```Dot( Vector: vector1, Vector: vector2 )``` - Returns the dot product between 2 vectors.

```AngleBetweenVectors( Vector: vector1, Vector: vector2 )``` -  Returns the angle between 2 vectors in Degrees.

## Complex Numbers 
Class: ```ComplexNum```

Stores a complex number as a double for the ℝ Part and a double for the 𝕀 Part, with support for standard operations ( + , - , * , / ).
### Functions 

```.conjugate()``` - Returns the complex conjugate of the complex number.

```.modulus()``` - returns the modulus of the complex number.

```.argument()``` - returns the argument of the complex number.

```.ToString()``` - converts the complex number into a string. e.g. 2+3i

```Pow( ComplexNum: num, double: power )``` - calulcates the number to a power, with the output as a complex number. (note: currently not accurate)

```Sqrt( ComplexNum/double: num )``` - returns the square root of the number as a complex number.

## Rational Numbers / Fractions
Class: ```Rational```

Stores a rational number as a ratio between 2 integers (numerator and denominator) with support for standard operations ( + , - , * , / ).
### Functions

```.Reciprocal()``` - Returns the reciprocal of the number.

```.ToDouble()``` - returns the corresponding double value of the number.

```.ToString()``` - Returns the string representing the number. e.g. 3/4

```DoubleToRational( double: num )``` - converts the input double into a fraction.
