using System;
using Foodinio.Infrastructure.DTO;
using Microsoft.Extensions.Caching.Memory;

namespace Foodinio.Infrastructure.Extensions
{
    public static class CacheExtensions
    {
        public static void SetJwt(this IMemoryCache cache, Guid tokenId, JwtDTO jwt)
            => cache.Set(GetJwtKey(tokenId), jwt, TimeSpan.FromSeconds(5));

        public static JwtDTO GetJwt(this IMemoryCache cache, Guid tokenId)
        => cache.Get<JwtDTO>(GetJwtKey(tokenId));

        private static string GetJwtKey(Guid tokenId) => $"{tokenId}-jwt";
    }
}