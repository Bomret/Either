using Machine.Specifications;

namespace Either.Tests {
    [Subject(typeof (Either))]
    public class When_I_return_a_right_as_either_of_string_or_int {
        static Either<string, int> _either;

        Because of = () => _either = 2;

        It should_contain_the_int_two =
            () => _either.Match(s => 0, i => i).ShouldEqual(2);

        It should_return_a_right =
            () => _either.IsRight.ShouldBeTrue();
    }
}