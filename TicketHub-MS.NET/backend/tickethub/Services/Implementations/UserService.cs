using tickethub.DTO;
using tickethub.Helper;
using tickethub.Repositories;
using tickethub.Repositories.Interfaces;
using tickethub.Services.Interfaces;

namespace tickethub.Services.Implementations
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        private IConfiguration configuration;
        private IEmailService emailService;

        public UserService(IUserRepository userRepository,IConfiguration configuration, IEmailService emailService)
        {
            this.userRepository = userRepository;
            this.configuration = configuration;
            this.emailService = emailService;
        }
        public async Task<AuthenticateResponse> AuthenticateAsync(string email, string password)
        {
            User user=await userRepository.AuthenticateAsync(email, password);
            if (user == null) return null;
            //if (user == null || !PasswordHelper.VerifyPassword(email, user.Email)) return null;
            // Authentication successful so generate jwt token
            JwtTokenGenerator jwtTokenGenerator = new JwtTokenGenerator(configuration);
;           var token = jwtTokenGenerator.generateJwtToken(user);
            return new AuthenticateResponse(user, token);   
        }

        public async Task<User> ValidateEmailAsync(string email)
        {
            return await userRepository.ValidateEmailAsync(email);
        }

        public async Task<User> ValidatePhoneAsync(string phone)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return await userRepository.ValidatePhoneAsync(phone);
            }
        }

        public async Task AddAsync(User user)
        {
            //Console.WriteLine("UserService.AddAsync called");

            await userRepository.AddAsync(user);

            var emailDetails = new EmailDetails
            {
                Recipient = user.Email,
                Subject = "Welcome to TicketHub!",
                MsgBody = $"Hello {user.Name},\n\nThank you for signing up at TicketHub! We are excited to have you on board.\n\nBest Regards,\nTicketHub Team",
                Attachment = "D:/CDAC/TICKETHUB PROJECT/SendEmail/QP-WJP.pdf"
            };

            //await emailService.SendSimpleMail(emailDetails);

            if (!string.IsNullOrEmpty(emailDetails.Attachment) && File.Exists(emailDetails.Attachment))
            {
                await emailService.SendMailWithAttachment(emailDetails);
            }
            else
            {
                await emailService.SendSimpleMail(emailDetails);
            }

        }

        public async Task<List<User>> GetAsync()
        {
            return await userRepository.GetAsync(); 
        }

        public async Task<User> GetByIdAsync(long id)
        {
            return await userRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(User user)
        {
            await userRepository.UpdateAsync(user);
        }

        public async Task DeleteAsync(long id)
        {
            await userRepository.DeleteAsync(id);
        }
    }
}
