using media.hub.data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<MediaContext>(options 
    => options.UseSqlServer(builder.Configuration.GetConnectionString("MediaConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// / DEFAULT CORS WITH ALL ORIGINS
// builder.Services.AddCors(options
//     => options.AddDefaultPolicy(
//         builder => 
//         {
//             builder.AllowAnyOrigin();
//             builder.AllowAnyHeader();
//             builder.AllowAnyMethod();   
//         }
//     ));

builder.Services.AddCors(options => 
options.AddPolicy("OnlyGetPolicy", builder =>
    {
        builder.WithOrigins("http://127.0.0.1:5500");
        builder.WithMethods("GET");
    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// DEFAULT
// app.UseCors();
app.UseCors("OnlyGetPolicy");


app.UseAuthorization();

app.MapControllers();

app.Run();
