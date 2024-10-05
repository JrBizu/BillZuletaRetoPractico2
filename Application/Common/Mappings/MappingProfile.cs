

using Application.UseCases.Logs.Commands.CreateLog;
using AutoMapper;

namespace Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<CreateLogCommandModel, CreateLogCommand>();
        }
    }
}
