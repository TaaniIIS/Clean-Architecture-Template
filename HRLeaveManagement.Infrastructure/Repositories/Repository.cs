using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HRLeaveManagement.Infrastructure.Repositories
{
    // This is a generic repository class that implements the IRepository interface.
    // It allows CRUD operations on any entity class 'T' (like Position, Category, etc.).
    public class Repository<T> : IRepository<T> where T : class
    {
        // Dependency injection of the application's database context.
        // This context allows the repository to communicate with the database.
        internal readonly ApplicationDbContext _applicationDbContext;

        // Constructor that receives the ApplicationDbContext from DI and stores it.
        public Repository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        // Retrieves all records of type T from the database asynchronously.
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            // Uses EF Core to access the DbSet<T> and convert it to a list.
            var list = await _applicationDbContext.Set<T>().ToListAsync();
            return list;
        }

        // Adds a new entity of type T to the database asynchronously.
        public async Task<T> AddAsync(T entity)
        {
            // Adds the entity to the DbSet<T> (but not saved yet).
            await _applicationDbContext.Set<T>().AddAsync(entity);

            // Saves the changes to the database.
            await _applicationDbContext.SaveChangesAsync();

            // Returns the newly added entity (with DB-generated values like ID).
            return entity;
        }

        // Deletes the given entity of type T from the database.
        public async Task DeleteAsync(T entity)
        {
            // Marks the entity as deleted in the DbSet<T>.
            _applicationDbContext.Set<T>().Remove(entity);

            // Saves the change (delete) to the database.
            await _applicationDbContext.SaveChangesAsync();
        }

        // Retrieves a single entity by its primary key ID.
        public async Task<T> GetByIdAsync(int id)
        {
            // Finds the entity in the DbSet<T> using its key.
            return await  _applicationDbContext.Set<T>().FindAsync(id);
        }

        // Updates an existing entity in the database.
        public async Task UpdateAsync(T entity)
        {
            // Tells EF Core that the entity has been modified.
            _applicationDbContext.Entry(entity).State = EntityState.Modified;

            // Saves the updated entity to the database.
            await _applicationDbContext.SaveChangesAsync();
        }
    }

}
