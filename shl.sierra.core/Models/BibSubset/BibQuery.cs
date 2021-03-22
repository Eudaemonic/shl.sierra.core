using System.Collections.Generic;

namespace shl.sierra.core.Models.BibSubset
{
    public class BibQuery
    {
        public int count { get; set; }
        public int total { get; set; }
        public int start { get; set; }
        public List<EntryLink> entries { get; set; }
    }


    public class EntryLink
    {
        public string link { get; set; }
    }
}
