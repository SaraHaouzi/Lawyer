using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Security;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private static int cnt = 2;
        private readonly DataContext _dataContext ;
        // GET: api/<CustomerController>
        public CustomerController(DataContext Context)
        {
            _dataContext = Context;
        }
        [HttpGet]
        public List<Customer> Get()
        {
            return _dataContext.Customers;
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            Customer castomer = _dataContext.Customers.Find(e => e.Id == id);
            if (castomer is null)
                return NotFound();
            return castomer;
        }
        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] Customer c)
        {
            _dataContext.Customers.Add(new Customer { Id=cnt++,Name=c.Name,Age=c.Age});
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Customer c)
        {
            if (c is null)
                return NotFound();
            Customer cPut = _dataContext.Customers.Find(e => e.Id == id);
            if(cPut == null) 
                return BadRequest();
            cPut.Id = c.Id;
            cPut.Name = c.Name;
            cPut.Age = c.Age;
            return NoContent();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Customer cDelete = _dataContext.Customers.Find(e => e.Id == id);
            if(null == cDelete)
            return NotFound();
            _dataContext.Customers.Remove(cDelete);
            return NoContent(); 
        }
    }
}
