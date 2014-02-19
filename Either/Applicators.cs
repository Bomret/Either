using System;

namespace Either {
    public static class Applicators {
        public static bool IsLeft<A, B>(this Either<A, B> either) {
            return either.Match(_ => true, _ => false);
        }

        public static bool IsRight<A, B>(this Either<A, B> either) {
            return either.Match(_ => false, _ => true);
        }

        public static void IfLeft<A, B>(this Either<A, B> either, Action<A> ifLeft) {
            either.Match(ifLeft, _ => { });
        }

        public static void IfRight<A, B>(this Either<A, B> either, Action<B> ifRight) {
            either.Match(_ => { }, ifRight);
        }

        public static A GetLeft<A, B>(this Either<A, B> either) {
            return either.Match(a => a,
                                _ => { throw new InvalidOperationException("This either does not have a left value."); });
        }

        public static A GetLeftOr<A, B>(this Either<A, B> either, A alternative) {
            return either.Match(a => a, _ => alternative);
        }

        public static A GetLeftOrDefault<A, B>(this Either<A, B> either) {
            return either.Match(a => a, _ => default(A));
        }

        public static B GetRight<A, B>(this Either<A, B> either) {
            return
                either.Match(_ => { throw new InvalidOperationException("This either does not have a right value."); },
                             b => b);
        }

        public static B GetRightOr<A, B>(this Either<A, B> either, B alternative) {
            return either.Match(_ => alternative, b => b);
        }

        public static B GetRightOrDefault<A, B>(this Either<A, B> either) {
            return either.Match(_ => default(B), b => b);
        }
    }
}