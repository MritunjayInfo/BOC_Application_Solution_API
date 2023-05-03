using BOCApplication.Model.DTO.CreatetableDTO;
using BOCApplication.Model.DTO.SectionsDTO;
using BOCApplication.Repositoy.SectionsService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOCApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionsController : ControllerBase
    {
        private readonly ISectionRepository _sectionRepository;
        public SectionsController(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }
        [HttpGet("List/{UserId}")]
        public async Task<IActionResult> GetSection(int UserId)
        {
            var res = await _sectionRepository.GetSectionsAsync(UserId);
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> AddSections(CreateSections createSections)
        {
            var exist = await _sectionRepository.GetSectionsAsyncByName(createSections.Name, createSections.UserId);
            if(exist != null)
            {
                return BadRequest($"This {createSections.Name} is already exits");
            }
            var res  =  await _sectionRepository.AddSectionsAsync(createSections);
             return Ok(res);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetSectionbyId(int Id)
        {
            var res = await _sectionRepository.GetSectionsAsyncById(Id);
            if(res == null)
            {
                return BadRequest($"This {Id} is not exist");
            }
            return Ok(res);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var res = await _sectionRepository.DeleteAsync(Id);
            return res == false ? BadRequest($"this{Id} is not availbale") : Ok($"Section is Deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSection(UpdateSection updateSection)
        {
            var res = await _sectionRepository.UpdateSectionsAsync(updateSection);
            return Ok(res);
        }
    }
}
