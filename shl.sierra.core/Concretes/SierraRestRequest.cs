using RestSharp;

namespace shl.sierra.core.Concretes
{
    internal class SierraRestRequest
    {
        private readonly string _accessToken;

        public SierraRestRequest(string accessToken)
        {
            _accessToken = accessToken;
        }


        public RestRequest Execute(string resource, Method method)
        {
            var request = new RestRequest(resource, method);

            request.AddHeader("Authorization", _accessToken);


            return request;
        }


    }
}
