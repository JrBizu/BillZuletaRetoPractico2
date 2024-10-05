

using Application.Common.Interfaces;
using Application.UseCases.Common.Handlers;
using Application.UseCases.Common.Results;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Logs.Commands.CreateLog
{
    public class CreateLogCommand : CreateLogCommandModel, IRequest<Result<CreateLogCommandDto>>
    {
        public class CreateFileCommandHandler(
        IRepository<LogEntity> repository) : UseCaseHandler, IRequestHandler<CreateLogCommand, Result<CreateLogCommandDto>>
        {
            public async Task<Result<CreateLogCommandDto>> Handle(CreateLogCommand request, CancellationToken cancellationToken)
            {
                //var cosmosDB = new CosmosDB(configuration);

                foreach (var transaction in request.Logs)
                {
                    var file = new LogEntity
                    {
                        id = transaction.Id,
                        Type = transaction.Type,
                        Descripcion = transaction.Descripcion,
                        CreatedDate = transaction.CreatedDate,
                    };

                    //await cosmosDB.InsertDataOperation(file);
                    await repository.CreateLogAsync(file);
                }

                var resultData = new CreateLogCommandDto { Created = true };

                return Succeded(resultData);
            }
        }
    }
}
