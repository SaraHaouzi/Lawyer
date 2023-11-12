using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetController : Controller
    {
        private static int cnt = 2;
        private static List<Meet> meets = new List<Meet>
        {
            new Meet
            {
                Date = DateTime.Now,
                Hour=13,
                Durationofmeeting=1
            }
        };
        // GET: api/<MeetController>
        [HttpGet]
        public List<Meet> Get()
        {
            return meets;
        }

        // GET api/<MeetController>/{Date}
        [HttpGet("{Date}")]
        public ActionResult<Meet> Get(DateTime date)
        {
            Meet m = meets.Find(e => e.Date == date);
            if (m is null)
                return NotFound();
            return m;
        }
        // POST api/<MeetController>
        [HttpPost]
        public void Post([FromBody] Meet m)
        {
            meets.Add(new Meet { Date =m.Date, Hour = m.Hour, Durationofmeeting = m.Durationofmeeting });
        }

        // PUT api/<MeetController>/{date}
        [HttpPut("{Date}")]
        public IActionResult Put(int hour, [FromBody] Meet m)
        {
            if (m is null)
                return NotFound();
            Meet mPut = meets.Find(e => e.Hour == hour);
            if (mPut == null)
                return BadRequest();
            mPut.Date = m.Date;
            mPut.Hour = m.Hour;
            mPut.Durationofmeeting = m.Durationofmeeting;
            return NoContent();
        }

        // DELETE api/<MeetController>/5
        [HttpDelete("{Date}")]
        public IActionResult Delete(DateTime date)
        {
            Meet mDelete = meets.Find(e => e.Date == date);
            if (null == mDelete)
                return NotFound();
            meets.Remove(mDelete);
            return NoContent();
        }
    }
}
