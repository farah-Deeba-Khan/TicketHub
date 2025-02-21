using tickethub.Helper;
using tickethub.Repositories;
using tickethub.Repositories.Implementations;
using tickethub.Repositories.Interfaces;
using tickethub.Services.Implementations;
using tickethub.Services.Interfaces;
using ticketHub.Repositories.Interfaces;
using ticketHub.Repositories.Implementations;
using ticketHub.Services.Interfaces;
using ticketHub.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IContactEmailService, ContactEmailService>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>(); // Add this line  
builder.Services.AddScoped<IShowtimeRepository, ShowtimeRepository>();
builder.Services.AddScoped<IShowtimeService, ShowtimeService>();
builder.Services.AddScoped<IOtpService, OtpService>();
builder.Services.AddScoped<IBookingRepository,BookingRepository>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();


builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Ensure the database is created
using (var context = new ApplicationDbContext())
{
    context.Database.EnsureCreated();  // Creates the DB if it doesn't exist
}

// Configure the HTTP request pipeline.
app.UseCors("AllowAll");
app.UseMiddleware<JwtMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
