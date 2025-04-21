using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Interfaces;
using HRLeaveManagement.CoreBusiness.Entity;
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

        // Retrieves a single entity by its primary key ID.
        // This method is generic and can be used for any entity type T.
        // It uses the FindAsync method to locate the entity in the DbSet<T> using its key.
        // The FindAsync method is optimized for primary key lookups.   
        // It returns null if the entity is not found.  
        // The method is asynchronous and returns a Task<T>.    
        // The 'await' keyword is used to asynchronously wait for the result.   
        // The 'T' type parameter must be a class (reference type). 
        public async Task<T> GetByIdAsync(int id)
        {
            // Finds the entity in the DbSet<T> using its key.
           var  response= await _applicationDbContext.Set<T>().FindAsync(id);
            // If the entity is not found, it returns null.
            if (response == null)
            {
                return null;
            }
            // If the entity is found, it returns the entity.
            return response;
        }

        // Retrieves a single entity by its primary key ID.
        // This method is specific to the Position entity.
        // It uses a LINQ query to filter the Position records by their ID.
        // This method is not generic and is specific to the Position entity.
        //public async Task<Position> GetByIdAsync2(int id)
        //{
        //    return await _applicationDbContext.Positions.Where(f => f.PositionID == id).FirstOrDefaultAsync();
        //}

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
        // This method is generic and can be used for any entity type T.
        // It uses the Remove method to mark the entity as deleted in the DbSet<T>.
        // The changes are saved to the database using SaveChangesAsync.
        // The method is asynchronous and returns a Task.
        public async Task DeleteAsync(T entity)
        {
            // Marks the entity as deleted in the DbSet<T>.
            _applicationDbContext.Set<T>().Remove(entity);

            // Saves the change (delete) to the database.
            await _applicationDbContext.SaveChangesAsync();
        }

        //public async Task DeleteAsync(T entity)
        //{
        //    // Checks if the entity is null.    
        //    if (entity == null)
        //    {
        //        // If the entity is null, it throws an exception.
        //        throw new ArgumentNullException(nameof(entity));
        //    }
        //    // Checks if the entity is being tracked by the DbContext.
        //    var entry = _applicationDbContext.Entry(entity);
        //    if (entry.State == EntityState.Detached)
        //    {
        //        // If the entity is not being tracked, it attaches it to the DbContext.
        //        _applicationDbContext.Set<T>().Attach(entity);
        //    }
        //    // Removes the entity from the DbSet<T>.
        //    _applicationDbContext.Set<T>().Remove(entity);
        //    // Saves the changes to the database.
        //    await _applicationDbContext.SaveChangesAsync();
        //    //    return entity;
        //    // If the entity is not found, it returns null.
        //}

        // Deletes the given entity of type T from the database.
        // This method is generic and can be used for any entity type T.
        // It uses the Remove method to mark the entity as deleted in the DbSet<T>.
        // The changes are saved to the database using SaveChangesAsync.
        // The method is asynchronous and returns a Task<bool>.
        // The method returns true if the entity was deleted successfully, otherwise false.
        //public async Task<bool> DeleteAsync(T entity)
        //{
        //    // marks the entity as deleted in the DbSet<T>.
        //    _applicationDbContext.Set<T>().Remove(entity);
        //    // Saves the change (delete) to the database.
        //    var result = await _applicationDbContext.SaveChangesAsync();
        //    // If the result is greater than 0, it means the entity was deleted successfully.
        //    if (result > 0)
        //    {
        //        return true;
        //    }
        //    // If the result is 0, it means the entity was not found or not deleted.
        //    return false;

        //}

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
