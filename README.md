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

```Matrix.Identity( int: size )``` - Returns an identity matrix of the given size.


## Vectors
Class: ```Vector```

Uses a matrix of nx1 order to represent a matrix, with support for standard operations ( + , - ) and square bracket indexing.
### Functions

```.Length()``` - Returns the length of the given vector.

```.ToMatrix()``` - Converts the vector into a matrix object.

```.Magnitude()``` - Returns the magnitude of the vector.

```Vector.Dot( Vector: vector1, Vector: vector2 )``` - Returns the dot product between 2 vectors.

```Vector.AngleBetweenVectors( Vector: vector1, Vector: vector2 )``` -  Returns the angle between 2 vectors in Degrees.

## Complex Numbers 
Class: ```ComplexNum```

Stores a complex number as a double for the ℝ Part and a double for the 𝕀 Part, with support for standard operations ( + , - , * , / ).
### Constants 

```ComplexNum.I``` - outputs the value of the imaginary unit 'i'. (a complex number with no real part and an imaginary part of 1)

### Functions 

```.conjugate()``` - Returns the complex conjugate of the complex number.

```.modulus()``` - returns the modulus of the complex number.

```.argument()``` - returns the argument of the complex number.

```.ToString()``` - converts the complex number into a string. e.g. 2+3i

```ComplexNum.Pow( ComplexNum: num, double: power )``` - calulcates the number to a power, with the output as a complex number. (note: currently not accurate)

```ComplexNum.Sqrt( ComplexNum/double: num )``` - returns the square root of the number as a complex number.

## Rational Numbers / Fractions
Class: ```Rational```

Stores a rational number as a ratio between 2 integers (numerator and denominator) with support for standard operations ( + , - , * , / ).
### Functions

```.Reciprocal()``` - Returns the reciprocal of the number.

```.ToDouble()``` - returns the corresponding double value of the number.

```.ToString()``` - Returns the string representing the number. e.g. 3/4

```Rational.DoubleToRational( double: num )``` - converts the input double into a fraction.

## Polynomials
Class: ```Polynomial```

Stores a polynomial as an integer array where each index represents the coefficient of the equivalent power of x. The coefficients can be accessed via square bracket indexing.
### Functions

```.Evaluate( double: x )``` - Evaluate the expression given the specified value of x.

```.FindRoots()``` - Finds the solutions to the equation when f(x) = 0, including complex solutions via the ```ComplexNum``` class. (note: not implemented for polynomials of degree > 2)

```.Derivative()``` - Outputs the derivative of the function.

```.NthDerivative( int: n )``` - Outputs the result of differentiating a function n times.

```ToString()``` - Converts the polynomial into a string. e.g. 2x^2+3x+4
