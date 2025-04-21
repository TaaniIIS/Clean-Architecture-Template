using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.CoreBusiness.Entity;

namespace HRLeaveManagement.Application.Interfaces
{
    // This interface defines a generic repository for basic CRUD operations.
    // T is a generic type that must be a class (reference type).
    public interface IRepository<T> where T : class
    {
        // Retrieves all entities of type T from the data source.
        // Returns a read-only list of T objects asynchronously.
        Task<IReadOnlyList<T>> GetAllAsync();
        //Task<List<T>> GetAllAsync();


        // Retrieves a single entity of type T by its unique identifier (id).
        Task<T> GetByIdAsync(int id);

        // Adds a new entity of type T to the data source.
        // Returns the added entity, which may now include a generated ID or other default values.
        Task<T> AddAsync(T entity);

        // Updates an existing entity of type T in the data source.
        Task UpdateAsync(T entity);

        // Deletes the given entity of type T from the data source.

        Task DeleteAsync(T entity);
        //Task<bool> DeleteAsync(T entity);
        //Task DeleteAsync(int id);

    }

}
