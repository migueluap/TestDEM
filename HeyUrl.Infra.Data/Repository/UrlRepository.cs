using HeyUrl.Domain.Interfaces;
using HeyUrl.Domain.Models;
using HeyUrl.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeyUrl.Infra.Data.Repository
{
    public class UrlRepository : IUrlRepository
    {
        protected readonly HeyUrlContext Db;
        protected readonly DbSet<Url> DbSet;
        public UrlRepository(HeyUrlContext context)
        {
            Db = context;
            DbSet = Db.Set<Url>();
        }
        public IUnitOfWork UnitOfWork => Db;
        public void Add(Url url)
        {
            Db.Add(url);
        }
        public async Task<IEnumerable<Url>> GetByAll()
        {
            return await DbSet.ToListAsync();
        }
        public async Task<Url> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }
        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
