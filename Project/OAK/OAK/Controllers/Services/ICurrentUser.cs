using OAK.Models;
using System.Threading.Tasks;

namespace OAK.Controllers.Services
{
    public interface ICurrentUser
    {
        Task<Autor> GetInformation();
    }
}
