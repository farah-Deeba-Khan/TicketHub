using tickethub.Entities;

namespace tickethub.Services.Interfaces
{
    public interface IContactEmailService
    {
        Task SendEmailAsync(ContactRequest request);
    }
}
