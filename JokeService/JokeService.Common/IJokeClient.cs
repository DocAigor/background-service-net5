using System.Threading.Tasks;

namespace JokeService.Common
{
    public interface IJokeClient
    {
        Task<string> GetJokeAsync();
    }
}