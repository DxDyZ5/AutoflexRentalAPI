using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace autoFlexrentalBackend.Models
{
    [Table("Category")]
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        // Navigation property
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}