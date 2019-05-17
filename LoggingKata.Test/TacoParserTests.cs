using System;
using Xunit;
using LoggingKata;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {

        [Theory]
        [InlineData("30.409891,-84.280756,Taco Bell Tallahassee/... (Free trial * Add to Cart for a full POI info)")]
        [InlineData("40.409891,-84.280756,Taco Bell Tallahassee/... (Free trial * Add to Cart for a full POI info)")]
        [InlineData("34.039588, -84.283254, Taco Bell Alpharetta/... (Free trial * Add to Cart for a full POI info)")]
        [InlineData("33.556383,-86.889051,Taco Bell Birmingha... (Free trial * Add to Cart for a full POI info)")]
        [InlineData("34.206722,-86.873404,Taco Bell Cullman/... (Free trial * Add to Cart for a full POI info)")]
        public void ShouldParse(string str)
        {
            // Arrange
            TacoParser tacop = new TacoParser();

            //Act
            ITrackable actual = tacop.Parse(str);

            //Assert
            Assert.NotNull(actual);

        }
        [Theory]
        [InlineData("")]
        public void ShouldFailParse(string str)
        {
            // TODO: Complete Should Fail Parse
        }
    }
}
