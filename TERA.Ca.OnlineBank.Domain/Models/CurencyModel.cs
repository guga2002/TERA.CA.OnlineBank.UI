using System.ComponentModel.DataAnnotations;

namespace TERA.Ca.OnlineBank.Domain.Models
{
    public class CurencyModel
    {
        public string Name { get; set; }

        public decimal Equvalent { get; set; }
    }
}
