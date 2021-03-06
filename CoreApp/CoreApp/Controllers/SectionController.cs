using CoreApp.Data.Dtos;
using CoreApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreApp.Controllers;
[Route("api/section")]
[ApiController]
public class SectionController : ControllerBase
{
    private readonly ISectionService _service;

    public SectionController(ISectionService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<ReadSectionDto>> GetAll()
    {
        var result = _service.GetAll();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public ActionResult<ReadSectionDto> GetById([FromRoute] int id)
    {
        var result = _service.GetById(id);
        return Ok(result);
    }

    [HttpGet("{id}/project")]
    public ActionResult<List<ReadSectionDto>> GetAllSections([FromRoute] int id)
    {
        var result = _service.GetAllSections(id);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public ActionResult PutSection([FromRoute] int id, [FromBody] CreateSectionDto dto)
    {
        _service.PutSection(id, dto);
        return Ok();
    }

    [HttpPatch("{id}")]
    public ActionResult PatchSection([FromRoute] int id, [FromBody] CreateSectionDto dto)
    {
        _service.PatchSection(id, dto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        _service.Delete(id);
        return NoContent();
    }

    [HttpPost]
    public ActionResult Create([FromBody] CreateSectionDto dto)
    {
        var id = _service.Create(dto);
        return Created($"/api/section/{id}", null);
    }
}