using InnAdministrator.Data.Context;
using InnAdministrator.Data.Entities;
using InnAdministrator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

//using System.Data.Entity;

namespace InnAdministrator.Services
{
    public class GildedRoseDataService : IInnAdministratorDataService
    {
        private readonly InnAdministratorContext _context;

        public GildedRoseDataService(InnAdministratorContext context)
        {
            _context = context;
        }

        #region Items

        public void CreateItem(string name, int sellIn, int quality)
        {
            _context.Items.Add(new Item
            {
                Name = name,
                SellIn = sellIn,
                Quality = quality
            });

            _context.SaveChanges();
        }

        public Item GetItem(Guid itemId)
        {
            return _context.Items.SingleOrDefault(i => i.Id == itemId);
        }

        public Item GetItem(string itemName)
        {
            if (!String.IsNullOrWhiteSpace(itemName))
            {
                return _context.Items.SingleOrDefault(i => i.Name == itemName);
            }

            return null;
        }

        public IList<Item> GetAllItems()
        {
            return _context.Items.ToList();
        }

        public void UpdateItem(Item item)
        {
            if (item != null)
            {
                _context.SaveChanges();
            }
        }

        public void DeleteItem(Guid itemId)
        {
            Item itemToDelete = _context.Items.SingleOrDefault(i => i.Id == itemId);

            if (itemToDelete != null)
            {
                _context.Items.Remove(itemToDelete);

                _context.SaveChanges();
            }
        }

        #endregion

        #region ItemsProperties

        //TODO: GRUD operations for ItemsProperties

        #endregion
    }
}
