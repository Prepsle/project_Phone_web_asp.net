using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webphone.Models
{
    [Table("Carts")]
    public class Carts
    {
        [Key]
        public int CartID { get; set; }
        public int? UserID { get; set; }
        public int? ProductID { get; set; }
        public int? Quantity { get; set; }
    }
}
