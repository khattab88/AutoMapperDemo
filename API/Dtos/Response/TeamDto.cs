using API.Mappings;
using API.Models;
using AutoMapper;

namespace API.Dtos.Response
{
    public class TeamDto : IMapFrom<Team>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Team, TeamDto>()
                .ForMember(dest => dest.DateUpdated, opt => opt.Ignore());
        }
    }
}
