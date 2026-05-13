namespace TantareApi.DTOs.Character
{
    public record CreateCharacterDto(string name, DateOnly? birthday, DateOnly? deathDay);
}