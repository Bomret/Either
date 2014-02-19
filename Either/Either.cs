using System;

namespace Either {
    public abstract class Either<A, B> {
        public abstract void Match(Action<A> ifLeft, Action<B> ifRight);
        public abstract C Match<C>(Func<A, C> ifLeft, Func<B, C> ifRight);

        public static implicit operator Either<A, B>(A leftValue) {
            return new Left<A, B>(leftValue);
        }

        public static implicit operator Either<A, B>(B rightValue) {
            return new Right<A, B>(rightValue);
        }
}
}