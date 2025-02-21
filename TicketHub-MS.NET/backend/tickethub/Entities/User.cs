using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

[Table("users")]
public class User : BaseEntity
{
    [MaxLength(25)]
    [Column("name")]
    public string Name { get; set; }

    [MaxLength(50)]
    [Column("email")]

    [EmailAddress(ErrorMessage ="Email is incorrect")]
    //[Index(IsUnique = true)]
    public string Email { get; set; }

    [MaxLength(25)]
    [Column("phone")]
    //[Index(IsUnique = true)]
    public string Phone { get; set; }

    [Column("dob")]
    public DateOnly Dob { get; set; }

    [MaxLength(25)]
    [Column("gender")]
    public string Gender { get; set; }

    [Column("role")]
    [MaxLength(25)]
    public string? Role { get; set; }

    [MaxLength(25)]
    [Column("marital_status")]
    public string MaritalStatus { get; set; }

    [Column("password")]
    public string? Password { get; set; }
}
