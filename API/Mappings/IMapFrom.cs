using AutoMapper;

namespace API.Mappings
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile mappingProfile) => mappingProfile.CreateMap(typeof(T), GetType());
    }
}
