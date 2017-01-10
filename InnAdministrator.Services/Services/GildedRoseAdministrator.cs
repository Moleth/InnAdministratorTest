using InnAdministrator.Data.Entities;
using InnAdministrator.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace InnAdministrator.Services
{
    public class GildedRoseAdministrator : IInnAdministrator
    {
        public readonly IInnAdministratorDataService _innAdministratorDataService;

        public GildedRoseAdministrator(IInnAdministratorDataService innAdministratorDataService)
        {
            _innAdministratorDataService = innAdministratorDataService;
        }

        public void UpdateQuality()
        {
            IList<Item> items = _innAdministratorDataService.GetAllItems();

            if (items != null)
            {
                foreach (Item item in items)
                {
                    /*
                    In this case I would have prefered to have added an ItemType enum property
                    to the Item entity, instead of using the new Value string from the ItemsProperties
                    table, but the angry goblin would not agree to changing the entity more than adding an ID to it,
                    so a combromise had to be made :)
                    */
                    string itemProperty = item.Properties.SingleOrDefault(i => i.Name == "ItemType")?.Value;

                    if (!string.IsNullOrWhiteSpace(itemProperty))
                    {
                        switch (itemProperty)
                        {
                            case "Ordinary":
                                item.Quality = CalculateOrdinaryItemQuality(item.Quality, item.SellIn);
                                break;
                            case "Conjured":
                                item.Quality = CalculateConjuredItemQuality(item.Quality, item.SellIn);
                                break;
                            case "AgedCheese":
                                item.Quality = CalculateAgedCheeseItemQuality(item.Quality);
                                break;
                            case "Legendary":
                                item.Quality = CalculateLegendaryItemQuality(item.Quality, item.SellIn);
                                break;
                            case "BackstagePass":
                                item.Quality = CalculateBackstagePassItemQuality(item.Quality, item.SellIn);
                                break;
                        }

                        item.SellIn --;

                        _innAdministratorDataService.UpdateItem(item);
                    }
                }
            }
        }

        public int CalculateOrdinaryItemQuality(int quality, int sellIn)
        {
            if (quality >= 52) return 50;
            
            if (quality < 0) return 0;

            int maximumValueToDecreaseQuality = sellIn >= 0 ? 1 : 2;

            for (int counter = 0; counter < maximumValueToDecreaseQuality; counter++)
            {
                if (quality > 0) quality -= 1;
            }

            return quality;
        }

        public int CalculateAgedCheeseItemQuality(int quality)
        {
            if (quality <= 0) quality = 0;

            if (quality < 50) return quality += 1;

            return quality;
        }

        public int CalculateConjuredItemQuality(int quality, int sellIn)
        {
            if (quality >= 54) return 50;

            if (quality >= 53 && sellIn > 0) return 50;

            if (quality < 0) return 0;

            int maximumValueToDecreaseQuality = sellIn >= 0 ? 2 : 4;

            for (int counter = 0; counter < maximumValueToDecreaseQuality; counter++)
            {
                if (quality > 0) quality -= 1;
            }

            return quality;
        }
        
        public int CalculateLegendaryItemQuality(int quality, int sellIn)
        {
            if (quality <= 0) quality = 0;

            return quality;
        }
        
        public int CalculateBackstagePassItemQuality(int quality, int sellIn)
        {
            if (sellIn < 0) return 0;

            if (quality <= 0) quality = 0;

            if (sellIn > 10)
            {
                if (quality < 50)
                {
                    return quality += 1;
                }
            }

            int maximumValueToIncreaseQuality = sellIn < 6 ? 3 : 2;

            for (int counter = 0; counter < maximumValueToIncreaseQuality; counter++)
            {
                if (quality < 50) quality += 1;
            }

            return quality;
        }
    }
}
