using System.Threading.Tasks;
using BLL.Services;
using BLL.ViewModel;
using DLL.EFCORE.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class CashingController : ControllerBase
    {
        private readonly IApplicationCashingService _cashingService;

        public CashingController(IApplicationCashingService cashingService)
        {
            _cashingService = cashingService;
        }

        [HttpGet("{key}")]
        public async Task<IActionResult> Index(string key)
        {
            return Ok(await _cashingService.GetData(key));
        }
        
        [HttpPost("insert-department")]
        public async Task<IActionResult> AddDepartment(RedisStorageViewModel redisData)
        {
            await _cashingService.SaveData(redisData.Key, redisData.Value);
            return Ok("store data successfully");
        }
    }
}