﻿using CRM.Domain.Core;
using CRM.Domain.Entity.Base;
using CRM.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.EntityFramework.Repositories.Base
{
    public class ORMBaseRepository<T, TPrimaryKey> : BaseRepository<T>, IBaseRepository<T>, IDisposable
      where T : BaseEntity<int>
    {
        private DataContext context;
        private DbSet<T> table;
        string errorMessage = string.Empty;

        public ORMBaseRepository(DataContext context) : base(context)
        {
            this.context = context;
            table = context.Set<T>();
        }

        public DataContext GetDataContext()
        {
            return context;
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            var entity = table.FirstOrDefault(s => s.Id == id && s.IsDeleted == false);
            if (entity == null)
            {
                return;
            }
            DeleteSoft(entity);
        }

        private void DeleteSoft(T entity)
        {
            entity.IsDeleted = true;
            SaveChanges();
        }

        public override T Get(int id)
        {
            return table.FirstOrDefault(s => s.Id == id && s.IsDeleted==false);
        }

        public override IEnumerable<T> GetAll()
        {
            return table.AsEnumerable().Where(s=> s.IsDeleted==false);
        }

        public override T Insert(T entity)
        {
            table.Add(entity);
            return entity;
        }

        public override void SaveChanges()
        {
            context.SaveChanges();
        }

        public override async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public override T Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public override async Task<IEnumerable<T>> GetAllAsync()
        {
            return await table.Where(s => s.IsDeleted == false).ToListAsync();
        }

        public override async Task<T> GetAsync(int id)
        {
            return await table.FirstOrDefaultAsync(s => s.Id == id && s.IsDeleted == false);
        }

        public override async Task<T> InsertAsync(T entity)
        {
            return await Task.FromResult(table.Add(entity));
        }

        public override async Task<T> UpdateAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return await Task.FromResult(entity);
        }

        public void Dispose()
        {
            if (context != null)
                context.Dispose();
        }

    }
}
