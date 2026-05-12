using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TantareApi.Entities;
using TantareApi.Infrastructure;

namespace TantareApi.Endpoints
{
    public static class WorldEndpoints
    {
        public static void MapWorldEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/worlds");

            group.MapPost("/", async (World world, TantareDb db) =>
            {
                db.Worlds.Add(world);
                await db.SaveChangesAsync();
                return TypedResults.Created();
            });

            group.MapGet("/", async (TantareDb db) =>
            {
                return await db.Worlds.ToListAsync();
            });

            group.MapGet("/{id}", async Task<Results<Ok<World>, NotFound>> (int id, TantareDb db) =>
            {
                return await db.Worlds.FindAsync(id)
                    is World world
                        ? TypedResults.Ok(world)
                        : TypedResults.NotFound();
            });
        }
    }
}