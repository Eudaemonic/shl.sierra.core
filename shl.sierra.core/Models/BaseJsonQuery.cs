using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace shl.sierra.core.Models
{
    public class BaseJsonQuery
    {
        public Target target { get; set; }
        public Expr expr { get; set; }
    }

    public class Record
    {
        public string type { get; set; }

    }

    public class Field
    {
        public string tag { get; set; }

    }


    public class Target
    {
        public Record record { get; set; }

        [DefaultValue(0), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull & JsonIgnoreCondition.WhenWritingDefault)]

        public int id { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Field field { get; set; }

    }

    public class Expr
    {
        public string op { get; set; }
        public List<string> operands { get; set; }

    }
}
