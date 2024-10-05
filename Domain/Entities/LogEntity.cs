
namespace Domain.Entities
{
    public class LogEntity : BaseEntity
    {
        public string? Type { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
