using CA.Application.TodoLists.Commands.CreateTodoList;
using CA.Infrastructure.Persistence;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CA.Application.UnitTests.TodoLists.Commands.CreateTodoList
{
    public class CreateTodoListCommandTests : TestFixture
    {
        private readonly ApplicationDbContext _context;

        public CreateTodoListCommandTests()
        {
            _context = DbContextFactory.Create();
        }

        [Fact]
        public async Task Handle_ShouldPersistTodoList()
        {
            var command = new CreateTodoListCommand
            {
                Title = "Bucket List"
            };

            var handler = new CreateTodoListCommandHandler(_context);

            var result = await handler.Handle(command,
                CancellationToken.None);

            var entity = _context.TodoLists.Find(result);

            entity.ShouldNotBeNull();
            entity.Title.ShouldBe(command.Title);
        }
    }
}
