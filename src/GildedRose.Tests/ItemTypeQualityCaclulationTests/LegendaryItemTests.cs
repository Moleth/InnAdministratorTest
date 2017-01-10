using GildedRose.Tests.TestFixtures;
using Xunit;
using Xunit.Abstractions;

namespace GildedRose.Tests
{
    [Collection("Gilded Rose tests")]
    [Trait("ItemTypeQualityCalculation", "Legendary")]
    public class LegendaryItemTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        private readonly InnAdministratorFixture _innAdministratorFixture;
        
        public LegendaryItemTests(ITestOutputHelper testOutputHelper, InnAdministratorFixture innAdministratorFixture)
        {
            _innAdministratorFixture = innAdministratorFixture;
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void ShouldNeverHaveAQualityLessThanZero()
        {
            int result = _innAdministratorFixture._innAdministrator.CalculateLegendaryItemQuality(-1, 1);

            Assert.True(result == 0);
        }

        [Fact]
        public void ShouldNeverHaveItsQualityChanged()
        {
            int result = _innAdministratorFixture._innAdministrator.CalculateLegendaryItemQuality(80, 1);

            Assert.True(result == 80);
        }
    }
}
