using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace InnAdministrator.Data.Entities
{
    [Table("Items")]
    public class Item
    {
        public Item()
        {
            this.Properties = new HashSet<ItemProperty>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public virtual ICollection<ItemProperty> Properties { get; set; }
    }
}
