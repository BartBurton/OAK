using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OAK.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OAK.Services
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

        public async Task<Autor> GetCurrentUser()
        {
            Autor autor = null;

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated == true)
            {
                autor = await _oak.Autors
                    .Where(a => a.Email == _httpContextAccessor.HttpContext.User.Identity.Name)
                    .FirstOrDefaultAsync();
            }

            return autor;
        }
    }
}