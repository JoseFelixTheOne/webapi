using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TareaController : ControllerBase
{
    private readonly ITareaService tareaService;
    public TareaController(ITareaService tareaservice)
    {
        tareaService = tareaservice;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(tareaService.Get());
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Tarea tarea)
    {
        await tareaService.Save(tarea);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id,[FromBody] Tarea tarea)
    {
        await tareaService.Update(id,tarea);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await tareaService.Delete(id);
        return Ok();
    }
}