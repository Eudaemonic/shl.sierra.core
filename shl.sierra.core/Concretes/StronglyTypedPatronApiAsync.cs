using shl.sierra.core.Enums;
using shl.sierra.core.Interfaces;
using shl.sierra.core.Models;
using shl.sierra.core.Models.FinesSet;
using shl.sierra.core.Models.PatronSubset;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace shl.sierra.core.Concretes
{
    public class StronglyTypedPatronApiAsync : IStronglyTypedPatronApiAsync
    {
        private readonly PatronApiAsync _patron;


        public StronglyTypedPatronApiAsync(ISierraRestClient sierraRestClient)
        {
            _patron = new PatronApiAsync(sierraRestClient);

        }

        public async Task<BaseEnumerator> Query(string json, int offset, int limit)
        {
            return JsonSerializer.Deserialize<BaseEnumerator>(await _patron.Query(json, offset, limit));
        }

        /// <summary>
        /// Simple method to replicate the existing barcode function in Sierra.
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public async Task<bool> CheckIfBarcodeExists(string barcode)
        {
            return await _patron.CheckIfBarcodeExists(barcode);
        }

        /// <summary>
        /// Creates a new patron and returns the Id. 
        /// </summary>
        /// <param name="patron"></param>
        /// <returns></returns>
        public async Task<string> Create(Patron patron)
        {
            var json = JsonSerializer.Serialize(patron);

            return await _patron.Create(json);
        }

        /// <summary>
        /// Returns a Patron object from record Id.
        /// The default fields are taken from the public properties of the class
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public async Task<Patron> Get(int id, string fields = null)
        {
            var result = new Patron();

            if (fields == null) fields = GetObjectFieldsAsString<Patron>();

            return JsonSerializer.Deserialize<Patron>(await _patron.Get(id, fields)); ;
        }

        public async Task Update(Patron patron, int? id)
        {
            var json = JsonSerializer.Serialize(patron);

            await _patron.Update(json, id);
        }

        /// <summary>
        ///  Get pcode{0} etc
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<PatronMetaData> GetPatronMetaData(PatronCode code)
        {
            return await _patron.GetPatronMetaData(code);
        }


        /// <summary>
        ///     Method accepts the varField tag and returns a single record.
        /// </summary>
        /// <param name="varFieldTag"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<Patron> GetPatronByVarField(char varFieldTag, string query)
        {
            return JsonSerializer.Deserialize<Patron>(await _patron.GetPatronByVarField(varFieldTag, query));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public async Task<CheckOuts> GetCheckouts(int id, string fields = null)
        {
            if (fields == null) fields = GetCheckOutFields();

            return JsonSerializer.Deserialize<CheckOuts>(await _patron.GetCheckouts(id, fields));
        }

        public async Task<CheckOut> GetCheckout(int id, string fields)
        {
            if (fields == null) fields = GetCheckOutFields();

            return JsonSerializer.Deserialize<CheckOut>(await _patron.GetCheckout(id, fields));
        }


        public async Task<CheckOut> Renew(int id, string fields)
        {
            if (fields == null) fields = GetCheckOutFields();

            return JsonSerializer.Deserialize<CheckOut>(await _patron.Renew(id, fields));
        }



        #region Fines


        public async Task<bool> Charge(int recordId, int amount, string reason, string location)
        {
            return await _patron.Charge(recordId, amount, reason, location);
        }


        public async Task<Fines> Fines(int recordId)
        {
            return JsonSerializer.Deserialize<Fines>(await _patron.Fines(recordId));
        }


        public async Task<bool> Payment(int recordId, Payments payments)
        {
            return await _patron.Payment(recordId, payments);
        }


        public async Task<Holds> Holds(int recordId)
        {
            return JsonSerializer.Deserialize<Holds>(await _patron.Holds(recordId));
        }


        #endregion

        #region helpers

        private string GetObjectFieldsAsString<T>()
        {
            var names = typeof(T).GetProperties().Select(p => p.Name).ToArray();

            return string.Join(",", names);

        }

        private string GetCheckOutFields()
        {
            return $"id,patron,item,dueDate,numberOfRenewals,outDate,recallDate,callNumber,barcode";
        }

        #endregion
    }
}