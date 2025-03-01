using System.ComponentModel.DataAnnotations;

namespace armadieti2.Models
{
    public class StatoChiaveModel
    {
        [Key]
        public required string StatoChiave { get; set; }
    }
}
