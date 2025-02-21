using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace tickethub.DTO
{
    public class AuthenticateResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateOnly Dob { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            Phone = user.Phone;
            Dob = user.Dob;
            Gender = user.Gender;
            MaritalStatus = user.MaritalStatus;
            Token = token;
        }
    }
}
