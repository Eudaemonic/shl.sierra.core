using RestSharp;
using shl.sierra.core.Enums;
using shl.sierra.core.Interfaces;
using shl.sierra.core.Models;
using shl.sierra.core.Models.FinesSet;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace shl.sierra.core.Concretes
{
    public class PatronApiAsync : IPatronApiAsync
    {
        #region Initialiser

        private readonly ISierraRestClient _sierraRestClient;

        public PatronApiAsync(ISierraRestClient sierraRestClient)
        {
            _sierraRestClient = sierraRestClient;

        }

        #endregion

        #region Methods


        public async Task<string> Get(int id, string fields)
        {
            var request = _sierraRestClient.Execute(Branch.patrons, @"/" + id, Method.GET);

            request.AddQueryParameter("fields", fields);
            // execute the request
            var x = await _sierraRestClient.Client.ExecuteAsync(request);

            return x.Content;
        }


        public async Task<string> Query(string json, int offset, int limit)
        {
            var request = _sierraRestClient.Execute(Branch.patrons, "/query", Method.POST);

            request.AddQueryParameter("offset", offset.ToString());
            request.AddQueryParameter("limit", limit.ToString());
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            // execute the request
            var x = await _sierraRestClient.Client.ExecutePostAsync(request);

            return x.Content;
        }



        /// <inheritdoc />
        /// <summary>
        /// Returns a true if barcode is already in the system
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public async Task<bool> CheckIfBarcodeExists(string barcode)
        {
            var request = _sierraRestClient.Execute(Branch.patrons, "/find", Method.GET);

            request.AddQueryParameter("varFieldTag", "b");
            request.AddQueryParameter("varFieldContent", barcode.Trim());
            request.AddQueryParameter("fields", "id");

            var result = await _sierraRestClient.Client.ExecuteAsync(request);

            return result.StatusCode != HttpStatusCode.NotFound;
        }


        /// <summary>
        /// Creates a new patron from a patron object
        /// Returns ID on creation
        /// </summary>
        /// <param name="patron"></param>
        /// <returns></returns>
        public async Task<string> Create(string patron)
        {
            var request = _sierraRestClient.Execute(Branch.patrons, null, Method.POST);

            request.AddParameter("text/json", patron, ParameterType.RequestBody);

            var result = await _sierraRestClient.Client.ExecutePostAsync(request);

            return result.StatusCode == HttpStatusCode.OK ? GetIdFromLink(result.Content) : string.Empty;
        }





        /// <summary>
        /// Update Patron values
        /// </summary>
        /// <param name="patron">
        /// </param>
        /// <param name="id"></param>
        /// <returns>
        /// </returns>
        public async Task Update(string patron, int? id)
        {

            var request = _sierraRestClient.Execute(Branch.patrons, "/" + id.ToString(), Method.PUT);

            request.AddParameter("text/json", patron, ParameterType.RequestBody);

            await _sierraRestClient.Client.ExecuteAsync(request);
        }

        /// <summary>
        /// Returns the properties of patron objects from the submitted array of ids
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public async Task<string> ListByIds(string[] ids, string fields)
        {
            var request = _sierraRestClient.Execute(Branch.patrons, null, Method.GET);

            request.AddQueryParameter("id", string.Join(",", ids));

            request.AddQueryParameter("fields", fields);
            // execute the request

            var result = await _sierraRestClient.Client.ExecuteAsync(request);

            return result.Content;
        }




        /// <summary>
        /// Get pcode{0} etc
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<PatronMetaData> GetPatronMetaData(PatronCode code)
        {
            var request = _sierraRestClient.Execute(Branch.patrons, "/metadata", Method.GET);

            request.AddQueryParameter("fields", code.ToString());

            var response = await _sierraRestClient.Client.ExecuteAsync<PatronMetaData>(request);

            var result = JsonSerializer.Deserialize<PatronMetaData>(response.Content.Substring(1, response.Content.Length - 2));

            return result;
        }


        /// <summary>
        /// Method accepts the varField tag and returns a single record. 
        /// Returns all fines data for a specified patron record.
        /// </summary>
        /// <param name="varFieldTag"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<string> GetPatronByVarField(char varFieldTag, string query)
        {
            var request = _sierraRestClient.Execute(Branch.patrons, "/find", Method.GET);

            request.AddQueryParameter("varFieldTag", varFieldTag.ToString());
            request.AddQueryParameter("varFieldContent", query);
            request.AddQueryParameter("fields",
                "id,names,barcodes,addresses,expirationDate,patronCodes,varFields,emails,patronType,moneyOwed");
            // execute the request

            IRestResponse response = await _sierraRestClient.Client.ExecuteAsync(request);


            return response.Content;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public async Task<string> GetCheckouts(int id, string fields)
        {

            var request = _sierraRestClient.Execute(Branch.patrons, $"/{id}/checkouts", Method.GET);

            request.AddQueryParameter("fields", fields);

            IRestResponse response = await _sierraRestClient.Client.ExecuteAsync(request);

            return response.Content;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public async Task<string> GetCheckout(int id, string fields)
        {

            var request = _sierraRestClient.Execute(Branch.patrons, $"/checkouts/{id}", Method.GET);

            request.AddQueryParameter("fields", fields);

            IRestResponse response = await _sierraRestClient.Client.ExecuteAsync(request);

            return response.Content;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public async Task<string> Renew(int id, string fields)
        {

            var request = _sierraRestClient.Execute(Branch.patrons, $"/checkouts/{id}/renewal", Method.POST);

            request.AddQueryParameter("fields", fields);

            IRestResponse response = await _sierraRestClient.Client.ExecuteAsync(request);

            return response.Content;
        }
        #endregion

        #region Fines

        public async Task<bool> Charge(int recordId, int amount, string reason, string location)
        {

            var values = new Dictionary<string, object>
            {
                { "amount", amount },
                { "reason", reason},
                { "location", location}
            };
            var request = _sierraRestClient.Execute(Branch.patrons, $"/{recordId}/fines/charge", Method.POST);
            var body = JsonSerializer.Serialize(values);
            request.AddParameter("text/json", body, ParameterType.RequestBody);

            var result = await _sierraRestClient.Client.ExecutePostAsync(request);

            return result.IsSuccessful;
        }


        public async Task<string> Fines(int recordId)
        {

            var request = _sierraRestClient.Execute(Branch.patrons, $"/{recordId}/fines", Method.GET);

            var result = await _sierraRestClient.Client.ExecuteAsync(request);

            return result.Content;
        }



        public async Task<bool> Payment(int recordId, Payments payments)
        {


            var request = _sierraRestClient.Execute(Branch.patrons, $"/{recordId}/fines/payment", Method.PUT);
            var body = JsonSerializer.Serialize(payments);
            request.AddParameter("text/json", body, ParameterType.RequestBody);

            var result = await _sierraRestClient.Client.ExecuteAsync(request);

            return result.IsSuccessful;
        }


        public async Task<string> Holds(int recordId)
        {

            var request = _sierraRestClient.Execute(Branch.patrons, $"/{recordId}/holds", Method.GET);


            var result = await _sierraRestClient.Client.ExecuteAsync(request);

            return result.Content;
        }


        #endregion


        #region StringHelpers

        string GetIdFromLink(string link)
        {
            return link.Contains("/") ? link.Substring(link.LastIndexOf("/", StringComparison.Ordinal) + 1, 7) : string.Empty;
        }

        #endregion

    }
}