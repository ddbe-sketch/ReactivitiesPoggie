﻿using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Security.Claims;

namespace Infrastructure.Security
{
    public class UserAccessor(IHttpContextAccessor httpContextAccessor, AppDbContext dbContext) : IUserAccessor
    {
        public async Task<User> GetUserAsync()
        {
            return await dbContext.Users.FindAsync(GetUserId()) ?? throw new UnauthorizedAccessException("No user is logged in");
        }

        public string GetUserId()
        {
            var userId = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId ?? throw new Exception("No user found");
        }

        public async Task<User> GetUserWithPhotosAsync()
        {
            var userId = GetUserId();

            return await dbContext.Users
                .Include(x => x.Photos)
                .FirstOrDefaultAsync(x => x.Id == userId)
                ?? throw new UnauthorizedAccessException("No user is logged in");
        }
    }
}
