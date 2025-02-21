//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;

//[Table("movie_casts")]
//public class MovieCast : BaseEntity
//{
//    public string Director { get; set; }

//    public string Writer { get; set; }

//    public ICollection<Cast> Casts { get; set; } = new List<Cast>();
//}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("movie_casts")]
public class MovieCast : BaseEntity
{
    [Column("director")]
    [MaxLength(50)]
    public string? Director { get; set; }

    [Column("writer")]
    [MaxLength(50)]
    public string? Writer { get; set; }

    public virtual ICollection<Cast> Casts { get; set; } = new List<Cast>();
    //public long MovieId { get; internal set; }

    public MovieCast() { }

    public MovieCast(string director, string writer)
    {
        Director = director;
        Writer = writer;
        Casts = new List<Cast>();     
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Director: {Director}, Writer: {Writer}";
    }
}
