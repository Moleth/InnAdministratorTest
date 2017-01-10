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
    public class GuildedRoseAgedCheseTestData
    {
        //These values should probably be in an external source.
        public static IEnumerable<object[]> TestData
        {
            get
            {
                yield return new object[] { 25, 26 };
                yield return new object[] { 50, 50 };
            }
        }
    }

    [Collection("Gilded Rose tests")]
    [Trait("ItemTypeQualityCalculation", "Aged Cheese")]
    public class AgedCheeseItemsTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        private readonly InnAdministratorFixture _innAdministratorFixture;


        public AgedCheeseItemsTests(ITestOutputHelper testOutputHelper, InnAdministratorFixture innAdministratorFixture)
        {
            _innAdministratorFixture = innAdministratorFixture;
            _testOutputHelper = testOutputHelper;
        }

        //Put here as an example of a [Theory] tha could replace several facts. The tests of this [Theory] as still also executed by the below [Fact]s.
        //Normally either the [Theory] or the [Fact]s should be used.
        [Theory]
        [MemberData("TestData", MemberType = typeof(GuildedRoseAgedCheseTestData))]
        public void CalculateAgedCheeseQuality(int quality, int expectedResult)
        {
            int result = _innAdministratorFixture._innAdministrator.CalculateAgedCheeseItemQuality(quality);

            Assert.True(result == expectedResult);
        }

        [Fact]
        public void ShouldHaveItsQualityRaisedByOneIfQualityIsBetweenZeroAndFifty()
        {
            int result = _innAdministratorFixture._innAdministrator.CalculateAgedCheeseItemQuality(25);

            Assert.True(result == 26);
        }

        [Fact]
        public void ShouldNotHaveQualityLessThanOrEqualToZero()
        {
            int result = _innAdministratorFixture._innAdministrator.CalculateAgedCheeseItemQuality(-1);

            Assert.True(result > 0);
        }

        [Fact]
        public void ShouldNotHaveQualityMoreThanFifty()
        {
            int result = _innAdministratorFixture._innAdministrator.CalculateAgedCheeseItemQuality(50);

            Assert.True(result == 50);
        }
    }
}
