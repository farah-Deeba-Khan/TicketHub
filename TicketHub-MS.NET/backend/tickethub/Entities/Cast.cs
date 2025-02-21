//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//[Table("casts")]
//public class Cast : BaseEntity
//{
//    public long CastId { get; set; }

//    public string Name { get; set; }

//    public string ProfilePath { get; set; }

//    [ForeignKey("MovieCast")]
//    [Column("cast_id")]
//    public long MovieCastId { get; set; }
//    public MovieCast MovieCast { get; set; }
//}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("casts")]
public class Cast : BaseEntity  
{
    [Column("cast_id")]
    public long CastId { get; set; }

    [Column("name")]
    [MaxLength(100)]
    public string Name { get; set; }

    [Column("profile_path")]
    public string? ProfilePath { get; set; }

    //[ForeignKey("MovieCast")]
    //[Column("movie_cast_id")]
    ////public int MovieCastId { get; set; } // Foreign key property
    //public long MovieCastId { get; set; }

    //public virtual MovieCast MovieCast { get; set; } // Navigation property

    public Cast() { }

    public Cast(long castId, string name, string profilePath, int movieCastId)
    {
        CastId = castId;
        Name = name;
        ProfilePath = profilePath;
        //MovieCastId = movieCastId;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Name: {Name}, ProfilePath: {ProfilePath}";
    }
}
