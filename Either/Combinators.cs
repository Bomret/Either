using System;

namespace Either {
    public static class Combinators {
        public static Either<B, A> Swap<A, B>(this Either<A, B> either) {
            return either.Match<Either<B, A>>(a => a,
                                              b => b);
        }

        public static Either<C, B> MapLeft<A, B, C>(this Either<A, B> either, Func<A, C> f) {
            return either.Match<Either<C, B>>(a => f(a),
                                              b => b);
        }

        public static Either<C, B> FlatMapLeft<A, B, C>(this Either<A, B> either, Func<A, Either<C, B>> f) {
            return either.Match(f, b => b);
        }

        public static Either<A, C> MapRight<A, B, C>(this Either<A, B> either, Func<B, C> f) {
            return either.Match<Either<A, C>>(a => a,
                                              b => f(b));
        }

        public static Either<A, C> FlatMapRight<A, B, C>(this Either<A, B> either, Func<B, Either<A, C>> f) {
            return either.Match(a => a, f);
        }

        public static Either<A, B> LeftOrElse<A, B>(this Either<A, B> either, A alternative) {
            return either.Match<Either<A, B>>(a => a, _ => alternative);
        }

        public static Either<A, B> LeftOrElseWith<A, B>(this Either<A, B> either, Either<A, B> alternative) {
            return either.Match(a => a, _ => alternative);
        }

        public static Either<A, B> RightOrElse<A, B>(this Either<A, B> either, B alternative) {
            return either.Match<Either<A, B>>(_ => alternative, b => b);
        }

        public static Either<A, B> RightOrElseWith<A, B>(this Either<A, B> either, Either<A, B> alternative) {
            return either.Match(_ => alternative, b => b);
        }
    }
}