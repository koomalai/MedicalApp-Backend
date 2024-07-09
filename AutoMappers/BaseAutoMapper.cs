using AutoMapper;

namespace MedicalAppBackend.AutoMappers
{
    public static class BaseAutoMapper
    {
        public static Mapper CreateBaseAutoMapper<Tsource,Tdestination>()
        {
            var configuration = new MapperConfiguration(configuration =>
            {
                configuration.CreateMap<Tsource,Tdestination>();
            });
            return new Mapper(configuration);
        }
    }
}
