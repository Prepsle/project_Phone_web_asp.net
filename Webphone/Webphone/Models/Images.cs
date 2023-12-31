using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webphone.Models
{
    [Table("Images")]
    public class Images
    {
        [Key]
        public int ImageID { get; set; }
        public string? ImageURL { get; set; }
        public int? Position { get; set; }
    }
}
