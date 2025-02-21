using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tickethub.Entities
{
    public class TheaterOwner : BaseEntity
    {
        [Column("name")]
        [Required]
        public string Name { get; set; }

        [Column("contact_info")]
        [Required]
        [MaxLength(100)]
        public string ContactInfo { get; set; }

        [Column("role")]
        public string Role { get; set; }

        public virtual ICollection<Theater> Theaters { get; set; } = new List<Theater>();
    }
}
