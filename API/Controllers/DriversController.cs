using API.Dtos.Request;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private static List<Driver> drivers = new List<Driver>()
        {
            new Driver(){ Id=Guid.NewGuid(), FirstName="Michael", LastName="Schomacher", DateAdded=DateTime.Now, DriverNumber=1, Status=1, Trophies=7 },
            new Driver(){ Id=Guid.NewGuid(), FirstName="Louis", LastName="Hamilton", DateAdded=DateTime.Now, DriverNumber=2, Status=1, Trophies=5 },
        };

        private readonly ILogger<DriversController> _logger;
        private readonly IMapper _mapper;

        public DriversController(ILogger<DriversController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        // get all drivers
        [HttpGet]
        public IActionResult Get()
        {
            var activeDrivers = drivers.Where(d => d.Status == 1).ToList();

            return Ok(activeDrivers);
        }

        // create driver
        [HttpPost]
        public IActionResult Create([FromBody] CreateDriverDto createDto)
        {
            if (ModelState.IsValid)
            {
                //var driver = new Driver 
                //{
                //    Id = Guid.NewGuid(),
                //    Status = 1,
                //    DateAdded = DateTime.Now,
                //    FirstName = createDto.FirstName,
                //    LastName = createDto.LastName,
                //    DriverNumber = createDto.DriverNumber,
                //    Trophies = createDto.Trophies,
                //};

                var driver = _mapper.Map<Driver>(createDto);

                drivers.Add(driver);
                return Created("", driver);
            }

            ModelState.AddModelError("", "invalid driver");
            return BadRequest(ModelState);
        }

        // get driver by id
        [HttpGet]
        [Route("{id}", Name = "GetDriver")]
        public IActionResult Get(Guid id)
        {
            var driver = drivers.FirstOrDefault(d => d.Id == id);

            if (driver is null) return NotFound();

            return Ok(driver);
        }

        // update driver
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Driver driver)
        {
            if (driver.Id != id) return BadRequest();

            var existing = drivers.FirstOrDefault(d => d.Id == id);

            if(existing is null) return NotFound();

            existing.DriverNumber = driver.DriverNumber;
            existing.Status = existing.Status;
            existing.Trophies = driver.Trophies;
            existing.DateUpdated = DateTime.Now;

            return NoContent();
        }

        // delete driver
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var existing = drivers.FirstOrDefault(d => d.Id == id);

            if (existing is null) return NotFound();

            drivers.Remove(existing);

            return NoContent();
        }
    }
}
