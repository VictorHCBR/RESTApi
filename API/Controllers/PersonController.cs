using API.Model;
using API.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController(IPersonService person) : ControllerBase
{
    private readonly IPersonService _person = person;

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_person.FindAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
    {
        var person = _person.FindById(id);

        if (person == null)
            return NotFound();

        return Ok(person);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Person person)
    {
        if (person == null)
            return BadRequest();

        return Ok(_person.Create(person));
    }

    [HttpPut]
    public IActionResult Put([FromBody] Person person)
    {
        if (person == null)
            return BadRequest();

        return Ok(_person.Update(person));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var person = _person.FindById(id);

        if (person == null)
            return NotFound();

        return NoContent();
    }
}