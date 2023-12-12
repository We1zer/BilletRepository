using BilletAPI.Models;
using System.Linq.Expressions;

namespace BilletAPI.Repository.IRepository
{
    public interface IBilletRepository:IRepository<Billet>
    {
       
        Task<Billet> UpdateAsync(Billet entity);
       

    }
}
