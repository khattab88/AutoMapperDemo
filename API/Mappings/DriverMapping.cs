using API.Dtos.Request;
using API.Models;
using AutoMapper;

namespace API.Mappings
{
    public class DriverMapping : Profile
    {
        public DriverMapping()
        {
            CreateMap<CreateDriverDto, Driver>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.DriverNumber, opt => opt.MapFrom(src => src.DriverNumber))
                .ForMember(dest => dest.Trophies, opt => opt.MapFrom(src => src.Trophies))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => 1))
                .ForMember(dest => dest.DateAdded, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.DateUpdated, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}
