# shl.sierra.core
A strongly typed interface for Innovative's Sierra RESTful interface in C# for .Net Core


The Sierra REST API provides access to the Sierra library platform database. It is intended for the use of Innovative customers and their authorized third-party associates, as well as Innovative’s commercial partners.

The Sierra REST API is a Representational State Transfer (REST) API service that provides JSON or XML responses and employs predictable, resource-oriented URLs. The system returns HTTP response codes to indicate errors.
Swagger is here:

https://sandbox.iii.com/iii/sierra-api/swagger/index.html

This version deals explicitly with the PATRON branch, however, the base Sierra Client Interface will accept any branch you build for it. 

Our requirement at the University of London was for a strongly typed interface, so I use some mapping.

## Dependencies
RestSharp 106.2.1


## Using the Client

If you can initiate an instance of the class by calling one of two contructors:

If you do have the bearer token (remember this is only valid for 1 hour):

_patron = new PatronApi(new SierraRestClient(BaseUrl, Token));

If you don't have the bearer token - this will always get a fresh token but it does mean you have two requests for every call:

_patron = new PatronsApi(new SierraRestClient(baseUrl, clientKey, clientSecret)));

        public SierraRestClient(string baseUrl, string accessToken)
        {
            _baseUrl = baseUrl;
            _accessToken = accessToken;

        }

        public SierraRestClient(string baseUrl, string clientKey, string clientSecret)
        {
            _baseUrl = baseUrl;
            _clientKey = clientKey;
            _clientSecret = clientSecret;
            _accessToken = AccessToken;
      }
      
# Patron Endpoint

Once you have created an instance of IPatron interface using the following:

_patron = new PatronsApi(new SierraRestClient(baseUrl, clientKey, clientSecret)));

You can call something like:

		var patron = new StronglyTypedPatronApi(new SierraRestClient(BaseUrl, ClientKey, ClientSecret));

		var x = _patron.Get({Id});

		Assert.AreEqual(x.barcodes.FirstOrDefault(),"{barcode}");






