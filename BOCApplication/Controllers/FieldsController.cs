using BOCApplication.Model.DTO.CreatetableDTO;
using BOCApplication.Model.DTO.FieldsDTO;
using BOCApplication.Model.DTO.ProcessDTO;
using BOCApplication.Repositoy.FieldsService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOCApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldsController : ControllerBase
    {
        private readonly IFieldsRepository _fieldsRepository;
        public FieldsController(IFieldsRepository fieldsRepository)
        {
            _fieldsRepository = fieldsRepository;
        }
        [HttpGet("List/{UserId}")]
        public async Task<IActionResult> GetField(int UserId)
        {
            var res = await _fieldsRepository.GetFieldsAsync(UserId);
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> AddField(CreateFields createFields)
        {
            var ExistFields = await _fieldsRepository.GetFieldsAsyncByType(createFields.Type, createFields.UserId);
            if (ExistFields != null) return BadRequest($"this {createFields.Type} is already exits");
            var res = await _fieldsRepository.AddFieldsAsync(createFields);
            return Ok(res); 
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetFieldById(int Id)
        {
            var res = await _fieldsRepository.GetFieldsAsync(Id);
            if(res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var res = await _fieldsRepository.DeleteAsync(Id);
            return res == false ? BadRequest($"this{Id} is not availbale") : Ok($"Field is Deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFieldsAsync(UpdateFields updateFields)
        {
            var ExistFields = await _fieldsRepository.GetFieldsAsyncByType(updateFields.Type, updateFields.UserId);
            if (ExistFields.Id != updateFields.Id)
            {
                return BadRequest($" This Field ({updateFields.Type}) allready exist");
            }
            var res = await _fieldsRepository.UpdateFieldsAsync(updateFields);
            return Ok(res);
        }
    }
}
