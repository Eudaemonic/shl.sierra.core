using System.Threading.Tasks;

namespace shl.sierra.core.Interfaces
{
    public interface IItemsApiAsync
    {
        Task<string> Get(string[] itemIds = null, string status = "", string[] bibIds = null, string[] fields = null, string[] locations = null, int limit = 50,
            int offset = 0, string suppressedOnly = "");

        Task<string> Get(string id, string[] fields = null);


        Task<string> Query(string json, int offset, int limit);
    }
}