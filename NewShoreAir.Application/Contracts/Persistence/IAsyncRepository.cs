using System.Linq.Expressions;
using NewShoreAir.Domain.Common;

namespace NewShoreAir.Application.Contracts.Persistence
{
    //va a ser un interface que toma valores genericos
    //desde T donde T debe ser de tipo BaseDomainModel
    public interface IAsyncRepository<T> where T : BaseDomainModel
    {
        //Trae la lista de todas las fila de tipo generico <T>
        Task<IReadOnlyList<T>> GetAllAsync();

        //Trae datos de las entidades a partir de una condicion
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

        //Trae datos de las entidades a partir de una condicion, permite ordenar los resultados
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                     Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                     string? includeString = null,
                                     bool disableTracking = true);

        //Trae datos de las entidades a partir de una condicion, permite ordenar los resultados,
        //realizar includes de otras entidades relacionadas y habilitar o desabilitar el tracking
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                     Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                     List<Expression<Func<T, object>>> includes = null,
                                     bool disableTracking = true);

        //Metodo para obtener una entidad por el Id
        Task<T> GetByIdAsync(int id);

        //Agregar un nuevo registro
        Task<T> AddAsync(T entity);

        //Actualizar registro
        Task<T> UpdateAsync(T entity);

        //Eliminar registro
        Task DeleteAsync(T entity);

        void AddEntity(T entity);
        void UpdateEntity(T entity);
        void DeleteEntity(T entity);

    }
}
