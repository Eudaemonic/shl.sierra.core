using RestSharp;
using shl.sierra.core.Interfaces;

namespace shl.sierra.core.Concretes
{
    public class ItemsApi : IItemsApi
    {
        #region Initialiser

        private readonly ISierraRestClient _sierraRestClient;

        public ItemsApi(ISierraRestClient sierraRestClient)
        {
            _sierraRestClient = sierraRestClient;
        }

        #endregion

        #region Methods

        public string Get(string[] itemIds = null, string status = "", string[] bibIds = null, string[] fields = null, string[] locations = null, int limit = 50,
            int offset = 0)
        {
            var request = _sierraRestClient.Execute(Branch.items, "/", Method.GET);


            if (fields != null) request.AddQueryParameter("fields", string.Join(",", fields));

            if (itemIds != null) request.AddQueryParameter("id", string.Join(",", itemIds));

            if (locations != null) request.AddQueryParameter("locations", string.Join(",", locations));

            if (!string.IsNullOrWhiteSpace(status)) request.AddQueryParameter("status", status);

            if (bibIds != null) request.AddQueryParameter("bibIds", string.Join(",", bibIds));

            request.AddQueryParameter("limit", limit.ToString());

            // execute the request
            var result = _sierraRestClient.Client.Execute(request).Content;

            return result;
        }

        #endregion

        #region Helpers

        #endregion

    }
}