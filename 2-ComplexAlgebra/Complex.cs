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
        public double Phase => Math.Atan2(Real, Imaginary);

        public Complex Complement => new Complex(-Real, -Imaginary);

        public Complex Plus(Complex c)
            => new Complex(this.Real + c.Real, this.Imaginary + c.Imaginary);

        public Complex Minus(Complex c)
            => new Complex(this.Real - c.Real, this.Imaginary - c.Imaginary);

        public override string ToString() 
            => String.Format("{0}{1}", 
                Real != 0 ? Real + " ": String.Empty,
                String.Concat(
                    (Imaginary != 0.0 ? 
                    ((Math.Sign(Imaginary) < 0.0 ? "-": "+") + " " 
                    + Math.Abs(Imaginary) + "i"): String.Empty)));

        public override bool Equals(object obj)
            => obj is Complex complex &&
                   Real == complex.Real &&
                   Imaginary == complex.Imaginary;

        public override int GetHashCode()
            => HashCode.Combine(Real, Imaginary, Modulus, Phase, Complement);
    }
}