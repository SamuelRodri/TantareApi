namespace TantareApi.DTOs.Character
{
    public record CharacterDto(int Id, string Name, DateOnly? birthDate, DateOnly? deathDate);
}