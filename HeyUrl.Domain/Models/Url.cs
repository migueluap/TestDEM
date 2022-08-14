using NetDevPack.Domain;
using System;

namespace HeyUrl.Domain.Models
{
    public class Url : Entity, IAggregateRoot
    {

        public Url(Guid id, string shortUrl, int count)
        {
            Id = id;
            ShortUrl = shortUrl;
            Count = count;
        }

        //Empty to EF Constructor
        protected Url() { }

        public Guid Id { get; private set; }
        public string ShortUrl { get; private set; }
        public int Count { get; private set; }
    }
}
