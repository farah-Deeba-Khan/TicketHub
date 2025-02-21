

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using tickethub.Entities;

[Table("theaters")]
public class Theater : BaseEntity
{
    [Column("name")]
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }   

    [Column("location")]
    [MaxLength(25)]
    public string Location { get; set; }

    [ForeignKey("TheaterOwner")]
    [Column("theater_Ownerid")]
    [Required]
    //public int TheaterOwnerId { get; set; } // Foreign key property
    public long TheaterOwnerId { get; set; }

    public virtual TheaterOwner TheaterOwner { get; set; } // Navigation property

    public override string ToString()
    {
        return $"{base.ToString()}, Name: {Name}, Location: {Location}, TheaterOwnerId: {TheaterOwnerId}";
    }
}


//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//[Table("theaters")]
//public class Theater : BaseEntity
//{
//    [MaxLength(25)]
//    [Column("name")]

//    //[Index(IsUnique = true)]
//    public string Name { get; set; }

//    [MaxLength(25)]
//    [Column("location")]

//    public string Location { get; set; }

//    private TheaterOwner theaterOwner;

//}
