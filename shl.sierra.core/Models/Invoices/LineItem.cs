using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace shl.sierra.core.Models.Invoices
{
    public class LineItem
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("invoice")]
        public Uri Invoice { get; set; }

        [JsonPropertyName("order")]
        public Uri Order { get; set; }

        [JsonPropertyName("paidAmount")]
        public decimal PaidAmount { get; set; }

        [JsonPropertyName("lienAmount")]
        public decimal LienAmount { get; set; }

        [JsonPropertyName("lienFlag")]
        public long LienFlag { get; set; }

        [JsonPropertyName("fund")]
        public string Fund { get; set; }

        [JsonPropertyName("subFund")]
        public long SubFund { get; set; }

        [JsonPropertyName("noOfCopies")]
        public long NoOfCopies { get; set; }

        [JsonPropertyName("orderStatus")]
        public string OrderStatus { get; set; }

        [JsonPropertyName("lineItemNote")]
        public string LineItemNote { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("multiFlag")]
        public string MultiFlag { get; set; }

        [JsonPropertyName("vendor")]
        public string Vendor { get; set; }
    }


    public class LineItems
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("entries")]
        public List<LineItem> Entries { get; set; }


    }
}
