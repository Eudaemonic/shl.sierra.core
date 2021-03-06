using RestSharp;
using shl.sierra.core.Interfaces;
using System.Threading.Tasks;

namespace shl.sierra.core.Concretes
{
    public class ItemsApiAsync : IItemsApiAsync
    {
        #region Initialiser

        private readonly ISierraRestClient _sierraRestClient;

        public ItemsApiAsync(ISierraRestClient sierraRestClient)
        {
            _sierraRestClient = sierraRestClient;
        }

        #endregion

        #region Methods

        public async Task<string> Get(string[] itemIds = null, string status = "", string[] bibIds = null, string[] fields = null, string[] locations = null, int limit = 50,
            int offset = 0, string suppressedOnly = "")
        {
            var request = _sierraRestClient.Execute(Branch.items, "/", Method.GET);

            if (fields != null) request.AddQueryParameter("fields", string.Join(",", fields));

            if (itemIds != null) request.AddQueryParameter("id", string.Join(",", itemIds));

            if (locations != null) request.AddQueryParameter("locations", string.Join(",", locations));

            if (!string.IsNullOrWhiteSpace(status)) request.AddQueryParameter("status", status);
            if (!string.IsNullOrWhiteSpace(suppressedOnly)) request.AddQueryParameter("suppressed", suppressedOnly);

            if (bibIds != null) request.AddQueryParameter("bibIds", string.Join(",", bibIds));

            request.AddQueryParameter("limit", limit.ToString());

            // execute the request
            var result = await _sierraRestClient.Client.ExecuteAsync(request);

            return result.Content;
        }

        public async Task<string> Get(string id, string[] fields = null)
        {

            var request = _sierraRestClient.Execute(Branch.items, $"/{id}", Method.GET);

            if (fields != null) request.AddQueryParameter("fields", string.Join(",", fields));

            // execute the request
            var result = await _sierraRestClient.Client.ExecuteAsync(request);

            return result.Content;


        }

        public async Task<string> Query(string json, int offset, int limit)
        {
            var request = _sierraRestClient.Execute(Branch.items, "/query", Method.POST);

            request.AddQueryParameter("offset", offset.ToString());
            request.AddQueryParameter("limit", limit.ToString());
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            // execute the request
            var x = await _sierraRestClient.Client.ExecutePostAsync(request);

            return x.Content;
        }


        #endregion

        #region Helpers

        #endregion

    }
}