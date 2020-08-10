using CA.Domain.Entities;
using System.Linq;

namespace CA.Infrastructure.Persistence
{
    public class ApplicationDbContextSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (context.TodoLists.Any())
            {
                return;
            }

            var list = new TodoList
            {
                Title = "Todo List",
                Items =
                {
                    new TodoItem { Title = "Make a todo list" },
                    new TodoItem { Title = "Check off the first item" },
                    new TodoItem { Title = "Realise you've already done two things on the list!"},
                    new TodoItem { Title = "Reward yourself with a nice, long nap" },
                }
            };

            context.TodoLists.Add(list);
            context.SaveChanges();
        }
    }
}