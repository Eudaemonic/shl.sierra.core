using RestSharp;
using shl.sierra.core.Enums;
using shl.sierra.core.Interfaces;

namespace shl.sierra.core.Concretes
{
    public class BibsApi : IBibsApi
    {
        #region Initialiser


        private readonly ISierraRestClient _sierraRestClient;

        public BibsApi(ISierraRestClient sierraRestClient)
        {
            _sierraRestClient = sierraRestClient;

        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a full patron objedt with all var fields. 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="fields"></param>
        /// <param name="query"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public string Search(Indexes index, string query, string[] fields = null, int limit = 20)
        {
            if (fields is null)
            {
                fields = new[] { "title", "author", "publishYear" };
            }
            var request = _sierraRestClient.Execute(Branch.bibs, "/search", Method.GET);

            if (index != Indexes.none)
            {
                request.AddQueryParameter("index", index.ToString());
            }
            request.AddQueryParameter("fields", string.Join(",", fields));
            request.AddQueryParameter("text", query.ToLower());
            request.AddQueryParameter("limit", limit.ToString());

            // execute the request
            var result = _sierraRestClient.Client.Execute(request).Content;

            return result;

        }



        public string GetById(int id, string[] fields = null)
        {
            if (fields == null || fields.Length == 0)
            {
                fields = new[] { "title", "author", "publishYear", "available", "varFields" };
            }
            var request = _sierraRestClient.Execute(Branch.bibs, "/" + id, Method.GET);

            request.AddQueryParameter("fields", string.Join(",", fields));
            // execute the request
            return _sierraRestClient.Client.Execute(request).Content;

        }


        #endregion

        #region Helpers



        #endregion
    }
}
