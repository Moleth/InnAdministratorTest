using InnAdministrator.Data.Context;
using InnAdministrator.Services;
using Xunit;

namespace GildedRose.Tests.TestFixtures
{
    public class InnAdministratorFixture
    {
        public GildedRoseAdministrator _innAdministrator { get; private set; }

        public InnAdministratorFixture()
        {
            InnAdministratorContext context = new InnAdministratorContext();
            GildedRoseDataService dataService = new GildedRoseDataService(context);
            _innAdministrator = new GildedRoseAdministrator(dataService);
        }
    }

    [CollectionDefinition("Gilded Rose tests")]
    public class GildedRoseTestsCollection : ICollectionFixture<InnAdministratorFixture>
    {
    }
}
