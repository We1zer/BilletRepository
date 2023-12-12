using BilletAPI.Data;
using BilletAPI.Models;
using BilletAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Linq.Expressions;

namespace BilletAPI.Repository
{
    public class BilletRepository :Repository<Billet>, IBilletRepository
    {
        private readonly ApplicationDbContext _db;
        public BilletRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
       
   
        public async Task<Billet> UpdateAsync(Billet entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.Billets.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
