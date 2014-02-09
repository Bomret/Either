using System;

namespace Either {
    public sealed class Left<T> {
        public Left(T value) {
            Value = value;
        }

        public T Value { get; private set; }
    }

    sealed class Left<A, B> : Either<A, B> {
        public Left(A value) {
            Value = value;
        }

        public A Value { get; private set; }

        public override bool IsLeft {
            get { return true; }
        }

        public override bool IsRight {
            get { return false; }
        }

        public override C Match<C>(Func<A, C> ifLeft, Func<B, C> ifRight) {
            return ifLeft(Value);
        }
    }
}