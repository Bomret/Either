using System;

namespace Either {
    public static class Either {
        public static Left<T> Left<T>(T value) {
            return new Left<T>(value);
        }

        public static Right<T> Right<T>(T value) {
            return new Right<T>(value);
        }
    }

    public abstract class Either<A, B> {
        public abstract bool IsLeft { get; }
        public abstract bool IsRight { get; }

        public abstract C Match<C>(Func<A, C> ifLeft, Func<B, C> ifRight);

        public static implicit operator Either<A, B>(Left<A> left) {
            return new Left<A, B>(left.Value);
        }

        public static implicit operator Either<A, B>(A leftValue) {
            return new Left<A, B>(leftValue);
        }

        public static implicit operator Either<A, B>(Right<B> right) {
            return new Right<A, B>(right.Value);
        }

        public static implicit operator Either<A, B>(B rightValue) {
            return new Right<A, B>(rightValue);
        }
    }
}