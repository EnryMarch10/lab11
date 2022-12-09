using ComplexAlgebra;
using System;
using System.Collections.Generic;

namespace Calculus
{
    /// <summary>
    /// A calculator for <see cref="Complex"/> numbers, supporting 2 operations ('+', '-').
    /// The calculator visualizes a single value at a time.
    /// Users may change the currently shown value as many times as they like.
    /// Whenever an operation button is chosen, the calculator memorises the currently shown value and resets it.
    /// Before resetting, it performs any pending operation.
    /// Whenever the final result is requested, all pending operations are performed and the final result is shown.
    /// The calculator also supports resetting.
    /// </summary>
    ///
    /// HINT: model operations as constants
    /// HINT: model the following _public_ properties methods
    /// HINT: - a property/method for the currently shown value
    /// HINT: - a property/method to let the user request the final result
    /// HINT: - a property/method to let the user reset the calculator
    /// HINT: - a property/method to let the user request an operation
    /// HINT: - the usual ToString() method, which is helpful for debugging
    /// HINT: - you may exploit as many _private_ fields/methods/properties as you like
    ///
    /// TODO: implement the calculator class in such a way that the Program below works as expected
    class Calculator
    {
        private bool enabled;
        private Complex _value;
        private IList<Tuple<Complex, char>> _values = new List<Tuple<Complex, char>>();

        public Complex Value
        {
            get => _value;
            set
            {
                enabled = true;
                _value = value;
            }
        }
        public char Operation
        {
            set
            {
                if (enabled && (value.Equals(OperationPlus) || value.Equals(OperationMinus) || value.Equals(OperationEqual)))
                {
                    _values.Add(new Tuple<Complex, char>(_value, value));
                    enabled = false;
                }
            }
        }

        public const char OperationEqual = '=';
        public const char OperationPlus = '+';
        public const char OperationMinus = '-';

        public void ComputeResult()
        {
            if ((_values.Count > 0) && _values[_values.Count - 1].Item2.Equals(OperationEqual))
            {
                _value = _values[0].Item1;
                for(int i = 0; i < _values.Count - 1; i++)
                {
                    if (_values[i].Item2.Equals(OperationPlus))
                    {
                        _value = _value.Plus(_values[i + 1].Item1);
                    }
                    else
                    {
                        _value = _value.Minus(_values[i + 1].Item1);
                    }
                }
                _values.Clear();
                enabled = false;
            }
        }

        public void Reset()
        {
            _values.Clear();
            _value = null;
            enabled = false;
        }

        public override string ToString()
        {
            if (enabled && (_value != null) && (_values.Count > 0))
            {
                return _value + ", " + _values[_values.Count - 1].Item2;
            }
            else if (_values.Count > 0)
            {
                return "null, " + _values[_values.Count - 1].Item2;
            }
            else if (_value != null)
            {
                return _value + ", null";
            }
            return "null, null";
        }
    }
}