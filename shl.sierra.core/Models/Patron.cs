using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;


namespace shl.sierra.core.Models
{
    public class Patron
    {


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? id { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [DisplayName("Email")]
        public List<string> emails { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [DisplayName("Name")]
        public List<string> names { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [DisplayName("Patron Type")]
        public int? patronType { get; set; }


        [DisplayName("Address")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<Address> addresses { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [DisplayName("Barcode")]
        public List<string> barcodes { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [DisplayName("Expiry Date")]
        public string expirationDate { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [DisplayName("Patron Codes")]
        public PatronCodes patronCodes { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<VarField> varFields { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dictionary<int, FixedFieldEntry> fixedFields { get; set; }
    }


    public class Address
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string> lines { get; set; }

        public string type { get; set; }
    }

    public class PatronCodes
    {
        [DisplayName("Pcode 1")]
        public string pcode1 { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [DisplayName("Pcode 2")]
        public string pcode2 { get; set; }

        [DisplayName("Pcode 3")]
        public int pcode3 { get; set; }

        [DisplayName("Pcode 4")]
        public int pcode4 { get; set; }
    }

    public class VarField
    {

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string fieldTag { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string content { get; set; }
    }



    public class FixedFieldEntry
    {
        public string label { get; set; }
        public string value { get; set; }


    }

    public class Canvas
    {
        void test()
        {
            var x = new Patron();

            var y = new Dictionary<int, List<List<FixedFieldEntry>>>();


        }
    }



}