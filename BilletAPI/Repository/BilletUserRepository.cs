using BilletAPI.Data;
using BilletAPI.Models;
using BilletAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Linq.Expressions;

namespace BilletAPI.Repository
{
    public class BilletUserRepository : Repository<BilletUser>, IBilletUserRepository
    {
        private readonly ApplicationDbContext _db;
        public BilletUserRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
       
   
        public async Task<BilletUser> UpdateAsync(BilletUser entity)
        {
            entity.Date = DateTime.Now;
            _db.BilletUsers.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
