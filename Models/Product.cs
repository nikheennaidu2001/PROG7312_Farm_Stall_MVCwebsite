using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Prog_Farm_Stall_MVC_Final.Models
{
    public partial class Product
    {
        [Key]
        [Column("Product_id")]
        public int ProductId { get; set; }
        [Required]
        [Column("Product_FarmerName")]
        [StringLength(255)]
        public string ProductFarmerName { get; set; }
        [Required]
        [Column("Product_Name")]
        [StringLength(25)]
        public string ProductName { get; set; }
        [Required]
        [Column("Product_Description")]
        [StringLength(25)]
        public string ProductDescription { get; set; }
    }
}
