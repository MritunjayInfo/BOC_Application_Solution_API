using BOCApplication.Data;
using BOCApplication.Model.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOCApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreferredFormController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public PreferredFormController(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetForm()
        {
            var res = _db.PreferredForms.ToList();
            return Ok(res);
        }

    }
}
