﻿
namespace Application.UseCases.Logs.Queries.GetLogs
{
    public class GetLogsQueryValueDto
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Descripcion { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
