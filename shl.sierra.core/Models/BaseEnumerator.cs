using shl.sierra.core.Extensions;

namespace shl.sierra.core.Models
{
    public class BaseEnumerator
    {
        public int total { get; set; }
        public int start { get; set; }
        public Entry[] entries { get; set; }
    }

    public class Entry
    {
        public int recordNo;

        public string link
        {
            get =>  recordNo.ToString();
            set => recordNo = value.GetIdAsIntFromLink();
        }
    }
}