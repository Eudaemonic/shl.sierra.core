using System.Linq;
using System.Text.Json;
using shl.sierra.core.Enums;
using shl.sierra.core.Interfaces;
using shl.sierra.core.Models;
using shl.sierra.core.Models.PatronSubset;

namespace shl.sierra.core.Concretes
{
    public class StronglyTypedPatronApi : IStronglyTypedPatronApi
    {
        private readonly PatronApi _patron;



        public StronglyTypedPatronApi(ISierraRestClient sierraRestClient)
        {
            _patron = new PatronApi(sierraRestClient);
          

        }

        /// <summary>
        /// Simple method to replicate the existing barcode function in Sierra.
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public bool CheckIfBarcodeExists(string barcode)
        {
            return _patron.CheckIfBarcodeExists(barcode);
        }

        public ErrorCode Delete(int recordId)
        {
            var json = JsonSerializer.Deserialize<ErrorCode>(_patron.Delete(recordId));

            return json;
        }

        /// <summary>
        /// Creates a new patron and returns the Id. 
        /// </summary>
        /// <param name="patron"></param>
        /// <returns></returns>
        public string Create(Patron patron)
        {
            var json = JsonSerializer.Serialize(patron);

            return _patron.Create(json);
        }

        /// <summary>
        /// Returns a Patron object from record Id.
        /// The default fields are taken from the public properties of the class
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public Patron Get(int id, string fields = null)
        {
            var result = new Patron();

            if (fields == null) fields = GetObjectFieldsAsString<Patron>();

            return JsonSerializer.Deserialize<Patron>(_patron.Get(id, fields)); ;
        }

        public void Update(Patron patron, int? id)
        {
            var json = JsonSerializer.Serialize(patron);

            _patron.Update(json, id);
        }

        /// <summary>
        ///  Get pcode{0} etc
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public PatronMetaData GetPatronMetaData(PatronCode code)
        {
            return _patron.GetPatronMetaData(code);
        }


        /// <summary>
        ///     Method accepts the varField tag and returns a single record.
        /// </summary>
        /// <param name="varFieldTag"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public Patron GetPatronByVarField(char varFieldTag, string query)
        {
            return JsonSerializer.Deserialize<Patron>(_patron.GetPatronByVarField(varFieldTag, query));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public CheckOuts GetCheckouts(int id, string fields = null)
        {
            if (fields == null) fields = GetObjectFieldsAsString<CheckOut>();

            return JsonSerializer.Deserialize<CheckOuts>(_patron.GetCheckouts(id, fields));
        }


        #region helpers

        private string GetObjectFieldsAsString<T>()
        {
            var names = typeof(T).GetProperties().Select(p => p.Name).ToArray();

            return string.Join(",", names);
        }

        #endregion
    }
}