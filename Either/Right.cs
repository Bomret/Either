using System;

namespace Either {
    public sealed class Right<T> {
        public Right(T value) {
            Value = value;
        }

        public T Value { get; private set; }
    }

    sealed class Right<A, B> : Either<A, B> {
        public Right(B value) {
            Value = value;
        }

        public B Value { get; private set; }

        public override bool IsLeft {
            get { return false; }
        }

        public override bool IsRight {
            get { return true; }
        }

        public override C Match<C>(Func<A, C> ifLeft, Func<B, C> ifRight) {
            return ifRight(Value);
        }
    }
}