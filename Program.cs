using Microsoft.EntityFrameworkCore;
using TantareApi.Infrastructure;
using TantareApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TantareDb>(opt => opt.UseInMemoryDatabase("Tantare"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapWorldEndpoints();
app.MapLocationEndpoints();
app.MapCharacterEndpoints();

app.Run();
