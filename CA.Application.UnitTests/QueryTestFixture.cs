using Xunit;

namespace CA.Application.UnitTests
{
    [CollectionDefinition(nameof(QueryCollection))]
    public class QueryCollection
       : ICollectionFixture<TestFixture>
    { }
}
