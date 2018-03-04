namespace ViajaNet.WebAccess.Data.Repositories
{
    using Couchbase;
    using Couchbase.Authentication;
    using Couchbase.Configuration.Client;
    using Couchbase.Views;
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ViajaNet.WebAccess.Data.Options;
    using ViajaNet.WebAccess.Domain.Core.Models;

    public class CouchbaseRepository<T> where T : Entity
    {
        private readonly Cluster cluster;

        protected IOptions<CouchbaseOptions> Options { get; set; }

        public CouchbaseRepository(IOptions<CouchbaseOptions> options)
        {
            this.Options = options;

            this.cluster = new Cluster(new ClientConfiguration
            {
                Servers = new List<Uri> { new Uri(options.Value.Url) }
            });

            var authenticator = new PasswordAuthenticator(options.Value.User, options.Value.Password);
            cluster.Authenticate(authenticator);
        }

        public async Task Insert(T entity)
        {
            using (var bucket = await cluster.OpenBucketAsync(this.Options.Value.Bucket))
            {
                var document = new Document<T>
                {
                    Id = entity.Id.ToString(),
                    Content = entity
                };

                var upsert = await bucket.UpsertAsync(document);
            }
        }

        public async Task<IViewResult<T>> Query<T>(IViewQuery query)
        {
            using (var bucket = await cluster.OpenBucketAsync(this.Options.Value.Bucket))
            {
                return await bucket.QueryAsync<T>(query);
            }
        }
    }
}
