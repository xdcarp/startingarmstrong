using AutoMapper;

namespace Armstrong.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.MapToDtos();
            this.MapToDomains();
        }
        public void MapToDtos()
        {
        }

        public void MapToDomains()
        {
        }
    }
}
