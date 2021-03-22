using System;
using System.Threading.Tasks;
using shl.sierra.core.Enums;

namespace shl.sierra.core.Interfaces
{
    public interface IInvoicesApiAsync
    {
        Task<string> Get(string login, DateTime? startDate, DateTime? endTime, InvoiceDateQuery dateToQuery, string status = "", string[] Ids = null, string[] fields = null, string[] locations = null, int limit = 50,
            int offset = 0);

        Task<string> Get(string login, string id, string[] fields = null);


        Task<string> LineItems(string id, string login, string[] fields = null);
    }
}