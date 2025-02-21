namespace tickethub.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAsync();
        Task<User> GetByIdAsync(long id);
        Task<User> AuthenticateAsync(String email, String password);   
        Task<User> ValidateEmailAsync(String email);
        Task<User> ValidatePhoneAsync(String phone);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(long id);
    }
}
