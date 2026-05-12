namespace TantareApi.Entities
{
    public class Character
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public DateTime? birthDate { get; set; }
        public DateTime? deathDate { get; set;  }
    }
}