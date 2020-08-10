using CA.Application.TodoLists.Commands.CreateTodoList;
using CA.Application.TodoLists.Commands.DeleteTodoList;
using CA.Application.TodoLists.Commands.UpdateTodoList;
using CA.Application.TodoLists.Queries.GetTodoLists;
using CA.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;


namespace CA.WebUI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoListsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/TodoLists
        [HttpGet]
        public async Task<ActionResult<TodosVm>> GetTodoList()
        {
            return await _mediator.Send(new GetTodoListsQuery());
        }

        // PUT: api/TodoLists/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoList(int id, UpdateTodoListCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command);

            return NoContent();
        }

        // POST: api/TodoLists
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<int>> PostTodoList(CreateTodoListCommand command)
        {
            return await _mediator.Send(command);
        }

        // DELETE: api/TodoLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoList(int id)
        {
            await _mediator.Send(new DeleteTodoListCommand { Id = id });

            return NoContent();
        }
    }
}