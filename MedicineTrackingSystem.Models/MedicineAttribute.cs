using System;
using System.ComponentModel.DataAnnotations;

namespace MedicineTrackingSystem.Models
{
    public class MedicineAttribute
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50), Required]
        public string MedicineFullName { get; set; }

        [MaxLength(50), Required]
        public string Brand { get; set; }

        [DataType(DataType.Currency), Required,]
        public decimal? Price { get; set; }

        [Required]
        public int? Quantity { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}"), Required]
        public DateTime? ExpiryDate { get; set; }

        [MaxLength(500), Required]
        public string Notes { get; set; }
    }
}
