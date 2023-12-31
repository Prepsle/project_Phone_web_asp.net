using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webphone.Models
{
    [Table("Reviews")]
    public class Reviews
    {
        [Key]
        public int ReviewID { get; set; }
        public int? ProductID { get; set; }
        public int? UserID { get; set; }
        public int? Ratiing { get; set; }
        public string? Comment { get; set; }
        public DateTime? ReviewDate { get; set; }
    }
}
