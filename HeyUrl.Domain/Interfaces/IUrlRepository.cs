using HeyUrl.Domain.Models;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeyUrl.Domain.Interfaces
{
    public interface IUrlRepository : IRepository<Url>
    {
        Task<Url> GetById(Guid id);
        Task<IEnumerable<Url>> GetByAll();

        void Add(Url url);
    }
}
