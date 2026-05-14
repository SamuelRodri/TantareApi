namespace TantareApi.Entities
{
    public class Character
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public DateOnly? birthDate { get; set; }
        public DateOnly? deathDate { get; set;  }

        public int WorldId { get; set; }
        public int LocationId { get; set; }
    }
}