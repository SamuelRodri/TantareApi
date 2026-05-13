using TantareApi.DTOs.Location;
using TantareApi.Entities;

namespace TantareApi.Extensions
{
    public static class LocationExtensions
    {
        public static Location ToLocation(this CreateLocationDto dto) =>
            new()
            {
                Name = dto.Name,
                WorldId = dto.WorldId
            };

        public static LocationDto ToLocationDto(this Location location) =>
            new(location.Id, location.Name, location.WorldId);
    }
}