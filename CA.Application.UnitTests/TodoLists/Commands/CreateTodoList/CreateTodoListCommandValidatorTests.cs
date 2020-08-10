using CA.Application.TodoLists.Commands.CreateTodoList;
using CA.Infrastructure.Persistence;
using Shouldly;
using Xunit;

namespace CA.Application.UnitTests.TodoLists.Commands.CreateTodoList
{
    public class CreateTodoListCommandValidatorTests : TestFixture
    {
        private readonly ApplicationDbContext _context;

        public CreateTodoListCommandValidatorTests()
        {
            _context = Context;
        }

        [Fact]
        public void IsValid_ShouldBeTrue_WhenListTitleIsUnique()
        {
            var command = new CreateTodoListCommand
            {
                Title = "Bucket List"
            };

            var validator = new CreateTodoListCommandValidator(_context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void IsValid_ShouldBeFalse_WhenListTitleIsNotUnique()
        {
            var command = new CreateTodoListCommand
            {
                Title = "Todo List"
            };

            var validator = new CreateTodoListCommandValidator(_context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(false);
        }
    }
}
