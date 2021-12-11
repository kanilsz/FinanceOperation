using AutoMapper;

namespace FinanceOperation.Core.Mapping
{
    public interface IMapFrom<T>
    {
        void MapFrom(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
