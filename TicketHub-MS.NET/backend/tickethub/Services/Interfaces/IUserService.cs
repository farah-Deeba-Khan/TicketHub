using tickethub.DTO;

namespace tickethub.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAsync();
        Task<User> GetByIdAsync(long id);
        Task<AuthenticateResponse> AuthenticateAsync(String email, String password);
        Task<User> ValidateEmailAsync(String email);
        Task<User> ValidatePhoneAsync(String phone);
        Task AddAsync(User user);
        Task UpdateAsync(User user);  
        Task DeleteAsync(long id);
    }
}
