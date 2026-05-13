using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TantareApi.Entities;
using TantareApi.Infrastructure;

namespace TantareApi.Endpoints
{
    public static class CharacterEndpoints
    {
        public static void MapCharacterEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/characters");

            group.MapPost("/", async (TantareDb db, Character character) =>
                {
                    db.Characters.Add(character);
                    await db.SaveChangesAsync();
                    return TypedResults.Created();
                });

            group.MapGet("/", async (TantareDb db) =>
            {
                return await db.Characters.ToListAsync();
            });

            group.MapGet("/{id}", async Task<Results<Ok<Character>, NotFound>> (int id, TantareDb db) =>
            {
                return await db.Characters.FindAsync(id)
                    is Character character
                        ? TypedResults.Ok(character)
                        : TypedResults.NotFound();
            });
        }
    }
}