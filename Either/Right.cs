using System;

namespace Either {
    sealed class Right<A, B> : Either<A, B> {
        readonly B _value;

        public Right(B value) {
            _value = value;
        }

        public override void Match(Action<A> ifLeft, Action<B> ifRight) {
            ifRight(_value);
        }

        public override C Match<C>(Func<A, C> ifLeft, Func<B, C> ifRight) {
            return ifRight(_value);
        }
    }
}