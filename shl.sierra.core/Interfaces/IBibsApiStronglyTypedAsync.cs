using System.Threading.Tasks;
using shl.sierra.core.Enums;
using shl.sierra.core.Models.BibSubset;

namespace shl.sierra.core.Interfaces
{
    public interface IBibsApiStronglyTypedAsync
    {
        Task<BibsModel> GetById(int id, string[] fields = null);
        Task<BibSearchModel> Search(Indexes index, string query, string[] fields = null, int limit = 20);
        Task<BibQuery> Query(string jsonQuery, int limit = 20, int offset = 0);
    }
}