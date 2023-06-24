using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class WorkOrderController : ControllerBase
{
    // GET: api/<WorkOrderController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<WorkOrderController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<WorkOrderController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<WorkOrderController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<WorkOrderController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
