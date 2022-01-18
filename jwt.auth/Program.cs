using System.Text;
using jwt.auth.Options;
using jwt.auth.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtKeys"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<JwtService>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x => 
{
    x.RequireHttpsMetadata = false;
    // x.Authority = "https://localhost:7284";
    // x.Audience = "https://localhost:7284";
    x.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JwtKeys:IssuerSigningKey"])),
        ValidateIssuer = false,
        ValidIssuer = builder.Configuration["JwtKeys:ValidIssuer"],
        ValidateAudience = false,
        ValidAudience = builder.Configuration["JwtKeys:ValidAudience"],
        ValidateLifetime = true
    };
});

// builder.Services.AddSession(options => 
// {
//     options.IdleTimeout = TimeSpan.FromSeconds(5);
// });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

// app.UseSession();

app.MapControllers();

app.Run();
