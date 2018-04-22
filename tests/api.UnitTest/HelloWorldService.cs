using System;
using api.Services;
using Xunit;

namespace api.UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void When_One_Plus_One_Should_Be_Display_Tow()
        {
            decimal expected = 2;
            HelloWorldService helloWorldService = new HelloWorldService();
            decimal actual = helloWorldService.plus(1,1);

            Assert.Equal(expected, actual);
        }
    }

}
