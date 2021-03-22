using shl.sierra.core.Enums;

namespace shl.sierra.core.Interfaces
{
    public interface IBibsApi
    {
        /// <summary>
        /// Returns a full patron objedt with all var fields. 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="fields"></param>
        /// <param name="query"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        string Search(Indexes index, string query, string[] fields = null, int limit = 20);

        string GetById(int id, string[] fields = null);
    }
}