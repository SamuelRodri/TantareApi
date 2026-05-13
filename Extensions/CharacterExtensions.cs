using TantareApi.DTOs.Character;
using TantareApi.Entities;

namespace TantareApi.Extensions
{
    public static class CharacterExtensions
    {
        public static Character ToCharacter(this CreateCharacterDto dto) =>
            new()
            {
                Name = dto.name,
                birthDate = dto.birthday,
                deathDate = dto.deathDay
            };

        public static CharacterDto ToCharacterDto(this Character character) =>
            new(character.Id, character.Name, character.birthDate, character.deathDate);
    }
}