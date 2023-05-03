using BOCApplication.Model.DTO.CreatetableDTO;
using BOCApplication.Model.DTO.ProcessDTO;
using BOCApplication.Repositoy.ProcessService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOCApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        private readonly IProcessRepository _processRepository;
        public ProcessController(IProcessRepository processRepository)
        {
            _processRepository = processRepository;
        }
        [HttpGet("List/{UserId}")]
        public async Task<IActionResult> GetProcess(int UserId)
        {
            var res= await _processRepository.GetProcessAsync(UserId);
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProcess(CreateProcess createProcess)
        {
            var exitsProcess = await _processRepository.GetProcessAsyncByCode(createProcess.Code,createProcess.UserId);
            if (exitsProcess != null)
            {
                return BadRequest($"this {createProcess.Code} is already exits");
            }
            var res = await _processRepository.AddProcessAsync(createProcess);
            return Ok(res);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProcessAsync(int id)
        {
            var exitsProcess = await _processRepository.GetProcessAsyncById(id);
            if (exitsProcess == null)
            {
                return BadRequest("Process not exits");
            }
            return Ok(exitsProcess);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var res = await _processRepository.DeleteAsync(Id);
            return res == false ? BadRequest($"this{Id} is not availbale") : Ok($"Process is Deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProcess(UpdateProcess updateProcess)
        {
            var res = await _processRepository.UpdateProcessAsync(updateProcess);
            return Ok(res);
        }
    }
}
