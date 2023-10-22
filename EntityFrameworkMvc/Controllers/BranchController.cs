using EntityFrameworkMvc.Dtos;
using EntityFrameworkMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkMvc.Controllers
{
    [ApiController]
    [Route("api/branchs")]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _BranchService;

        public BranchController(IBranchService service)
        {
            _BranchService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_BranchService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] SaveBranchDto dto)
        {
            _BranchService.Save(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SaveBranchDto dto)
        {
            _BranchService.Update(id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _BranchService.Delete(id);
            return Ok();
        }
    }
}
