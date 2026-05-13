using TantareApi.DTOs.World;
using TantareApi.Entities;

namespace TantareApi.Extensions
{
    public static class WorldExtensions
    {
        public static World ToWorld(this CreateWorldDto createWorldDto) =>
            new()
            {
                Name = createWorldDto.Name
            };

        public static WorldDto ToWorldDto(this World world) =>
            new WorldDto(world.Id, world.Name);
    }
}