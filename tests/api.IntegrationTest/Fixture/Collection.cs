using Xunit;

namespace api.IntegrationTest.Fixtures
{
    [CollectionDefinition("SystemCollection")]
    public class Collection : ICollectionFixture<TestContext>
    {
        
    }
}