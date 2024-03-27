using System.ComponentModel.DataAnnotations;

namespace TERA.CA.OnlineBank.Core.Entities
{
    public abstract class AbstractEntity
    {
        [Key]
        protected Guid Id { get; set; }
    }
}
