using OAK.Models;
using System.Threading.Tasks;

namespace OAK.Services
{
    public interface ICurrentUser
    {
        Task<Autor> GetCurrentUser();
    }
}
