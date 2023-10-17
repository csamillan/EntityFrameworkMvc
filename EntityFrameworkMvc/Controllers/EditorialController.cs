using EntityFrameworkMvc.Dtos;
using EntityFrameworkMvc.Model;
using EntityFrameworkMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkMvc.Controllers
{
    [ApiController]
    [Route("api/editorials")]
    public class EditorialController : ControllerBase
    {
        private readonly IEditorialService _editorialService;

        public EditorialController(IEditorialService service)
        {
            _editorialService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_editorialService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] SaveEditorialDto dto)
        {
            _editorialService.Save(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SaveEditorialDto dto)
        {
            _editorialService.Update(id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _editorialService.Delete(id);
            return Ok();
        }
    }
}
