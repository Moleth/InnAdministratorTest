using GildedRose.Tests.TestFixtures;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace GildedRose.Tests
{
    /*
    I have added this class as example that could be used with the commented [Theory] in the test class.
    What to be used should of course have to do with the tests at hand. I have chosen here to stick
    to [Fact] mainly because the ammount of tests is small but also because I prefer their readabillity
    in the test explorer. I did not find a way yet in XUnit 2 where the theory name would be changed for
    each theory executed :)
    */
    public class GuildedRoseBackstagePassTestData
    {
        //These values should probably be in an external source.
        public static IEnumerable<object[]> TestData
        {
            get
            {
                yield return new object[] { 25, -1, 0 };
                yield return new object[] { 25, 11, 26 };
                yield return new object[] { 25, 10, 27 };
                yield return new object[] { 25, 5, 28 };
                yield return new object[] { 49, 5, 50 };
                yield return new object[] { 49, 10, 50 };
                yield return new object[] { 49, 15, 50 };
            }
        }
    }

    [Collection("Gilded Rose tests")]
    [Trait("ItemTypeQualityCalculation", "Backstage pass")]
    public class BackstagePassesItemsTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        private readonly InnAdministratorFixture _innAdministratorFixture;

        public BackstagePassesItemsTests(ITestOutputHelper testOutputHelper, InnAdministratorFixture innAdministratorFixture)
        {
            _innAdministratorFixture = innAdministratorFixture;
            _testOutputHelper = testOutputHelper;
        }

        //Put here as an example of a [Theory] tha could replace several facts. The tests of this [Theory] as still also executed by the below [Fact]s.
        //Normally either the [Theory] or the [Fact]s should be used.
        [Theory]
        [MemberData("TestData", MemberType = typeof(GuildedRoseBackstagePassTestData))]
        public void CalculateAgedCheeseQuality(int quality, int sellIn, int expectedResult)
        {
            int result = _innAdministratorFixture._innAdministrator.CalculateBackstagePassItemQuality(quality, sellIn);

            Assert.True(result == expectedResult);
        }

        [Fact]
        public void ShouldNotHaveQualityOrEqualToZeroIfSellInHasNotPassed()
        {
            int result = _innAdministratorFixture._innAdministrator.CalculateBackstagePassItemQuality(-1, 1);

            Assert.True(result > 0);
        }

        [Fact]
        public void ShouldHaveAQualityOfZeroWhenSellInHasPassed()
        {
            int result = _innAdministratorFixture._innAdministrator.CalculateBackstagePassItemQuality(25, -1);

            Assert.True(result == 0);
        }

        [Fact]
        public void ShouldHaveItsQualityIncreaseByOneWhenThereAreMoreThanTenDaysLeftForSellIn()
        {
            int result = _innAdministratorFixture._innAdministrator.CalculateBackstagePassItemQuality(25, 11);

            Assert.True(result == 26);
        }

        [Fact]
        public void ShouldHaveItsQualityIncreaseByTwoWhenThereAreTenOrLessDaysLeftForSellIn()
        {
            int result = _innAdministratorFixture._innAdministrator.CalculateBackstagePassItemQuality(25, 10);

            Assert.True(result == 27);
        }

        [Fact]
        public void ShouldHaveItsQualityIncreaseByThreeWhenThereAreFiveOrLessDaysLeftForSellIn()
        {
            int result = _innAdministratorFixture._innAdministrator.CalculateBackstagePassItemQuality(25, 5);

            Assert.True(result == 28);
        }

        [Fact]
        public void ShouldHaveItsQualityIncreaseToFiftyWhenThereAreFiveOrLessDaysLeftForSellInAndQualityIsFortyNine()
        {
            int result = _innAdministratorFixture._innAdministrator.CalculateBackstagePassItemQuality(49, 5);

            Assert.True(result == 50);
        }

        [Fact]
        public void ShouldHaveItsQualityIncreaseToFiftyWhenThereAreTenOrLessDaysLeftForSellInAndQualityIsFortyNine()
        {
            int result = _innAdministratorFixture._innAdministrator.CalculateBackstagePassItemQuality(49, 10);

            Assert.True(result == 50);
        }

        [Fact]
        public void ShouldHaveItsQualityIncreaseToFiftyWhenThereAreMoreThanTenDaysLeftForSellInAndQualityIsFortyNine()
        {
            int result = _innAdministratorFixture._innAdministrator.CalculateBackstagePassItemQuality(49, 15);

            Assert.True(result == 50);
        }
    }
}
