using Data.DatabaseContext;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Implementations
{
    public class AllRepositories<TEntity> : IRepositories<TEntity> where TEntity : class
    {
        private readonly Lab34Context _dbContext;
        DbSet<TEntity> Entities { get; set; }
        DbSet<TEntity> IRepositories<TEntity>.Entities { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public AllRepositories()
        {

        }
        public async Task<TEntity> AddOneAsyn(TEntity entity)
        {
            return (await this.Entities.AddAsync(entity)).Entity;
        }

        public async Task<TEntity> AddManyAsyn(IEnumerable<TEntity> entity)
        {
            Collection<TEntity> result = new Collection<TEntity>();
            foreach (var item in entity) // thêm từng cái 1
            {
                Collection<TEntity> collects = result;
                collects.Add(await this.AddOneAsyn(item));
            }
            return (TEntity)(IEnumerable<TEntity>)result;
        }

        public async Task<TEntity> DeleteOneAsyn(TEntity entity)
        {
            return Entities.Remove(entity).Entity;
        }

        public async Task<TEntity> DeleteManyAsyn(IEnumerable<TEntity> entity)
        {
            Collection<TEntity> result = new Collection<TEntity>();
            foreach (var item in entity) // thêm từng cái 1
            {
                Collection<TEntity> collects = result;
                collects.Add(await this.DeleteOneAsyn(item));
            }
            return (TEntity)(IEnumerable<TEntity>)result;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Entities.ToListAsync();
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            return await Entities.FindAsync(id);
        }

        public async Task<TEntity> UpdateOneAsyn(TEntity entity)
        {
            return Entities.Update(entity).Entity;
        }

        public async Task<IEnumerable<TEntity>> UpdateManyAsyn(IEnumerable<TEntity> entity)
        {
            Collection<TEntity> result = new Collection<TEntity>();
            foreach (var item in entity) // thêm từng cái 1
            {
                Collection<TEntity> collects = result;
                collects.Add(await this.UpdateOneAsyn(item));
            }
            return (IEnumerable<TEntity>)result;
        }
    }
}
