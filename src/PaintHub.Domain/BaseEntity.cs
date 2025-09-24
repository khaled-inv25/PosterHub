using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PosterHub.Domain
{
    public abstract class BaseEntity<TId> where TId : IEquatable<TId>
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TId Id { get; set; }
    }
}
