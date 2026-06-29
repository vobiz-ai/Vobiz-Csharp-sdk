using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record ListCustomerTransactionsResponseSummary : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("total_transactions")]
    public required int TotalTransactions { get; set; }

    [JsonPropertyName("total_debit")]
    public required int TotalDebit { get; set; }

    [JsonPropertyName("total_credit")]
    public required int TotalCredit { get; set; }

    [JsonPropertyName("net_amount")]
    public required int NetAmount { get; set; }

    [JsonPropertyName("by_reference_type")]
    public IEnumerable<ListCustomerTransactionsResponseSummaryByReferenceTypeItem> ByReferenceType { get; set; } =
        new List<ListCustomerTransactionsResponseSummaryByReferenceTypeItem>();

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
