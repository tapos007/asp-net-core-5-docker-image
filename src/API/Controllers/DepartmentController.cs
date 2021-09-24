using System.Threading.Tasks;
using BLL.Services;
using DLL.EFCORE.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("all-department")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _departmentService.GetAll());
        }
        
        [HttpPost("insert-department")]
        public async Task<IActionResult> AddDepartment(Department department)
        {
            
            return Ok(await _departmentService.Add(department));
        }
    }
}