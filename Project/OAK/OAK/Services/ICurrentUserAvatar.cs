using OAK.Models;
using System.Threading.Tasks;

namespace OAK.Services
{
    public interface ICurrentUserAvatar
    {
        Task<byte[]> GetAvatar();
    }
}
