﻿using Microsoft.AspNetCore.Identity;
using MotoMarketApi.Entities.Enums;

namespace MotoMarketApi.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public Role Role { get; set; }

        public ICollection<FavoriteAd> FavoriteAds { get; set; } = new List<FavoriteAd>();
    }
}
