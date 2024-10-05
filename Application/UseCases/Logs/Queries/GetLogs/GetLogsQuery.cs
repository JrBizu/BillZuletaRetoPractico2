
using Application.Common.Interfaces;
using Application.UseCases.Common.Handlers;
using Application.UseCases.Common.Results;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Transactions;

namespace Application.UseCases.Logs.Queries.GetLogs
{
    public class GetLogsQuery : IRequest<Result<GetLogsQueryDto>>
    {
        public class GetLogsQueryHandler(IRepository<LogEntity> repository) : UseCaseHandler, IRequestHandler<GetLogsQuery, Result<GetLogsQueryDto>>
        {
            public async Task<Result<GetLogsQueryDto>> Handle(GetLogsQuery request, CancellationToken cancellationToken)
            {
                //var result = await repository.GellAllLogsAsync();

                //var logs = result.Select(x => new GetLogsQueryValueDto
                //{
                //    Id = x.Id,
                //    Type = x.Type,
                //    Descripcion = x.Descripcion,
                //    CreatedDate = x.CreatedDate,
                //}).ToList();
                List<GetLogsQueryValueDto> oLista = new List<GetLogsQueryValueDto>();

                var result = repository.GetLogsAsync();

                var logs = result.Select(x => new GetLogsQueryValueDto
                {
                    id = x.id,
                    Type = x.Type,
                    Descripcion = x.Descripcion,
                    CreatedDate = x.CreatedDate,
                }).ToList();

                //var logs = new GetLogsQueryValueDto
                //{
                //    id = new Guid(),
                //    Type = "Prueba Type",
                //    Descripcion = "Prueba Descripcion",
                //    CreatedDate = new DateTime()
                //};

                //oLista.Add(logs);

                var response = new GetLogsQueryDto()
                {
                    Logs = logs
                };

                return Succeded(response);
            }
        }
    }
}
