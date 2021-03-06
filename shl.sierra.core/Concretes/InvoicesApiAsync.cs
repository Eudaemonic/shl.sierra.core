using RestSharp;
using shl.sierra.core.Enums;
using shl.sierra.core.Interfaces;
using System;
using System.Text;
using System.Threading.Tasks;

namespace shl.sierra.core.Concretes
{
    public class InvoicesApiAsync : IInvoicesApiAsync
    {
        #region Initialiser

        private readonly ISierraRestClient _sierraRestClient;

        public InvoicesApiAsync(ISierraRestClient sierraRestClient)
        {
            _sierraRestClient = sierraRestClient;
        }

        #endregion

        #region Methods

        public async Task<string> Get(string login, DateTime? startDate, DateTime? endDate, InvoiceDateQuery dateToQuery, string status = "", string[] Ids = null, string[] fields = null, string[] locations = null, int limit = 50,
            int offset = 0)
        {
            var request = _sierraRestClient.Execute(Branch.invoices, "/", Method.GET);

            if (startDate.HasValue && endDate.HasValue)
            {
                request.AddQueryParameter(dateToQuery.ToString(), FormatSierraDateRange(startDate.Value, endDate.Value));

            }
            request.AddQueryParameter("login", login.Trim());

            if (fields != null) request.AddQueryParameter("fields", string.Join(",", fields));

            if (!string.IsNullOrWhiteSpace(status)) request.AddQueryParameter("status", status);

            if (Ids != null) request.AddQueryParameter("id", string.Join(",", Ids));

            request.AddQueryParameter("limit", limit.ToString());

            request.AddQueryParameter("offset", offset.ToString());

            // execute the request
            var result = await _sierraRestClient.Client.ExecuteAsync(request);

            return result.Content;
        }

        public async Task<string> Get(string login, string id, string[] fields = null)
        {

            var request = _sierraRestClient.Execute(Branch.invoices, $"/{id}", Method.GET);

            request.AddQueryParameter("login", login.Trim());

            if (fields != null) request.AddQueryParameter("fields", string.Join(",", fields));

            // execute the request
            var result = await _sierraRestClient.Client.ExecuteAsync(request);

            return result.Content;


        }

        public async Task<string> LineItems(string id, string login, string[] fields = null)
        {
            var request = _sierraRestClient.Execute(Branch.invoices, $"/{id}/lineItems", Method.GET);

            request.AddQueryParameter("login", login.Trim());

            if (fields != null) request.AddQueryParameter("fields", string.Join(",", fields));
            // execute the request
            var result = await _sierraRestClient.Client.ExecuteAsync(request);

            return result.Content;
        }

        #endregion

        #region Helpers

        string FormatSierraDateRange(DateTime startDate, DateTime endDate)
        {

            var sb = new StringBuilder();
            if (endDate != default)
            {
                sb.Append("[");
                sb.Append(startDate.ToString("s"));
                sb.Append(",");
                sb.Append(endDate.ToString("s"));
                sb.Append("]");
                return sb.ToString();
            }
            return startDate.ToString("s");
        }

        #endregion

    }
}