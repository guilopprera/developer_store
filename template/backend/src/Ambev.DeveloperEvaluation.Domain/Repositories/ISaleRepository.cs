using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for Sale entity operations
/// </summary>
public interface ISaleRepository
{
    /// <summary>
    /// Retrieves a sale by its unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the sale</param>
    /// <returns>The sale if found, null otherwise</returns>
    Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves all the existing sales
    /// </summary>
    /// <param name="id">The unique identifier of the sale</param>
    /// <returns>The sale if found, null otherwise</returns>
    Task<List<Sale>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Creates a new sale in the repository
    /// </summary>
    /// <param name="sale">The sale to create</param>
    /// <returns>The created sale</returns>
    Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken);

    /// <summary>
    /// Updates a new sale in the repository
    /// </summary>
    /// <param name="sale">The sale to update</param>
    /// <returns>The updated sale</returns>
    Task UpdateAsync(Sale sale, CancellationToken cancellationToken);

    /// <summary>
    /// Get a sale with its items 
    /// </summary>
    /// <param name="id">The sale id</param>
    /// <returns>The updated sale</returns>
    Task<Sale?> GetByIdWithItemsAsync(Guid id, CancellationToken ct);

    /// <summary>
    /// Deletes a sale from the repository
    /// </summary>
    /// <param name="id">The unique identifier of the sale to delete</param>
    /// <returns>True if the sale was deleted, false if not found</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);

}
