using Microsoft.EntityFrameworkCore;
using TantareApi.Entities;
using TantareApi.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TantareDb>(opt => opt.UseInMemoryDatabase("Tantare"));

var app = builder.Build();

app.MapPost("/worlds", async (TantareDb db, World world) =>
{
    db.Worlds.Add(world);
    await db.SaveChangesAsync();
    return TypedResults.Created();
});

app.MapGet("/worlds", async (TantareDb db) =>
{
    return await db.Worlds.ToListAsync();
});

app.MapGet("/worlds/{id}", async Task<Results<Ok<World>, NotFound>> (int id, TantareDb db) =>
{
    return await db.Worlds.FindAsync(id)
        is World world
            ? TypedResults.Ok(world)
            : TypedResults.NotFound();
});

app.Run();
