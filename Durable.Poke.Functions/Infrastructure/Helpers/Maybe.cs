using System;

namespace Durable.Poke.Functions.Infrastructure.Helpers
{
    public struct Maybe<T> : IEquatable<Maybe<T>>
    {
        private readonly T _value;

        public T Value
        {
            get
            {
                if (HasNoValue)
                    throw new InvalidOperationException("Maybe has no value");

                return _value;
            }
        }

        public static Maybe<T> None => new Maybe<T>();

        public bool HasValue => _value != null;
        public bool HasNoValue => !HasValue;

        private Maybe(T value)
        {
            _value = value;
        }

        public static implicit operator Maybe<T>(T value)
        {
            return new Maybe<T>(value);
        }

        public static Maybe<T> From(T obj)
        {
            return new Maybe<T>(obj);
        }

        public static bool operator ==(Maybe<T> maybe, T value)
        {
            if (maybe.HasNoValue)
                return false;

            return maybe.Value.Equals(value);
        }

        public static bool operator !=(Maybe<T> maybe, T value)
        {
            return (maybe == value) == false;
        }

        public static bool operator ==(Maybe<T> first, Maybe<T> second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Maybe<T> first, Maybe<T> second)
        {
            return (first == second) == false;
        }

        public override bool Equals(object obj)
        {
            if (obj is T)
                obj = new Maybe<T>((T)obj);

            if ((obj is Maybe<T>) == false)
                return false;

            var other = (Maybe<T>)obj;
            return Equals(other);
        }

        public bool Equals(Maybe<T> other)
        {
            if (HasNoValue && other.HasNoValue)
                return true;

            if (HasNoValue || other.HasNoValue)
                return false;

            return _value.Equals(other._value);
        }

        public override int GetHashCode()
        {
            if (HasNoValue)
                return 0;

            return _value.GetHashCode();
        }

        public override string ToString()
        {
            if (HasNoValue)
                return "No value";

            return Value.ToString();
        }
    }
}
