using Microsoft.EntityFrameworkCore;
using TantareApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TantareDb>(opt => opt.UseInMemoryDatabase("Tantare"));

var app = builder.Build();

app.Run();
