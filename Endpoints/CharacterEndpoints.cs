using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TantareApi.DTOs.Character;
using TantareApi.Entities;
using TantareApi.Extensions;
using TantareApi.Infrastructure;

namespace TantareApi.Endpoints
{
    public static class CharacterEndpoints
    {
        public static void MapCharacterEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/characters");

            group.MapPost("/", async (CreateCharacterDto dto, TantareDb db) =>
                {
                    db.Characters.Add(dto.ToCharacter());
                    await db.SaveChangesAsync();
                    return TypedResults.Created();
                });

            group.MapGet("/", async (TantareDb db) =>
            {
                return await db.Characters.Select(c => c.ToCharacterDto()).ToListAsync();
            });

            group.MapGet("/{id}", async Task<Results<Ok<CharacterDto>, NotFound>> (int id, TantareDb db) =>
            {
                return await db.Characters.FindAsync(id)
                    is Character character
                        ? TypedResults.Ok(character.ToCharacterDto())
                        : TypedResults.NotFound();
            });
        }
    }
}