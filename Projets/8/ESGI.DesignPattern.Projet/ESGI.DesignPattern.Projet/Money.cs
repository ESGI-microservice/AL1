using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Runtime.Serialization;

namespace ESGI.DesignPattern.Projet
{
    public class Money : INullable
    {
        private readonly decimal _value;

        public Money(int value) => this._value = value;

        public Money(decimal value) => this._value = value;

        public Money Add(Money other)
        {
            return new Money(_value + other._value);
        }

        public Money Percentage(int p)
        {
            return new Money(_value * p / 100);
        }

        public string Format()
        {
            return string.Format("{0:0.00}", _value);
        }

        internal decimal AsDecimal()
        {
            return _value;
        }

        public bool IsNull { get; }
    }
}
