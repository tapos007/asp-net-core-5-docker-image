using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace BLL.Services
{
    public interface IApplicationCashingService
    {
        Task SaveData(string key, string value);
        Task<string> GetData(string key);
    }

    public class ApplicationCashingService : IApplicationCashingService
    {
        private readonly IDistributedCache _cache;


        public ApplicationCashingService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task SaveData(string key, string value)
        {
            await _cache.SetStringAsync(key, value);
        }

        public  async Task<string> GetData(string key)
        {
            return await _cache.GetStringAsync(key);
            
        }
    }
}