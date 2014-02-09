using Machine.Specifications;

namespace Either.Tests {
    [Subject(typeof (Either))]
    public class When_I_return_a_left_as_either_of_string_or_int {
        static Either<string, int> _either;

        Because of = () => _either = "test";

        It should_contain_the_string_test =
            () => _either.Match(s => s, i => "").ShouldEqual("test");

        It should_return_a_left =
            () => _either.IsLeft.ShouldBeTrue();
    }
}