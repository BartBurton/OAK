using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OAK.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace OAK.Services
{
    public class CurrentUserAvatar : ICurrentUserAvatar
    {
        private readonly OAKContext _oak;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserAvatar(OAKContext oak, IHttpContextAccessor httpContextAccessor)
        {
            _oak = oak;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<byte[]> GetAvatar()
        {
            Autor autor = null;

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated == true)
            {
                autor = await _oak.Autors.FirstOrDefaultAsync(a => 
                a.Email == _httpContextAccessor.HttpContext.User.Identity.Name);
            }

            return autor?.Avatar;
        }
    }
}
