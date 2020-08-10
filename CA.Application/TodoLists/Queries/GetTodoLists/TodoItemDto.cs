using AutoMapper;
using CA.Application.Common.Mappings;
using CA.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace CA.Application.TodoLists.Queries.GetTodoLists
{
    public class TodoItemDto : IMapFrom<TodoItem>
    {
        public long Id { get; set; }

        public int ListId { get; set; }

        public string Title { get; set; }

        public bool Done { get; set; }

        public int Priority { get; set; }

        public string Note { get; set; }
    }

}
