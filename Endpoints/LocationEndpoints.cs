using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TantareApi.Entities;
using TantareApi.Infrastructure;

namespace TantareApi.Endpoints
{
    public static class LocationEndpoints
    {
        public static void MapLocationEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/locations");

            group.MapPost("/", async (Location location, TantareDb db) =>
            {
                db.Locations.Add(location);
                await db.SaveChangesAsync();
                return TypedResults.Created();
            });

            group.MapGet("/", async (TantareDb db) =>
            {
                return await db.Locations.ToListAsync();
            });

            group.MapGet("/{id}", async Task<Results<Ok<Location>, NotFound>> (int id, TantareDb db) =>
            {
                return await db.Locations.FindAsync(id)
                    is Location location
                        ? TypedResults.Ok(location)
                        : TypedResults.NotFound();
            });
        }
    }
}