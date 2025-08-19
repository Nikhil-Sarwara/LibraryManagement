using LibraryManagement.Application.Interfaces;
using LibraryManagement.Application.Mappings;
using LibraryManagement.Application.Services;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Entities.LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Interfaces;
using LibraryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// PostgreSQL
builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories
builder.Services.AddScoped<IRepository<Book>, Repository<Book>>();
builder.Services.AddScoped<IRepository<User>, Repository<User>>();
builder.Services.AddScoped<IRepository<Checkout>, Repository<Checkout>>();
builder.Services.AddScoped<IRepository<BookRating>, Repository<BookRating>>();
builder.Services.AddScoped<IRepository<ReadingProgress>, Repository<ReadingProgress>>();

// Services
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IUserService, UserService>();

// AutoMapper - Simple assembly-based registration
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowReactApp");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
