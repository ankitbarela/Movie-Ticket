using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using WebApplication1.Db;
using WebApplication1.Model;
using WebApplication1.Repository.BookingSummary;
using WebApplication1.Repository.City;
using WebApplication1.Repository.LoginCredential;
using WebApplication1.Repository.Movie;
using WebApplication1.Repository.Screen;
using WebApplication1.Repository.Seat;
using WebApplication1.Repository.Show;
using WebApplication1.Repository.State;
using WebApplication1.Repository.Theater;
using WebApplication1.Repository.User;
using WebApplication1.Services;
using WebApplication1.Services.BookingSummary;
using WebApplication1.Services.City;
using WebApplication1.Services.LoginCredential;
using WebApplication1.Services.Mail;
using WebApplication1.Services.Movie;
using WebApplication1.Services.Screen;
using WebApplication1.Services.Seat;
using WebApplication1.Services.Show;
using WebApplication1.Services.State;
using WebApplication1.Services.Theater;
using WebApplication1.Services.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddTransient<ISecurityService, SecurityService>();
builder.Services.AddTransient<IStateRepository, StateRepository>();
builder.Services.AddTransient<ICityRepository, CityRepository>();
builder.Services.AddTransient<IMovieRepository, MovieRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ILoginCredentialRepository, LoginCredentialRepository>();
builder.Services.AddTransient<IMailService, MailService>();
builder.Services.AddTransient<IStateService, StateService>();
builder.Services.AddTransient<ICityService, CityService>();
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<ILoginCredentialService, LoginCredentialService>();
builder.Services.AddTransient<ITheaterService, TheaterService>();
builder.Services.AddTransient<ISeatService, SeatService>();
builder.Services.AddTransient<ISeatRepository, SeatRepository>();
builder.Services.AddTransient<IShowService, ShowService>();
builder.Services.AddTransient<IScreenService, ScreenService>();
builder.Services.AddTransient<IScreenRepository, ScreenRepository>();
builder.Services.AddTransient<IShowRepository, ShowRepository>();
builder.Services.AddTransient<ITheaterRepository, TheaterRepository>();
builder.Services.AddTransient<IScreenService, ScreenService>();
builder.Services.AddTransient<IBookingSummaryRepository, BookingSummaryRepository>();
builder.Services.AddTransient<IBookingSummaryService, BookingSummaryService>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});

var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddAuthorization();
builder.Services.AddDbContext<MovieContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:Con"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

