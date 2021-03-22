using shl.sierra.core.Enums;
using shl.sierra.core.Models.BibSubset;

namespace shl.sierra.core.Interfaces
{
    public interface IBibsApiStronglyTyped
    {
        BibsModel GetById(int id, string[] fields = null);

        SimpleBib GetBasicModelById(int id, string[] fields = null);

        BibSearchModel Search(Indexes index, string query, string[] fields = null, int limit = 20);
    }
}