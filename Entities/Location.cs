namespace TantareApi.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public int WorldId { get; set; }
        public World World { get; set; } = null!;
    }
}