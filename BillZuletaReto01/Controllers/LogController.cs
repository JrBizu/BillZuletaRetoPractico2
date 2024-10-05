using Application.UseCases.Logs.Commands.CreateLog;
using Application.UseCases.Logs.Queries.GetLogs;
using BillZuletaReto01.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace BillZuletaReto02.Controllers
{
    public class LogController : BaseController
    {
        [HttpGet]
        [Route("GetAll")]
        [Produces(typeof(GetLogsQueryDto))]
        [ActionName(nameof(GetAll))]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetLogsQuery();
            var result = await this.Mediator.Send(query);
            return this.FromResult(result);
        }

        [HttpPost]
        [Route("Create")]
        [Produces(typeof(CreateLogCommandDto))]
        [ActionName(nameof(Create))]
        public async Task<IActionResult> Create(CreateLogCommandModel model)
        {
            var command = this.Mapper.Map<CreateLogCommand>(model);
            var result = await this.Mediator.Send(command);
            return this.FromResult(result);
        }
    }
}
