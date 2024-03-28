using System.ComponentModel.DataAnnotations;

namespace TERA.Ca.OnlineBank.Domain.Models
{
    public class CurencyModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Name Is not valid")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Currency name is not valid")]
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
