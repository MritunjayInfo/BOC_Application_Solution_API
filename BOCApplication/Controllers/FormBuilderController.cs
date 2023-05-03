using BOCApplication.Model.DTO.CreatetableDTO;
using BOCApplication.Model.DTO.FormBuilderDTO;
using BOCApplication.Repositoy.FormBuilderService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOCApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormBuilderController : ControllerBase
    {
        private readonly IFormBuilderRepository _formBuilderRepository;
        public FormBuilderController(IFormBuilderRepository formBuilderRepository)
        {
            _formBuilderRepository = formBuilderRepository;
        }
        [HttpGet("List/{UserId}")]
        public async Task<IActionResult> GetFormBuilder(int UserId)
        {
            var res = await _formBuilderRepository.GetFormBuilderAsync(UserId);
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> AddFormBuilder(CreateFormBuilder createFormBuilder)
        {
            var existFormbuilder = await _formBuilderRepository.GetFormBuilderAsyncByForm(createFormBuilder.Form, createFormBuilder.ProcessId);
            if(existFormbuilder != null)
            {
                return BadRequest($"This {createFormBuilder.Form} name is already exist");
            }
            var res  = await _formBuilderRepository.AddFormBuilderAsync(createFormBuilder);
            return Ok(res);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFormBuilderById(int id)
        {
            var res = await _formBuilderRepository.GetFormBuilderAsyncById(id);
            return Ok(res);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var res = await _formBuilderRepository.DeleteAsync(Id);
            return res == false ? BadRequest($"this{Id} is not availbale") : Ok($"FormBuilder is Deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFormBuilder(UpdateFormBuilder updateFormBuilder)
        {
            var existFormbuilder = await _formBuilderRepository.GetFormBuilderAsyncByForm(updateFormBuilder.Form, updateFormBuilder.ProcessId);
            if (existFormbuilder.Id != updateFormBuilder.Id)
            {
                return BadRequest($"This Formbuilder ({updateFormBuilder.Form}) allready exist");
            }
            var res = await _formBuilderRepository.UpdateFormBuilderAsync(updateFormBuilder);
            return Ok(res);
        }
    }
}
