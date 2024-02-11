using Microsoft.EntityFrameworkCore.Storage;

namespace BuildingManagement.Repository;
public interface IUnitOfWork
{
    int Commit();
    Task<int> CommitAsync();
    IDbContextTransaction BeginTransaction();
}