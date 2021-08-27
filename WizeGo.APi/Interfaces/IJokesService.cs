using System.Threading.Tasks;
using WizeGo.APi.Models;

namespace WizeGo.APi.Interfaces
{
    public interface IJokesService
    {
        Task<Jokes> GetJoke(string category = null);
    }
}