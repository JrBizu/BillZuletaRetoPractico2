using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Common.Factories;
using Infrastructure.Data;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Documents.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : BaseEntity
    {
        //        private readonly ApplicationDbContext _context;

        //        public Repository(IDbContextFactory factory)
        //        {
        //            _context = (ApplicationDbContext)factory.Create();
        //        }

        //        protected DbSet<T> Set => _context.Set<T>();

        //        public IQueryable<T> ListarTodos()
        //        {
        //            return Set.AsQueryable<T>();
        //        }

        //        public async Task<IEnumerable<T>> ListarTodosAsync()
        //        {
        //            return await Set.ToListAsync();
        //        }

        //        public async Task<T?> ObtenerPorIdAsync(Guid id)
        //        {
        //            return await Set.FindAsync(id);
        //        }

        //        public async Task<T> ObtenerPorIdAsync(string id)
        //        {
        //#pragma warning disable CS8603 // Possible null reference return.
        //            return await Set.FindAsync(id);
        //#pragma warning restore CS8603 // Possible null reference return.
        //        }

        //        public async Task AgregarAsync(T entity)
        //        {
        //            await Set.AddAsync(entity);
        //            await GuardarAsync();
        //        }

        //        public async Task ActualizarAsync(T entity)
        //        {
        //            Set.Update(entity);
        //            await GuardarAsync();
        //        }

        //        public async Task EliminarAsync(T entity)
        //        {
        //            Set.Remove(entity);
        //            await GuardarAsync();
        //        }

        //        public async Task<IEnumerable<T>> ExecuteStoredProcedure(string query)
        //        {
        //            return await Set.FromSqlRaw(query).ToListAsync();
        //        }

        //        ///////////////////////////// Private Methods ///////////////////////////////
        //        private async Task GuardarAsync()
        //        {
        //            await _context.SaveChangesAsync();
        //        }

        private readonly CosmosClient _cosmosClient;
        private readonly DocumentClient _documentClient;
        private readonly Database _database;
        private readonly string _ContainerName;
        private readonly string _DatabaseName;

        public Repository(IConfiguration configuration)
        {
            var ConnectionString = configuration.GetSection("CosmosDB:ConnectionString").Value ?? string.Empty;
            var Key = configuration.GetSection("CosmosDB:Key").Value ?? string.Empty;
            _DatabaseName = configuration.GetSection("CosmosDB:DatabaseName").Value ?? string.Empty;
            _ContainerName = configuration.GetSection("CosmosDB:ContainerName").Value ?? string.Empty;

            _cosmosClient = new CosmosClient(ConnectionString, Key);
            _documentClient = new DocumentClient(new Uri(ConnectionString), Key);
            _database = _cosmosClient.GetDatabase(_DatabaseName);
        }

        public async Task CreateLogAsync(T entity)
        {
            var container = await _database.CreateContainerIfNotExistsAsync(_ContainerName, $"/{_DatabaseName}");

            await container.Container.CreateItemAsync<T>(entity);
        }

        public List<LogEntity> GetLogsAsync()
        {
            FeedOptions options = new FeedOptions() { MaxItemCount = -1 };
            string sql = "SELECT * FROM C";
            Uri uri = UriFactory.CreateDocumentCollectionUri(_DatabaseName, _ContainerName);
            IQueryable<LogEntity> consulta = this._documentClient.CreateDocumentQuery<LogEntity>(uri, sql, options);

            return consulta.ToList();
        }
    }
}
