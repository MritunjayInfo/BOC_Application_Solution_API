using BOCApplication.Model.DTO.CreatetableDTO;
using BOCApplication.Repositoy.CreateTableService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOCApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateTableController : ControllerBase
    {
        private readonly ICreateTableRepository _createTableRepository;
        public CreateTableController(ICreateTableRepository createTableRepository)
        {
            _createTableRepository = createTableRepository;
        }
        [HttpGet("List/{UserId}")]
        public async Task<IActionResult> GetCreateTable(int UserId)
        {
            var res = await _createTableRepository.GetCreateTableAsync(UserId);
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> AddCreateTable(AddCreateTable addCreateTable)
        {
            var exist = await _createTableRepository.GetCreateTableAsyncByTableName(addCreateTable.TableName, addCreateTable.UserId);
            if(exist != null)
            {
                return BadRequest($"Table Name ({addCreateTable.TableName}) allready exist");
            }
            var res = await _createTableRepository.AddCreateTableAsync(addCreateTable);
            return Ok(res);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCreateTableById(int Id)
        {
            var res = await _createTableRepository.GetCreateTableAsyncById(Id);
            if (res == null) return BadRequest($"this{Id} is not availbale");
            return Ok(res);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
           var res =  await _createTableRepository.DeleteAsync(Id);
            return res == false ?BadRequest($"this{Id} is not availbale") : Ok($"CreateTable is Deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCreateTable(UpdateCreateTable updateCreateTable)
        {
            
            var res = await _createTableRepository.UpdateCreateTableAsync(updateCreateTable);
            return Ok(res);
        }
    }
}
