using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OAK.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace OAK.Controllers.Services
{
    public class CurrentUser : ICurrentUser
    {
        private readonly OAKContext _oak;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUser(OAKContext oak, IHttpContextAccessor httpContextAccessor)
        {
            _oak = oak;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Autor> GetInformation()
        {
            Autor autor = null;

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated == true)
            {
                autor = await _oak.Autors.FirstOrDefaultAsync(a => 
                a.Email == _httpContextAccessor.HttpContext.User.Identity.Name);
            }

            return autor;
        }
    }
}
