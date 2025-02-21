using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tickethub.DTO
{
    public class CastDTO
    {
        public long Id { get; set; }
        public long CastId { get; set; }
        public string Name { get; set; }

        public string? ProfilePath { get; set; }
    }
}
