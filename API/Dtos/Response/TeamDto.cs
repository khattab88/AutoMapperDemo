using API.Mappings;
using API.Models;

namespace API.Dtos.Response
{
    public class TeamDto : IMapFrom<Team>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
