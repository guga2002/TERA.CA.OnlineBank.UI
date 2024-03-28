using System.ComponentModel.DataAnnotations;

namespace TERA.Ca.OnlineBank.Domain.Models
{
    public class TransactionTypeModel
    {

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "TransactionName Is not valid")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "TransactionName  is not valid")]
        public string TransactionName { get; set; }

        public override string ToString()
        {
            return $"TransactionName {TransactionName}";
        }
    }
}
