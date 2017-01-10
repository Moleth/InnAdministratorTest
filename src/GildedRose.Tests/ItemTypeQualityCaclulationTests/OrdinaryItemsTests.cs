using GildedRose.Tests.TestFixtures;
using Xunit;
using Xunit.Abstractions;

namespace GildedRose.Tests
{
    [Collection("Gilded Rose tests")]
    [Trait("ItemTypeQualityCalculation", "Ordinary")]
    public class OrdinaryItemsTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        private readonly InnAdministratorFixture _innAdministratorFixture;

        public OrdinaryItemsTests(ITestOutputHelper testOutputHelper, InnAdministratorFixture innAdministratorFixture)
        {
            _innAdministratorFixture = innAdministratorFixture;
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void ShouldNotHaveQualityLessThanZero()
        {
            int result = _innAdministratorFixture._innAdministrator.CalculateOrdinaryItemQuality(-1, 15);

            Assert.True(result == 0);
        }

        [Fact]
        public void QualityShouldDecreaseByOneIfSellInHasNotPassed()
        {


            int result = _innAdministratorFixture._innAdministrator.CalculateOrdinaryItemQuality(5, 15);

            Assert.True(result == 4);
        }

        [Fact]
        public void QualityShouldDecreaseByTwoIfSellInIHasPassedAndQualityIsGreaterThanOne()
        {
            int result = _innAdministratorFixture._innAdministrator.CalculateOrdinaryItemQuality(5, -1);

            Assert.True(result == 3);
        }

        [Fact]
        public void QualityShouldDecreaseByOnlyOneIfSellHasPassedAndQualityIsOne()
        {
            int result = _innAdministratorFixture._innAdministrator.CalculateOrdinaryItemQuality(1, -1);

            Assert.True(result == 0);
        }

        [Fact]
        public void QualityShouldNeverBeMoreThanFiftyRegardLessOfSellIn()
        {
            int result = _innAdministratorFixture._innAdministrator.CalculateOrdinaryItemQuality(55, -1);

            Assert.True(result == 50);
        }

        [Fact]
        public void QualityShouldDecreaseToNoMoreThanFiftyIfSellInHasNotPassed()
        {
            int result = _innAdministratorFixture._innAdministrator.CalculateOrdinaryItemQuality(51, 1);

            Assert.True(result == 50);
        }

        [Fact]
        public void QualityShouldDecreaseToFortyNineIfSellInHasPassedAndQualityIsFiftyOne()
        {
            int result = _innAdministratorFixture._innAdministrator.CalculateOrdinaryItemQuality(51, -1);

            Assert.True(result == 49);
        }
    }
}
