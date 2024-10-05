using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IRepository<T>
        where T : BaseEntity
    {
        //IQueryable<T> ListarTodos();

        //Task<IEnumerable<T>> ListarTodosAsync();

        //Task<T?> ObtenerPorIdAsync(Guid id);

        //Task<T> ObtenerPorIdAsync(string id);

        //Task AgregarAsync(T entity);

        //Task ActualizarAsync(T entity);

        //Task EliminarAsync(T entity);

        //Task<IEnumerable<T>> ExecuteStoredProcedure(string query);

        Task CreateLogAsync(T entity);
    }
}
