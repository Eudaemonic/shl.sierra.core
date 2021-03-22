using System.Text.Json.Serialization;

namespace shl.sierra.core.Models.PatronSubset
{
    public class ErrorCode
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("specificCode")]
        public string SpecificCode { get; set; }

        [JsonPropertyName("httpStatus")]
        public string HttpStatus { get; set; }

        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}