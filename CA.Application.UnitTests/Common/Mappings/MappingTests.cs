using AutoMapper;
using CA.Application.TodoLists.Queries.GetTodoLists;
using CA.Domain.Entities;
using System;
using Xunit;

namespace CA.Application.UnitTests.Common.Mappings
{
    public class MappingTests : IClassFixture<MappingFixture>
    {
        private readonly IMapper _mapper;

        public MappingTests(MappingFixture fixture)
        {
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void ShouldHaveValidConfiguration()
        {
            _mapper
                .ConfigurationProvider
                .AssertConfigurationIsValid();
        }

        [Theory]
        [InlineData(typeof(TodoList), typeof(TodoListDto))]
        [InlineData(typeof(TodoItem), typeof(TodoItemDto))]
        public void ShouldSupportMappingFromSourceToDestination
            (Type source, Type destination)
        {
            var instance = Activator.CreateInstance(source);

            _mapper.Map(instance, source, destination);
        }
    }
}
