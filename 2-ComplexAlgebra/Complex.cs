using System;
using System.Collections.Generic;

namespace ComplexAlgebra
{
    /// <summary>
    /// A type for representing Complex numbers.
    /// </summary>
    ///
    /// TODO: Model Complex numbers in an object-oriented way and implement this class.
    /// TODO: In other words, you must provide a means for:
    /// TODO: * instantiating complex numbers
    /// TODO: * accessing a complex number's real, and imaginary parts
    /// TODO: * accessing a complex number's modulus, and phase
    /// TODO: * complementing a complex number
    /// TODO: * summing up or subtracting two complex numbers
    /// TODO: * representing a complex number as a string or the form Re +/- iIm
    /// TODO:     - e.g. via the ToString() method
    /// TODO: * checking whether two complex numbers are equal or not
    /// TODO:     - e.g. via the Equals(object) method
    public class Complex
    {
        public Complex(double real, double immaginary)
        {
            this.Real = real;
            this.Imaginary = immaginary;
        }
    
        public double Real { get; private set; }
        public double Imaginary { get; private set; }

        public double Modulus => Math.Sqrt(Math.Pow(Real, 2) + Math.Pow(Imaginary, 2));
        public double Phase => Math.Atan2(Imaginary, Real);

        public Complex Complement => new Complex(Real, -Imaginary);

        public Complex Plus(Complex c)
            => new Complex(this.Real + c.Real, this.Imaginary + c.Imaginary);

        public Complex Minus(Complex c)
            => new Complex(this.Real - c.Real, this.Imaginary - c.Imaginary);

        public override string ToString()
        {
            if ((Real == 0) && (Imaginary == 0))
            {
                return "0";
            }
            else if (Real == 0)
            {
                return Math.Abs(Imaginary) != 1 ? Imaginary + "i": Imaginary < 0 ? "-i": "i";
            }
            else if (Imaginary == 0)
            {
                return Real.ToString();
            }
            double imaginary = Math.Abs(Imaginary);
            return Real + " " + (Math.Sign(Imaginary) < 0.0 ? "-": "+") + " " + (imaginary != 1 ? imaginary + "i": "i");
        }

        public override bool Equals(object obj)
            => obj is Complex complex &&
                   Real == complex.Real &&
                   Imaginary == complex.Imaginary;

        public override int GetHashCode()
            => HashCode.Combine(Real, Imaginary);
    }
}