using BOCApplication.Model.Domain;
using BOCApplication.Model.DTO.CreatetableDTO;
using BOCApplication.Model.DTO.TabsDTO;
using BOCApplication.Repositoy.TabsService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOCApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TabsController : ControllerBase
    {
        private readonly ITabsRepository _tabsRepository;
        public TabsController(ITabsRepository tabsRepository)
        {
            _tabsRepository = tabsRepository;
        }
        [HttpGet("List/{UserId}")]
        public async Task<IActionResult> GetTabs(int UserId)
        {
            var res = await _tabsRepository.GetTabsAsync(UserId);
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> AddTabs(CreateTabs createTabs)
        {
            var exist = await _tabsRepository.GetTabsAsyncByName(createTabs.Name,createTabs.UserId);
            if(exist != null)
            {
                return BadRequest($"This{createTabs.Name} is already exits");
            }
           var res = await _tabsRepository.AddTabsAsync(createTabs);
            return Ok(res);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetTabsById(int Id)
        {
            var res = await _tabsRepository.GetTabsAsyncById(Id);
            if(res == null)
            {
                return BadRequest($"This {Id} is not exist");
            }
            return Ok(res);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var res = await _tabsRepository.DeleteAsync(Id);
            return res == false ? BadRequest($"this{Id} is not availbale") : Ok($"Tab is Deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTabAsync(UpdateTab updateTab)
        {
            var res = await _tabsRepository.UpdateTabsAsync(updateTab);
            return Ok(res);
        }
    }
}
