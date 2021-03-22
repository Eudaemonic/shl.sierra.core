using System.Threading.Tasks;
using shl.sierra.core.Enums;

namespace shl.sierra.core.Interfaces
{
    public interface IBibsApiAsync
    {
        /// <summary>
        /// Returns a full patron objedt with all var fields. 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="fields"></param>
        /// <param name="query"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task <string> Search(Indexes index,  string query, string[] fields = null, int limit = 20);

        Task<string> GetById(int id, string[] fields = null);

        Task<string> Query(string jsonQuery, int limit = 20, int offset = 0);

        Task<string> GetMarc(int id);

    }
}