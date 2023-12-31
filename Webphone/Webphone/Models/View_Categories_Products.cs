using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Webphone.Models
{
    [Table("View_Categories_Products")]
    public class View_Categories_Products
    {
        [Key]
        public int ProductID { get; set; }
        public string? Names { get; set; }
        public string? Descriptions { get; set; }
        public decimal? Price { get; set; }
        public int? StockQuantity { get; set; }
        public int? UserID { get; set; }
        public int? CategoryID { get; set; }
        public string? Expr1 { get; set; }
        public bool IsActive { get; set; }
        public string? Images { get; set; }
        public bool? Latest_Product { get; set; }
        public bool? Top_Rated_Product { get; set; }
        public bool? Review_Product { get; set; }
        public string? OS { get; set; }
        public string? Camera_TRC { get; set; }
        public string? Camere_S { get; set; }
        public string? Chip { get; set; }
        public int? RAM { get; set; }
        public int? SSD { get; set; }
        public string? SIM { get; set; }
        public string? LIB { get; set; }
        public string? Screen { get; set; }
        public string? Color { get; set; }
    }
}