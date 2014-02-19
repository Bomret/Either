using System;

namespace Either {
    sealed class Left<A, B> : Either<A, B> {
        readonly A _value;

        public Left(A value) {
            _value = value;
        }

        public override void Match(Action<A> ifLeft, Action<B> ifRight) {
            ifLeft(_value);
        }

        public override C Match<C>(Func<A, C> ifLeft, Func<B, C> ifRight) {
            return ifLeft(_value);
        }
    }
}