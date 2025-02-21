using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using tickethub.Entities;
using tickethub.Services.Interfaces;

namespace tickethub.Services.Implementations
{
    public class OtpService : IOtpService
    {
        private readonly IEmailService _emailService;
        private static readonly Random _random = new Random();

        // Using ConcurrentDictionary for thread safety
        private static readonly ConcurrentDictionary<string, string> _otpStorage = new ConcurrentDictionary<string, string>();


        public OtpService(IEmailService emailService)
        {
            _emailService = emailService;
        }

        // Generate OTP (6-digit)
        public string GenerateOtp()
        {
            return _random.Next(100000, 999999).ToString();
        }

        // Send OTP via Email
        public async Task<string> SendOtpAsync(string email)
        {
            string otp = GenerateOtp(); // Generate OTP
            _otpStorage[email] = otp;  // Store OTP mapped to email

            var emailDetails = new EmailDetails
            {
                Recipient = email,
                Subject = "Your OTP for Login",
                MsgBody = $"Your OTP for logging in is: {otp}"
            };

            await _emailService.SendSimpleMail(emailDetails);

            return otp; // Return OTP for verification
        }


        // Verify OTP
        public async Task<bool> VerifyOtp(string email, string enteredOtp)
        {
            if (_otpStorage.TryGetValue(email, out string storedOtp) && storedOtp == enteredOtp)
            {
                _otpStorage.TryRemove(email, out _); // Remove OTP after verification
                return await Task.FromResult(true); // Ensure async return
            }
            return await Task.FromResult(false);
        }





    }
}
