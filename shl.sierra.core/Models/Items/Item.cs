using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace shl.sierra.core.Models.Items
{
    public class Location
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Status
    {
        public string code { get; set; }
        public string display { get; set; }
        public DateTime? duedate { get; set; }
    }

    public class Item
    {
        public string id { get; set; }
        public DateTime updatedDate { get; set; }
        public DateTime createdDate { get; set; }
        public bool deleted { get; set; }
        public List<string> bibIds { get; set; }
        public Location location { get; set; }
        public Status status { get; set; }
        public string barcode { get; set; }
        public string callNumber { get; set; }

        [JsonPropertyName("varFields")]
        public VarField[] varFields { get; set; }
    }

    public  class VarField
    {
        [JsonPropertyName("fieldTag")]
        public string FieldTag { get; set; }

        [JsonPropertyName("content")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Content { get; set; }

        [JsonPropertyName("marcTag")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string MarcTag { get; set; }

        [JsonPropertyName("ind1")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Ind1 { get; set; }

        [JsonPropertyName("ind2")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Ind2 { get; set; }

        [JsonPropertyName("subfields")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Subfield[] Subfields { get; set; }
    }

    public  class Subfield
    {
        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }
    }

    public class ItemResult
    {
        public int total { get; set; }
        
        public List<Item> entries { get; set; }
    }
}
