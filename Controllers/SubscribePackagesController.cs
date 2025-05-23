using BlazorApp1.Dto;
using BlazorApp1.Models;
using EltafawkPlatform.Dto;
using EltafawkPlatform.Services;
using Humanizer;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class SubscribePackagesController : ControllerBase
{
    private readonly SubscribePackageService _service;

    public SubscribePackagesController(SubscribePackageService service)
    {
        _service = service;
    }
    [HttpGet]
    public async Task<ActionResult<List<SubscribePackageDto>>> GetAll()
    {
        //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //if (userId == null)
        //{
        //    // user not logged in
        //    return Unauthorized();
        //}
        var offers = await _service.GetAllAsync();
        var dtos = offers.Select(c => c.ToDto()).ToList();
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SubscribePackageDto>> Get(string id)
    {
        var model = await _service.GetByIdAsync(id);
        if (model is null)
            return NotFound();

        return SubscribePackageMapper.ToDto(model);
    }


    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] SubscribePackageDto dto)
    {
        var model = SubscribePackageMapper.ToModel(dto);
        await _service.CreateAsync(model);
        return Ok();
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] SubscribePackageDto dto)
    {
        var existing = await _service.GetByIdAsync(id);
        if (existing == null)
            return NotFound();

        existing.UpdateModel(dto);
        await _service.UpdateAsync(id,existing);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var deleted = await _service.DeleteAsync(id);
        return deleted ? Ok() : NotFound();
    }
}
