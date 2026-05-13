using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TantareApi.DTOs.Location;
using TantareApi.DTOs.World;
using TantareApi.Entities;
using TantareApi.Extensions;
using TantareApi.Infrastructure;

namespace TantareApi.Endpoints
{
    public static class WorldEndpoints
    {
        public static void MapWorldEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/worlds");

            group.MapPost("/", async (TantareDb db, CreateWorldDto dto) =>
            {
                db.Worlds.Add(dto.ToWorld());
                await db.SaveChangesAsync();
                return TypedResults.Created();
            });

            group.MapGet("/", async (TantareDb db) =>
            {
                return TypedResults.Ok(await db.Worlds.Include(w => w.Locations).Select(w => w.ToWorldDto()).ToListAsync());
            });

            group.MapGet("/{id}", async Task<Results<Ok<WorldDto>, NotFound>> (int id, TantareDb db) =>
            {
                return await db.Worlds.FindAsync(id)
                    is World world
                        ? TypedResults.Ok(world.ToWorldDto())
                        : TypedResults.NotFound();
            });

            group.MapGet("/{id}/locations", async Task<Results<Ok<List<LocationDto>>, NotFound>> (int id, TantareDb db) =>
            {
                var exists = await db.Worlds.AnyAsync(w => w.Id == id);

                if (!exists)
                    return TypedResults.NotFound();

                var locations = await db.Locations
                        .Where(l => l.WorldId == id)
                        .Select(l => l.ToLocationDto())
                        .ToListAsync();

                return TypedResults.Ok(locations);
            });
        }
    }
}