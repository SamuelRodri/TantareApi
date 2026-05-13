using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TantareApi.DTOs.Location;
using TantareApi.Entities;
using TantareApi.Extensions;
using TantareApi.Infrastructure;

namespace TantareApi.Endpoints
{
    public static class LocationEndpoints
    {
        public static void MapLocationEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/locations");

            group.MapPost("/", async (CreateLocationDto dto, TantareDb db) =>
            {
                db.Locations.Add(dto.ToLocation());
                await db.SaveChangesAsync();
                return TypedResults.Created();
            });

            group.MapGet("/", async (TantareDb db) =>
            {
                return await db.Locations.Select(l => l.ToLocationDto()).ToListAsync();
            });

            group.MapGet("/{id}", async Task<Results<Ok<LocationDto>, NotFound>> (int id, TantareDb db) =>
            {
                return await db.Locations.FindAsync(id)
                    is Location location
                        ? TypedResults.Ok(location.ToLocationDto())
                        : TypedResults.NotFound();
            });
        }
    }
}