using CoreApp.Data.Dtos;
using CoreApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreApp.Controllers;
[Route("/api/role")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IRoleService _service;

    public RoleController(IRoleService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<ReadRoleDto>> GetAll()
    {
        var result = _service.GetAll();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public ActionResult<ReadRoleDto> GetById([FromRoute] int id)
    {
        var result = _service.GetById(id);
        return Ok(result);
    }

    [HttpGet("{id}/student")]
    public ActionResult<List<ReadStudentDto>> GetAllStudents([FromRoute] int id)
    {
        var result = _service.GetAllStudents(id);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public ActionResult PutRole([FromRoute] int id, [FromBody] CreateRoleDto dto)
    {
        _service.PutRole(id, dto);
        return Ok();
    }

    [HttpPatch("{id}")]
    public ActionResult PatchRole([FromRoute] int id, [FromBody] CreateRoleDto dto)
    {
        _service.PatchRole(id, dto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        _service.Delete(id);
        return NoContent();
    }

    [HttpPost]
    public ActionResult Create([FromBody]CreateRoleDto dto)
    {
        var id = _service.Create(dto);
        return Created($"/api/role/{id}", null);
    }
}