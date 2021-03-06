using RestSharp;
using shl.sierra.core.Enums;
using shl.sierra.core.Helpers;
using shl.sierra.core.Interfaces;
using System;
using System.Threading.Tasks;

namespace shl.sierra.core.Concretes
{
    public class VendorApiAsync : IVendorApiAsync
    {
        #region Initialiser

        private readonly ISierraRestClient _sierraRestClient;

        public VendorApiAsync(ISierraRestClient sierraRestClient)
        {
            _sierraRestClient = sierraRestClient;
        }

        #endregion

        #region Methods

        public async Task<string> Get(string login, DateTime? startDate, DateTime? endDate, InvoiceDateQuery dateToQuery, string[] code = null, string[] ids = null, string[] fields = null, int limit = 50,
            int offset = 0)
        {
            var request = _sierraRestClient.Execute(Branch.vendors, "/", Method.GET);

            if (startDate.HasValue && endDate.HasValue)
            {
                request.AddQueryParameter(dateToQuery.ToString(), DateHelpers.FormatSierraDateRange(startDate.Value, endDate.Value));

            }
            request.AddQueryParameter("login", login.Trim());

            if (fields != null) request.AddQueryParameter("fields", string.Join(",", fields));

            if (code != null) request.AddQueryParameter("code", string.Join(",", code));

            if (ids != null) request.AddQueryParameter("id", string.Join(",", ids));

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



        #endregion

    }




}