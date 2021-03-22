using System.Collections.Generic;

namespace shl.sierra.core.Models.BibSubset
{


    public class Bib
    {
        public string id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public int publishYear { get; set; }
        public List<Location> locations { get; set; }
    }

    public class Entry
    {
        public double relevance { get; set; }
        public Bib bib { get; set; }
    }


    public class BibSearchModel
    {
        public int count { get; set; }
        public int total { get; set; }
        public int start { get; set; }
        public List<Entry> entries { get; set; }
    }
}
