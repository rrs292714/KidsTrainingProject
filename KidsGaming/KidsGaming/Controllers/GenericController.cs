using KidsGaming.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KidsGaming.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<T> : Controller where T : class
    {
        private IGeneric<T> _igenric;
        public GenericController(IGeneric<T> igenric)
        {
            _igenric = igenric;
        }

        // GET: api/<GenricController>
        [HttpGet]
        public List<T> getall()
        {
            return _igenric.getall();
        }

        // GET api/<GenricController>/5
        [HttpGet("{id}")]
        public List<T> Getbyid(int id)
        {
            return _igenric.getbyId(id);
        }

        // POST api/<GenricController>
        [HttpPost]
        public List<T> Post([FromBody] T value)
        {
            return _igenric.Insert(value);
        }

        // DELETE api/<GenricController>/5
        [HttpDelete("{id}")]
        public List<T> Delete(int id)
        {
            return _igenric.delete(id);
        }
    }
}
