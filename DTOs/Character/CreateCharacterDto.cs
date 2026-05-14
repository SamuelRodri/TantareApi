namespace TantareApi.DTOs.Character
{
    public record CreateCharacterDto(string name, DateOnly? birthday, DateOnly? deathDay, int worldId, int? locationId);
}