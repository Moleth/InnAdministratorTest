using InnAdministrator.Data.Entities;
using System;
using System.Collections.Generic;

namespace InnAdministrator.Services.Interfaces
{
    public interface IInnAdministratorDataService
    {
        #region Items

        void CreateItem(string name, int sellIn, int quality);

        Item GetItem(Guid itemId);

        IList<Item> GetAllItems(); 

        void UpdateItem(Item item);

        void DeleteItem(Guid itemId);

        #endregion

        #region ItemsProperties

        //TODO: GRUD operations for ItemsProperties

        #endregion
    }
}
