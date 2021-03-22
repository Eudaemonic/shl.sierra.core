using shl.sierra.core.Models.Items;

namespace shl.sierra.core.Interfaces
{
    public interface IItemsApiStronglyTyped

    {
        ItemResult Get(string[] itemIds = null, string status = "", string[] bibIds = null, string[] fields = null, string[] locations = null, int limit = 50, int offset = 0);
    }
}