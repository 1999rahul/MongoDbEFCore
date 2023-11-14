using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EfCoreMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        MongoDbContext db;
        public StudentsController(MongoDbContext mongoDbContext)
        {
            db = mongoDbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var res = db.students.ToList().Select(p => new
            {
                Id = p.Id.ToString(),
                Name = p.Name,
                Age = p.Age,
            });
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Student student)
        {
            await db.students.AddAsync(student);
            await db.SaveChangesAsync();

            return Ok(HttpStatusCode.Created);
        }
    }
}
