using System.Numerics;
using Microsoft.AspNetCore.Mvc;
using tickethub.DTO;
using tickethub.Entities;
using tickethub.Services.Implementations;
using tickethub.Services.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace tickethub.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IOtpService otpService;

        // Constructor to inject IUserService
        public UserController(IUserService userService, IOtpService otpService)
        {
            this.userService = userService;
            this.otpService = otpService;
        }

        // Get all users
        [HttpGet]
        [Helper.Authorize]
        public async Task<IActionResult> GetAsync()
        {
            var users = await userService.GetAsync();

            // Create a custom object for each user without the 'Password' field
            var userResponses = users.Select(user => new
            {
                user.Id,
                user.Name,
                user.Dob,
                user.Email,
                user.Phone,
                user.Gender,
                user.MaritalStatus
            }).ToList();

            // Return status code 200 with users list
            return Ok(userResponses);  
        }

        // Get user by ID
        [HttpGet("{id}")]
        [Helper.Authorize]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var user = await userService.GetByIdAsync(id);
            if (user == null)
            {
                // Return status code 404 if not found
                return NotFound(new { message = "User not found" }); 
            }

            // Create a custom object for each user without the 'Password' field
            var response = new
            {
                user.Id,
                user.Name,
                user.Dob,
                user.Email,
                user.Phone,
                user.Gender,
                user.MaritalStatus
            };

            // Return status code 200 with user object
            return Ok(response);  
        }

        //// Authenticate user
        //[HttpPost("authenticate")]
        //public async Task<IActionResult> AuthenticateAsync([FromBody] AuthenticateRequest authenticateRequest)
        //{
        //    var response = await userService.AuthenticateAsync(authenticateRequest.Email, authenticateRequest.Password);
        //    if (response == null)
        //    {
        //        // Return status code 401 if authentication fails
        //        return Unauthorized(new { message = "Invalid credentials" });  
        //    }
        //    // Return status code 200 with authenticated user data
        //    return Ok(response);  
        //}



        // Authenticate user and send OTP
        [HttpPost("signin")]
        public async Task<IActionResult> AuthenticateAsync([FromBody] AuthenticateRequest authenticateRequest)
        {
            var response = await userService.AuthenticateAsync(authenticateRequest.Email, authenticateRequest.Password);
            if (response == null)
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }

            // Send OTP to the authenticated user's email
            await otpService.SendOtpAsync(authenticateRequest.Email);

            return Ok(new { message = "OTP sent to your email.", user = response });
        }


        // Send OTP separately if needed (e.g., forgot password)
        [HttpPost("sendOTP")]
        public async Task<IActionResult> SendOTPAsync([FromBody] OTPRequest otpRequest)
        {
            await otpService.SendOtpAsync(otpRequest.Email);
            return Ok(new { message = "OTP sent to your email." });
        }


        // Verify OTP
        [HttpPost("verifyOTP")]
        public async Task<IActionResult> VerifyOTPAsync([FromBody] OTPVerifyRequest otpVerifyRequest)
        {
            bool isVerified = await otpService.VerifyOtp(otpVerifyRequest.Email, otpVerifyRequest.OTP);
            if (isVerified)
            {
                return Ok(new { message = "Login Successful" });
            }
            return BadRequest(new { message = "Invalid OTP or OTP expired" });
        }




        // Authenticate Email
        [HttpGet("validateEmail")]
        public async Task<IActionResult> ValidateEmailAsync(string email)
        {
            var response = await userService.ValidateEmailAsync(email);
            if (response!=null)
            {
                // Return status code 401 if authentication fails
                return Unauthorized(new { message = "Phone number already in use" });
            }
            else
            {
                // Return status code 200 with authenticated user data
                return Ok("Phone number is available");
            }
        }

        // Authenticate Phone
        [HttpGet("validatePhone")]
        public async Task<IActionResult> ValidatePhoneAsync(string phone)
        {
            var response = await userService.ValidatePhoneAsync(phone);
            if (response != null)
            {
                // Return status code 401 if authentication fails
                return Unauthorized(new { message = "Phone number already in use" });
            }
            else
            {
                // Return status code 200 with authenticated user data
                return Ok("Phone number is available");
            }
        }

       // Add a new user
       [HttpPost("signup")]
        public async Task<IActionResult> AddAsync([FromBody] User user)
        {
            // Validate the model
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                        .Where(ms => ms.Value.Errors.Any())
                        .ToDictionary(
                            kvp => kvp.Key,
                            kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToList()
                        );

                return BadRequest(new { errors });
            }

            await userService.AddAsync(user);

            // Return status code 201 (Created)
            return StatusCode(StatusCodes.Status201Created, new { message = "User Created Successfully" });
        }


        // Update an existing user
        //[Helper.Authorize]
        [HttpPut("updateUser/{id}")]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                // Return status code 400 if ID mismatch
                return BadRequest(new { message = "User ID mismatch" });  
            }

            var existingUser = await userService.GetByIdAsync(id);
            if (existingUser == null)
            {
                // Return status code 404 if user not found
                return NotFound(new { message = "User not found" });  
            }

            await userService.UpdateAsync(user);
            // Return status 200 on successful update
            return Ok(new { message = "User Updated Successfully" }); 
        }

        // Delete a user by ID
        [Helper.Authorize]
        [HttpDelete("deleteUser/{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var user = await userService.GetByIdAsync(id);
            if (user == null)
            {
                // Return status code 404 if user not found
                return NotFound(new { message = "User not found" });  
            }

            await userService.DeleteAsync(id);
            // Return status 200 on successful update
            return Ok(new { message = "User Deleted Successfully" });
        }
    }
}
