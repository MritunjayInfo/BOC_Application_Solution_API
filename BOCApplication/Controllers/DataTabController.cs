using BOCApplication.Model.DTO.CreatetableDTO;
using BOCApplication.Model.DTO.DataTabDTO;
using BOCApplication.Repositoy.DataTabService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOCApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataTabController : ControllerBase
    {
        private readonly IDataTabRepository _dataTabRepository;
        public DataTabController(IDataTabRepository dataTabRepository)
        {
            _dataTabRepository = dataTabRepository;
        }
        [HttpGet("List/{UserId}")]
        public async Task<IActionResult> GetDataTabs(int UserId)
        {
            var res = await _dataTabRepository.GetDatatabsAsync(UserId);
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> AddDatatabs(CreateDatatabs createDatatabs)
        {
            var exist = await _dataTabRepository.GetDatatabsAsyncByCode(createDatatabs.Code, createDatatabs.CreateTableId);
            if(exist != null)
            {
                return BadRequest($"This{createDatatabs.Code} is already exits");
            }
            var res = await _dataTabRepository.AddDatatabsAsync(createDatatabs);
            return Ok(res);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetDatatabsbyId(int Id)
        {
            var res = await _dataTabRepository.GetDatatabsAsyncById(Id);
            if(res == null)
            {
                return BadRequest($"This{Id} is Not exits");
            }
            return Ok(res);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var res = await _dataTabRepository.DeleteAsync(Id);
            return res == false ? BadRequest($"this{Id} is not availbale") : Ok($"Datatab is Deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDatatabs(UpdateDatatabs updateDatatabs)
        {
            var res = await _dataTabRepository.UpdateDatatabsAsync(updateDatatabs);
            return Ok(res);
        }
    }
}
