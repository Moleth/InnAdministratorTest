using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnAdministrator.Data.Entities
{
    [Table("ItemsProperties")]
    public class ItemProperty
    {
        

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid ItemId { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}
