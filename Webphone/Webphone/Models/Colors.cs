using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webphone.Models
{
    [Table("Colors")]
    public class Colors
    {
        [Key]
        public int ColorID { get; set; }
        public string? Names { get; set; }
        public int? ProductID { get; set; }
    }
}
