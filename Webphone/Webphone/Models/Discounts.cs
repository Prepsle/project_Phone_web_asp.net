using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webphone.Models
{
    [Table("Discounts")]
    public class Discounts
    {
        [Key]
        public int DiscountID { get; set; }
        public int? ProductID { get; set; }
        public int? DiscountPercentage { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
