using BOCApplication.Model.DTO.CreatetableDTO;
using BOCApplication.Model.DTO.SubTabsDTO;
using BOCApplication.Repositoy.SubTabsService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOCApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubTabController : ControllerBase
    {
        private readonly ISubTabsRepository _subTabsRepository;
        public SubTabController(ISubTabsRepository subTabsRepository)
        {
            _subTabsRepository = subTabsRepository;
        }
        [HttpGet("List/{UserId}")]
        public async Task<IActionResult> GetSubTabs(int UserId)
        {
            var res = await _subTabsRepository.GetSubTabsAsync(UserId);
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> AddSubTabs(CreateSubTabs createSubTabs)
        {
            var exist = await _subTabsRepository.GetSubTabsAsyncByName(createSubTabs.Name, createSubTabs.UserId);
            if(exist != null)
            {
                return BadRequest($"This{createSubTabs.Name} is Already exist");
            }
            var res = await _subTabsRepository.AddSubTabsAsync(createSubTabs);
            return Ok(res);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetSubTabsById(int Id)
        {
            var res = await _subTabsRepository.GetSubTabsAsyncById(Id);
            if(res == null)
            {
                return BadRequest($"This{Id} is not exist");
            }
            return Ok(res);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var res = await _subTabsRepository.DeleteAsync(Id);
            return res == false ? BadRequest($"this{Id} is not availbale") : Ok($"SubTab is Deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSubTab(UpdateSubTab updateSubTab)
        {
            var res = await _subTabsRepository.UpdateSubTabsAsync(updateSubTab);
            return Ok(res);
        }

    }
}
