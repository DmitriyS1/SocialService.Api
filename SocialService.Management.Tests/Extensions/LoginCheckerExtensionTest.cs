using SocialService.Management.Extensions;
using System.Text;
using Xunit;

namespace SocialService.Management.Tests.Extensions
{
    public class LoginCheckerExtensionTest
    {
        [Theory]
        [InlineData("user login")]
        [InlineData("u s e r")]
        public void UserLogin_ShouldBeValid_WhenContainsOnlyLettersAndSpaces(string login)
        {
            var result = login.IsLoginCorrect();

            Assert.True(result);
        }

        [Theory]
        [InlineData("121231")]
        [InlineData("u1s2e2r")]
        [InlineData(" ")]
        [InlineData("__asdasf __ ")]
        [InlineData("$$ ***")]
        public void UserLogin_ShouldBeInvalid_WhenContainsNumbersAndSymbols(string login)
        {
            var result = login.IsLoginCorrect();

            Assert.True(!result);
        }

        [Fact]
        public void UserLogin_ShouldBeInvalid_WhenLengthGreater64Symbols()
        {
            var sb = new StringBuilder();
            for (var i = 64; i >=0; i--)
            {
                sb.Append('g');
            }

            var login = sb.ToString();
            var result = login.IsLoginCorrect();

            Assert.True(!result);
        }
    }
}
