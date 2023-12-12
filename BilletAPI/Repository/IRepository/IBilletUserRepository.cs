using BilletAPI.Models;
using System.Linq.Expressions;

namespace BilletAPI.Repository.IRepository
{
    public interface IBilletUserRepository:IRepository<BilletUser>
    {
       
        Task<BilletUser> UpdateAsync(BilletUser entity);
       

    }
}
