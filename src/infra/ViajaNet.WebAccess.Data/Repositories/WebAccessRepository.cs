namespace ViajaNet.WebAccess.Data.Repositories
{
    using System.Threading.Tasks;
    using Microsoft.Extensions.Options;
    using ViajaNet.WebAccess.Data.Options;
    using ViajaNet.WebAccess.Domain.Repositories;
    using ViajaNet.WebAccess.Domain.Views;
    using Couchbase.Views;
    using System.Collections.Generic;
    using System.Linq;

    public class WebAccessRepository : CouchbaseRepository<Domain.Models.WebAccess>, IWebAccessRepository
    {
        public WebAccessRepository(IOptions<CouchbaseOptions> options) : base(options)
        {
        }

        public async Task<IEnumerable<BrowserView>> GetBrowsersKPI()
        {
            var query = new ViewQuery().From(this.Options.Value.DesignDoc, "webaccess-browsers").FullSet().Group(true);
            var result = await this.Query<dynamic>(query);

            return result.Rows.Select(t => new BrowserView
            {
                Key = t.Key,
                Value = t.Value
            });
        }

        public async Task<IEnumerable<AccessPerHourView>> GetAccessPerHourKPI()
        {
            var query = new ViewQuery().From(this.Options.Value.DesignDoc, "webaccess-time").FullSet().Group(true);
            var result = await this.Query<dynamic>(query);

            return result.Rows.Select(t => new AccessPerHourView
            {
                Key = t.Key,
                Value = t.Value
            });
        }
    }
}
