
namespace Application.UseCases.Logs.Commands.CreateLog
{
    public class CreateLogCommandValueModel
    {
        public Guid Id { get; set; }
        public required string Type { get; set; }
        public required string Descripcion { get; set; }
        public required DateTime CreatedDate { get; set; }

    }
}
