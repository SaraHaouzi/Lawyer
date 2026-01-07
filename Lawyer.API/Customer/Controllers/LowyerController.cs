using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LowyerController : ControllerBase
    {
        private static int cnt = 2;
        public readonly DataContext _dataContext;
        public LowyerController(DataContext Context)
        {
            _dataContext = Context;
        }

        // GET: api/<LawyerController>
        [HttpGet]
        public List<Lawyer> Get()
        {
            return _dataContext.Lawyers;
        }

        // GET api/<LawyerController>/5
        [HttpGet("{id}")]
        public ActionResult<Lawyer> Get(int id)
        {
            Lawyer lawyer = _dataContext.Lawyers.Find(e => e.Id == id);
            if (lawyer is null)
                return NotFound();
            return lawyer;
        }
        // POST api/<LawyerController>
        [HttpPost]
        public void Post([FromBody] Lawyer l)
        {
            _dataContext.Lawyers.Add(new Lawyer { Id = cnt++, Name = l.Name, Age = l.Age });
        }

        // PUT api/<LawyerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Lawyer l)
        {
            if (l is null)
                return NotFound();
            Lawyer lPut = _dataContext.Lawyers.Find(e => e.Id == id);
            if (lPut == null)
                return BadRequest();
            lPut.Id = l.Id;
            lPut.Name = l.Name;
            lPut.seniority = l.seniority;
            return NoContent();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Lawyer lDelete = _dataContext.Lawyers.Find(e => e.Id == id);
            if (null == lDelete)
                return NotFound();
            _dataContext.Lawyers.Remove(lDelete);
            return NoContent();
        }
    }
}
