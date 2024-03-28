using System.ComponentModel.DataAnnotations;

namespace TERA.Ca.OnlineBank.Domain.Models
{
    public class CurencyModel
    {
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Currency name is not valid")]
        public string Name { get; set; }

        [Required]
        [Range(0, 1000000000)]
        public decimal Equvalent { get; set; }

        public override string ToString()
        {
            return $"Name:{Name} Eqvivalent in Gel: {Equvalent}";
        }
    }
}
