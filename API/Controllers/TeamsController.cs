using API.Dtos.Response;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private static List<Team> teams = new List<Team>()
        {
            new Team { Id=1, Name="Ferrari", Country="Italy", DateCreated=DateTime.Now, DateUpdated=DateTime.Now },
            new Team { Id=2, Name="Mercides", Country="Germany", DateCreated=DateTime.Now, DateUpdated=DateTime.Now }
        };

        private readonly IMapper _mapper;

        public TeamsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var mapped = _mapper.Map<List<TeamDto>>(teams);

            return Ok(mapped);
        }
    }
}
