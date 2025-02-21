using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using tickethub.Entities;

namespace tickethub.DTO
{
    public class TheaterDTO
    {
        public long Id { get; set; }    
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
