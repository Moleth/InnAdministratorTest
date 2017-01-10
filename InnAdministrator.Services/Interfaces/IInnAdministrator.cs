using InnAdministrator.Data.Entities;
using System.Collections.Generic;

namespace InnAdministrator.Services.Interfaces
{
    public interface IInnAdministrator
    {
        void UpdateQuality();

        int CalculateOrdinaryItemQuality(int quality, int sellIn);

        int CalculateAgedCheeseItemQuality(int quality);

        int CalculateConjuredItemQuality(int quality, int sellIn);

        int CalculateLegendaryItemQuality(int quality, int sellIn);

        int CalculateBackstagePassItemQuality(int quality, int sellIn);
    }
}
