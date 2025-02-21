
namespace tickethub.Services.Interfaces
{
    public interface IOtpService
    {
        string GenerateOtp();
        Task<string> SendOtpAsync(string email);
        Task<bool> VerifyOtp(string email, string enteredOtp);
    }
}
