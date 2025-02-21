//namespace tickethub.Entities
//{
//    public class Admin
//    {
//    }
//}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Admin : BaseEntity
{
    [Column("name")]
    public string? Name { get; set; } // Nullable equivalent to `nullable = true`

    [Column("email")]
    [Required]
    [EmailAddress]
    [MaxLength(255)]
    public string Email { get; set; }

    [Column("role")]
    public string Role { get; set; }

    [Column("password")]
    [Required]
    [MaxLength(255)]
    public string Password { get; set; }

    public Admin() { }

    public Admin(string? name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Name: {Name}, Email: {Email}";
    }
}
