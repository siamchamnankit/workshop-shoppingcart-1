using System;
using System.Threading.Tasks;
using api.IntegrationTest.Fixtures;
using api.Models;
using Newtonsoft.Json;
using Xunit;

namespace api.IntegrationTest
{
    [Collection("SystemCollection")]
    public class ValuesTest
    {
        private readonly TestContext _context;

        public ValuesTest(TestContext context)
        {
            _context = context;
        }
        
        [Fact]
        public async Task Get_Values()
        {
            var response = await _context.Client.GetAsync("/api/values");
            Object repositories = JsonConvert.DeserializeObject<Object>(response.Content.ReadAsStringAsync().Result);
            
            response.EnsureSuccessStatusCode();

            Assert.Equal("OK", response.StatusCode.ToString());
        }
    }
}

