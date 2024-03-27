using System.ComponentModel.DataAnnotations;

namespace TERA.CA.OnlineBank.Core.Entities
{
    public abstract class AbstractEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
