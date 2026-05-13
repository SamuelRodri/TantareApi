namespace TantareApi.Entities
{
    public class World
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        
        public ICollection<Location> Locations { get; set; } = new List<Location>();
    }
}