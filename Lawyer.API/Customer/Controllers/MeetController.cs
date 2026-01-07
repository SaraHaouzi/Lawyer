using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetController : Controller
    {
         private readonly DataContext _dataContext;
        public MeetController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // GET: api/<MeetController>
        [HttpGet]
        public List<Meet> Get()
        {
            return _dataContext.Meets;
        }

        // GET api/<MeetController>/{Id}
        [HttpGet("{Id}")]
        public ActionResult<Meet> Get(int Id )
        {
            Meet m = _dataContext.Meets.Find(e => e.Id == Id);
            if (m is null)
                return NotFound();
            return m;
        }
        // POST api/<MeetController>
        [HttpPost]
        public void Post([FromBody] Meet m)
        {
            _dataContext.Meets.Add(new Meet {Id=m.Id,CustomerId=m.CustomerId,LawyerId=m.LawyerId, Date =m.Date, Hour = m.Hour, Durationofmeeting = m.Durationofmeeting });
        }

        // PUT api/<MeetController>/{hour}
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, [FromBody] Meet m)
        {
            if (m is null)
                return NotFound();
            Meet mPut = _dataContext.Meets.Find(e => e.Id == Id);
            if (mPut == null)
                return BadRequest();
            mPut.Id = m.Id; 
            mPut.CustomerId= m.CustomerId;
            mPut.LawyerId=m.LawyerId;
            mPut.Date = m.Date;
            mPut.Hour = m.Hour;
            mPut.Durationofmeeting = m.Durationofmeeting;
            return NoContent();
        }

        // DELETE api/<MeetController>/5
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Meet mDelete = _dataContext.Meets.Find(e => e.Id == Id);
            if (null == mDelete)
                return NotFound();
            _dataContext.Meets.Remove(mDelete);
            return NoContent();
        }
    }
}
