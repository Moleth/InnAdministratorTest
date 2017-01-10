using GildedRose.Tests.TestFixtures;
using Xunit;
using Xunit.Abstractions;

namespace GildedRose.Tests
{
    [Collection("Gilded Rose tests")]
    [Trait("ItemTypeQualityCalculation", "Conjured")]
    public class ConjuredItemsTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        private readonly InnAdministratorFixture _innAdministratorFixture;
        
        public ConjuredItemsTests(ITestOutputHelper testOutputHelper, InnAdministratorFixture innAdministratorFixture)
        {
            _innAdministratorFixture = innAdministratorFixture;
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void ShouldNotHaveQualityLessThanZero()
        {
            int result = _innAdministratorFixture._innAdministrator.CalculateConjuredItemQuality(-1, 1);

            Assert.True(result == 0);
        }

        [Fact]
        public void QualityShouldDecreaseByTwoIfSellInHasNotPassed()
        {
            int result = _innAdministratorFixture._innAdministrator.CalculateConjuredItemQuality(5, 15);

            Assert.True(result == 3);
        }

        [Fact]
        public void QualityShouldDecreaseByFourIfSellInHasPassed()
        {
            int result = _innAdministratorFixture._innAdministrator.CalculateConjuredItemQuality(5, -1);

            Assert.True(result == 1);
        }

        [Fact]
        public void QualityShouldDecreaseByOnlyOneIfSellInHasNotPassedAndQualityIsOne()
        {
            int result = _innAdministratorFixture._innAdministrator.CalculateConjuredItemQuality(1, 1);

            Assert.True(result == 0);
        }

        [Fact]
        public void QualityShouldDecreaseByOnlyThreeIfSellInIsHasPassedAndQualityIsThree()
        {
            int result = _innAdministratorFixture._innAdministrator.CalculateConjuredItemQuality(3, -1);

            Assert.True(result == 0);
        }

        [Fact]
        public void QualityShouldNeverBeMoreThanFiftyRegardLessOfSellIn()
        {
            int result = _innAdministratorFixture._innAdministrator.CalculateConjuredItemQuality(55, -1);

            Assert.True(result == 50);
        }

        [Fact]
        public void QualityShouldDecreaseToFourtyNineIfSellInHasNotPassedAndQualityIsFiftyOne()
        {
            int result = _innAdministratorFixture._innAdministrator.CalculateConjuredItemQuality(51, 1);

            Assert.True(result == 49);
        }

        [Fact]
        public void QualityShouldDecreaseToFortyNineIfSellInHasPassedAndQualityIsFiftyThree()
        {
            int result = _innAdministratorFixture._innAdministrator.CalculateConjuredItemQuality(53, -1);

            Assert.True(result == 49);
        }
    }
}
