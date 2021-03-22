using System.Collections.Generic;

namespace shl.sierra.core.Models
{
    public class PatronMetaData
    {

        public string field { get; set; }
        public List<Value> values { get; set; }


        public class Value
        {
            public string code { get; set; }
            public string desc { get; set; }
        }




    }
}
