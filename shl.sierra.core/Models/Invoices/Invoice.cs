using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace shl.sierra.core.Models.Invoices
{

    public class Invoice
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("accountingUnit")]
        public long AccountingUnit { get; set; }

        [JsonPropertyName("invDate")]
        public DateTime InvDate { get; set; }

        [JsonPropertyName("invNum")]
        public string InvNum { get; set; }

        [JsonPropertyName("vendors")]
        public Vendor[] Vendors { get; set; }

        [JsonPropertyName("paidDate")]
        public DateTimeOffset PaidDate { get; set; }

        [JsonPropertyName("invTotal")]
        public InvTotal InvTotal { get; set; }

        [JsonPropertyName("lineItems")]
        public Uri[] LineItems { get; set; }

        [JsonPropertyName("statusCode")]
        public string StatusCode { get; set; }


        [JsonPropertyName("taxType")]
        public string TaxType { get; set; }

        [JsonPropertyName("foreignCurrency")]
        public ForeignCurrency ForeignCurrency { get; set; }



    }

    public class InvTotal
    {
        [JsonPropertyName("subTotal")]
        public double SubTotal { get; set; }

        [JsonPropertyName("shipping")]
        public long Shipping { get; set; }

        [JsonPropertyName("tax")]
        public long Tax { get; set; }

        [JsonPropertyName("discountOrService")]
        public long DiscountOrService { get; set; }

        [JsonPropertyName("grandTotal")]
        public double GrandTotal { get; set; }
    }
    public class ForeignCurrency
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("rate")]
        public string Rate { get; set; }

        [JsonPropertyName("format")]
        public string Format { get; set; }
    }

    public class Vendor
    {
        [JsonPropertyName("vendorCode")]
        public string VendorCode { get; set; }

        [JsonPropertyName("voucherNum")]
        public long VoucherNum { get; set; }

        [JsonPropertyName("voucherTotal")]
        public long VoucherTotal { get; set; }
    }

    public class UseTax
    {
        [JsonPropertyName("useTaxFund")]
        public string UseTaxFund { get; set; }

        [JsonPropertyName("percentageRate")]
        public decimal PercentageRate { get; set; }

        [JsonPropertyName("useTaxType")]
        public string UseTaxType { get; set; }


    }

    public class Invoices
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("entries")]
        public List<Invoice> Entries { get; set; }


    }
}

