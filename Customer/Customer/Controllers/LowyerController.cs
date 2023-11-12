using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LowyerController : ControllerBase
    {
        private static int cnt = 2;
        private static List<Lawyer> lawyers = new List<Lawyer>
        {
            new Lawyer
            {
                Id = 1,
                Name="yossef",
                Age=40
            }
        };
        // GET: api/<LawyerController>
        [HttpGet]
        public List<Lawyer> Get()
        {
            return lawyers;
        }

        // GET api/<LawyerController>/5
        [HttpGet("{id}")]
        public ActionResult<Lawyer> Get(int id)
        {
            Lawyer lawyer = lawyers.Find(e => e.Id == id);
            if (lawyer is null)
                return NotFound();
            return lawyer;
        }
        // POST api/<LawyerController>
        [HttpPost]
        public void Post([FromBody] Lawyer l)
        {
            lawyers.Add(new Lawyer { Id = cnt++, Name = l.Name, Age = l.Age });
        }

        // PUT api/<LawyerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Lawyer l)
        {
            if (l is null)
                return NotFound();
            Lawyer lPut = lawyers.Find(e => e.Id == id);
            if (lPut == null)
                return BadRequest();
            lPut.Id = l.Id;
            lPut.Name = l.Name;
            lPut.Age = l.Age;
            return NoContent();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Lawyer lDelete = lawyers.Find(e => e.Id == id);
            if (null == lDelete)
                return NotFound();
            lawyers.Remove(lDelete);
            return NoContent();
        }
    }
}
