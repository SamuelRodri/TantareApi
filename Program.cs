using Microsoft.EntityFrameworkCore;
using TantareApi.Infrastructure;
using TantareApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TantareDb>(opt => opt.UseInMemoryDatabase("Tantare"));

var app = builder.Build();

app.MapWorldEndpoints();
app.MapLocationEndpoints();
app.MapCharacterEndpoints();

app.Run();
